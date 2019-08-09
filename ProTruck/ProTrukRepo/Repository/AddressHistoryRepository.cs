using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;

namespace ProTrukRepo.Repository
{
 public   class AddressHistoryRepository : IAddressHistoryRepository
    {
        private readonly ProTruckEntities _db;
        public AddressHistoryRepository()
        {
            _db = new ProTruckEntities();

           

        }



        public bool isInsertable(int party)
        {
            try
            {

                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = _db.AdressHistories.Where(x => x.Party == party).ToList();

                if (DTO.Count < 1)
                {

                    return true;
                }

                else { return false; }
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool AddAddressHistory(AdressHistory address) {

            _db.AdressHistories.Add(address);
            int Result = _db.SaveChanges();

            if (Result == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }


        public bool updqateAddressHistory(AdressHistory address)
        {
            AdressHistory DTO = _db.AdressHistories.Where(m => m.Party == address.Party).FirstOrDefault();

            DTO.EnglisgAddress = address.EnglisgAddress;
            DTO.UrduAddress = address.UrduAddress;

            int Result = _db.SaveChanges();

            if (Result == 1)
            {

                return true;
            }
            else
            {

                return false;
            }
        }

        public async Task<Response> GetAddressHistory(int party)
        {
            try
            {
                AdressHistory DTO = await _db.AdressHistories.Where(x => x.Party == party).FirstOrDefaultAsync();
                AdressHistoryVM address = new AdressHistoryVM();
                if (DTO != null)
                {
                    address.EnglisgAddress = DTO.EnglisgAddress;
                    address.UrduAddress = DTO.UrduAddress;

                    return GenericResponses<AdressHistoryVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, address);
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


    }
}
