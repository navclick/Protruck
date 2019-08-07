using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;
using System.Web;

namespace ProTrukRepo.Repository
{
 public   class SettingRepository : ISettingRepository
    {

        private readonly ProTruckEntities _db;
        public SettingRepository()
        {
            _db = new ProTruckEntities();

            if (IsInsertable()) {
                Setting setting = new Setting();

                setting.EcomID = (int) HttpContext.Current.Session["Comp"];
                setting.DoAutoincrement = false;
                setting.LastConractNumber = 0;
                setting.LastDoNumber = 0;
                setting.PackPerWeight = 20;
                _db.Settings.Add(setting);

                int result =  _db.SaveChanges();
                
            }


        }


        public async Task<Response> GetSetting()
        {
            try
            {
                var DTO = await _db.Settings.FirstOrDefaultAsync();

                if (DTO != null)
                {
                 

                    return GenericResponses<Setting>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, DTO);
                }
                else
                {
                    return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, 0);

                }


            }
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }



        public async Task<Response> AddSetting(Setting setting)
        {



            Setting Exist = await _db.Settings.FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, -1);
            }

            _db.Settings.Add(Exist);

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

        public async Task<Response> RemoveSetting(Setting setting)
        {
            try
            {
                var DTO = await _db.Settings.Where(x => x.Id == setting.Id).FirstOrDefaultAsync();

                _db.Settings.Remove(DTO);

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



        public async Task<Response> UpdateSetting(Setting setting)
        {
            try
            {
               _db.Settings.Add(setting);

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
            catch (Exception e)
            {
                return GenericResponses<int>.ResponseStatus(true, e.Message, (int)Constant.httpStatus.NoContent, 0);

            }
        }

        public bool IsInsertable() {

            var settings =  _db.Settings.ToList();
            if (settings.Count > 0)
            {
                return false;

            }
            else {
                return true;
            }
        }

        public bool UpdateDoAutoIncrement(bool increment) {
            Setting DTO =  _db.Settings.FirstOrDefault();

            DTO.DoAutoincrement = increment;
            

            int result =  _db.SaveChanges();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return true;
            }
            else
            {
                return false;
            }

        }


        public bool UpdateLastDoNumber(decimal LastDoNumber) {
            Setting DTO = _db.Settings.FirstOrDefault();

            DTO.LastDoNumber = LastDoNumber;


            int result = _db.SaveChanges();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return true;
            }
            else
            {
                return false;
            }
        }




       public bool UpdateLastContractNumber(decimal LastContractNumber) {

            Setting DTO = _db.Settings.FirstOrDefault();

            DTO.LastConractNumber = LastContractNumber;


            int result = _db.SaveChanges();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool UpdatePackPerWeight(int pack) {
            Setting DTO = _db.Settings.FirstOrDefault();

            DTO.PackPerWeight = pack;


            int result = _db.SaveChanges();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                return true;
            }
            else
            {
                return false;
            }



        }

        public bool GetDoAutoIncrement()
        {
            Setting DTO = _db.Settings.FirstOrDefault();

            return (bool)DTO.DoAutoincrement ;

            

        }

        public decimal GetLastDoNumber()
        {
            Setting DTO = _db.Settings.FirstOrDefault();

            return (decimal) DTO.LastDoNumber;



        }

        public decimal GetLastContractNumber()
        {
            Setting DTO = _db.Settings.FirstOrDefault();

            return (decimal)DTO.LastConractNumber;

        }

        public int GetPackPerWeight()
        {
            Setting DTO = _db.Settings.FirstOrDefault();

            return (int)DTO.PackPerWeight;



        }
    }
}
