using AutoMapper;
using ProTrukRepo.Model;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Interface;

namespace ProTrukRepo.Repository
{
   public class PartyRepository : IPartyRepository
    {

        private readonly ProTruckEntities _db;
        
        public PartyRepository()
        {
            _db = new ProTruckEntities();
          
            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Party, PartyVM>();
                cfg.CreateMap<PartyVM, Party>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });





        }

        
             public async Task<Response> GetALLSenderParties()
        {
            try
            {
                List<PartyVM> response = new List<PartyVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Parties.Where(x=> x.SenderOrReceiver.Trim()== "Sender").ToListAsync();
                foreach (var party in DTO)
                {
                    PartyVM obj = new PartyVM();
                    obj.ConectPerson = party.ConectPerson;
                    obj.CreatedOn = party.CreatedOn;
                    obj.EcomID = party.EcomID;
                    obj.Id = party.Id;
                    obj.IsSubParty = party.IsSubParty;
                    obj.ParentId = party.ParentId;
                    obj.Phone = party.Phone;
                    obj.Party1 = party.Party1;
                    if (party.ParentId != null && party.ParentId != 0)
                    {
                        obj.ParentPartyName = GetPartyById((int)party.ParentId).Party1;

                    }
                    response.Add(obj);
                }

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                // response = Mapper.Map<IEnumerable<Expense>, List<ExpenseVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<PartyVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<PartyVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<PartyVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> GetALLParties()
        {
            try
            {
                List<PartyVM> response = new List<PartyVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Parties.ToListAsync();
                foreach (var party in DTO)
                {
                    PartyVM obj = new PartyVM();
                    obj.ConectPerson = party.ConectPerson;
                    obj.CreatedOn = party.CreatedOn;
                    obj.EcomID = party.EcomID;
                    obj.Id = party.Id;
                    obj.IsSubParty = party.IsSubParty;
                    obj.ParentId = party.ParentId;
                    obj.Phone = party.Phone;
                    obj.Party1 = party.Party1;
                    if (party.ParentId != null && party.ParentId != 0)
                    {
                        obj.ParentPartyName = GetPartyById((int)party.ParentId).Party1;

                    }
                    response.Add(obj);
                }

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                // response = Mapper.Map<IEnumerable<Expense>, List<ExpenseVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<PartyVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<PartyVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<PartyVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddParty(PartyVM party)
        {

            var Dto = Mapper.Map<PartyVM, Party>(party);

            Party Exist = await _db.Parties.Where(x => x.Party1.Trim() == party.Party1.Trim()).FirstOrDefaultAsync();
            if (Exist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.Parties.Add(Dto);

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

        public async Task<Response> RemoveParty(PartyVM party)
        {
            try
            {
                var DTO = await _db.Parties.Where(x => x.Id == party.Id).FirstOrDefaultAsync();

                _db.Parties.Remove(DTO);

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

        public Response GetallSelectListParties()
        {
            var DTO = _db.Parties.ToList();
            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (var party in DTO)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)party.Id;
                obj.Text = party.Party1;
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }



        public  Party GetPartyById(int id)
        {

            

            Party Exist =  _db.Parties.Where(x => x.Id == id).FirstOrDefault();
            if (Exist != null)
            {
                return Exist;
            }
            else {

                return null;
            }
            

        }

    }
}
