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
    public class UserMasterRepository : IUserMasterRepository
    {
        private readonly ProTruckEntities _db;
        public UserMasterRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                cfg.CreateMap<Module, ModuleVM>();
                cfg.CreateMap<Role, RolesVM>();
                cfg.CreateMap<UserVM, User>();

            });
        }
        public async Task<Response>  GetAllUsers()
        {
            try
            {
                List<UserVM> response = new List<UserVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var users =await _db.Users.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response =  Mapper.Map<IEnumerable<User>, List<UserVM>>(users);

                if (response.Count() > 0)
                {
                      return  GenericResponses<IEnumerable<UserVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                     return  GenericResponses<IEnumerable<UserVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                  return GenericResponses<UserVM>.ResponseStatus(true);
            }
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


        


        public Response GetModules() {
            try
            {
                
                List<ModuleVM> response = new List<ModuleVM>();
                var modules = _db.Modules.Select(x => x).ToList();
              //  Mapper.Initialize(cfg => cfg.CreateMap<Module, ModuleVM>());
                response = Mapper.Map<IEnumerable<Module>, List<ModuleVM>>(modules);

                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<ModuleVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<ModuleVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<ModuleVM>.ResponseStatus(true);
            }

        }
       

        public Response ValidateUser(UserVM user) {
            UserVM response = new UserVM();
            UserVM r = new UserVM();
            User result = _db.Users.Where(x => x.Email==user.Email && x.Password== user.Password).FirstOrDefault();
            if (result != null)
            {
               // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<User, UserVM>(result);
                return GenericResponses<UserVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
            }
            else {
                return GenericResponses<UserVM>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent, null);
            }


        }

        public async Task<bool> Adduser(UserVM user) {

            var userDto = Mapper.Map<UserVM, User>(user);
             _db.Users.Add(userDto);

            int result = await _db.SaveChangesAsync();

            if (result == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public async Task<bool> RemoveUser(UserVM user)
        {
            var userDto = await _db.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
            
            _db.Users.Remove(userDto);

            int result = await _db.SaveChangesAsync();

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
