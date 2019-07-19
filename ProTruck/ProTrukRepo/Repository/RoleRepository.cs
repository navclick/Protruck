using AutoMapper;
using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace ProTrukRepo.Repository
{
    
    public class RoleRepository : IRoleRepository
    {
        private readonly ProTruckEntities _db;
       
        public RoleRepository()
        {
            _db = new ProTruckEntities();
           
            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Role, RolesVM>();
                cfg.CreateMap<RolesVM, Role>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });
        }

        public async Task<Response> GetAllRoles()
        {
            try
            {
                List<RolesVM> response = new List<RolesVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var roles = await _db.Roles.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Role>, List<RolesVM>>(roles);

                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<RolesVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<RolesVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<RolesVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddRole(RolesVM role)
        {

            var roleDto = Mapper.Map<RolesVM, Role>(role);

            Role roleExist = await _db.Roles.Where(x => x.Role1.Trim() == role.Role1.Trim()).FirstOrDefaultAsync();
            if (roleExist != null) {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Roles.Add(roleDto);
            
            int result = await _db.SaveChangesAsync();

            if (result ==1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                
                return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent,result);
            }


        }

        public async Task<Response> RemoveRole(RolesVM role)
        {
            try
            {
                var roleDto = await _db.Roles.Where(x => x.Id == role.Id).FirstOrDefaultAsync();

                _db.Roles.Remove(roleDto);

                int result = await _db.SaveChangesAsync();

                if (result == 1)
                {
                    // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                    return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MSGFailed, (int)Constant.httpStatus.NoContent, result);
                }
            }
            catch(Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }

    }
}
