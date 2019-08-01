using ProTrukRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using AutoMapper;
using System.Data.Entity;
using ProTrukRepo.Util;

namespace ProTrukRepo.Repository
{
  public  class VendorRepository : IVendorRepository
    {

        private readonly ProTruckEntities _db;
        public VendorRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Vendor, VendorVM>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City1.City1.Trim())); ;
                cfg.CreateMap<VendorVM, Vendor>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });


        }

        public async Task<Response> GetallVendors()
        {
            try
            {
                List<VendorVM> response = new List<VendorVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Vendors.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Vendor>, List<VendorVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<VendorVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<VendorVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<VendorVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddVendor(VendorVM vendor)

        {

            var Dto = Mapper.Map<VendorVM, Vendor>(vendor);

            Vendor Exist = await _db.Vendors.Where(x => x.Name.Trim() == vendor.Name.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Vendors.Add(Dto);

            int result = await _db.SaveChangesAsync();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent, result);
            }


        }

        public async Task<Response> RemoveVendor(VendorVM vendor)
        {
            try
            {
                var DTO = await _db.Vendors.Where(x => x.Id == vendor.Id).FirstOrDefaultAsync();

                _db.Vendors.Remove(DTO);

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
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }

        
    }
}
