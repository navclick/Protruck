using AutoMapper;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;
using ProTrukRepo.Interface;

namespace ProTrukRepo.Repository 
{
   public  class BiltyRepository : IBiltyRepository
    {
        private readonly ProTruckEntities _db;
        public BiltyRepository()
        {
            _db = new ProTruckEntities();

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bilty, BiltyVM>().ForMember(dest => dest.GoodTypeName, opt => opt.MapFrom(src => src.GoodsType.Goods.Trim()))
                .ForMember(dest => dest.PartyName, opt => opt.MapFrom(src => src.Party.Party1.Trim()))
                 .ForMember(dest => dest.VehicleReg, opt => opt.MapFrom(src => src.vehicle.RegNumber.Trim()));
                 
                cfg.CreateMap<BiltyVM, Bilty>();


                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });
        }


        public async Task<Response> GetAllBiltiesForReport(ReportSearchVM search)
        {
            try
            {

                string qry = "select * from bilty";


                if (search.DateFrom != "" && search.DateFrom != null)
                {

                    qry = qry + " where BiltyDate <= '" + search.DateFrom + "' and BiltyDate >= '"+ search.DateFrom + "'" ;

                }

                if (search.FiledoneValue != "" && search.FiledoneValue != null)
                {
                    qry= qry + " and BiltyNo="+ search.FiledoneValue +"";

                }

                if (search.DropdownoneValue != "" && search.DropdownoneValue != null) {

                    qry = qry + " and PartyId=" + search.DropdownoneValue + "";


                }


                List<BiltyVM> response = new List<BiltyVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Bilties.SqlQuery(qry).ToListAsync();

                /*
                if (search.DateFrom != "" && search.DateFrom != null) {

                    DTO.Where(m => m.BiltyDate >= Convert.ToDateTime(search.DateFrom) && m.BiltyDate <= Convert.ToDateTime(search.DateTo));

                }
                */

                /*
                if (search.FiledoneValue != "" && search.FiledoneValue != null) {

                     DTO.Where(m => m.BiltyNo == Convert.ToDecimal(search.FiledoneValue));

                    }
                    */

                
                
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                //response = Mapper.Map<IEnumerable<Bilty>, List<BiltyVM>>(DTO);
                if (DTO.Count() > 0)
                {
                    return GenericResponses<IEnumerable<Bilty>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, DTO);
                }
                else
                {
                    return GenericResponses<IEnumerable<Bilty>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, DTO.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<DorderVM>.ResponseStatus(true);
            }
        }


        public async Task<Response> GetAllBilties()
        {
            try
            {
                List<BiltyVM> response = new List<BiltyVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                var DTO = await _db.Bilties.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());

                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<Bilty>, List<BiltyVM>>(DTO);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<BiltyVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<BiltyVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<DorderVM>.ResponseStatus(true);
            }
        }
        public async Task<Response> GetBilty(decimal biltynumber) {
                try
                {
                    var DTO = await _db.Bilties.Where(x => x.BiltyNo == biltynumber).FirstOrDefaultAsync();

                    if (DTO != null)
                    {
                        var Obj = Mapper.Map<Bilty, BiltyVM>(DTO);

                        return GenericResponses<BiltyVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Obj);
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


        public async Task<Response> AddBilty(BiltyVM bilty, decimal[] dos) {
            var Dto = Mapper.Map<BiltyVM, Bilty>(bilty);

           

            _db.Bilties.Add(Dto);

            int result = await _db.SaveChangesAsync();

            if (result == 1)
            {
                // Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());


                foreach (decimal donumber in dos)
                {

                    BiltyToDo biltyToDoObj = new BiltyToDo();
                    biltyToDoObj.Biltyno = Dto.BiltyNo;
                    biltyToDoObj.Donumber = donumber;
                    _db.BiltyToDos.Add(biltyToDoObj);
                    int resultDos = await _db.SaveChangesAsync();
                }



                return GenericResponses<int>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, result);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoLoginFailed, (int)Constant.httpStatus.NoContent, result);
            }


        }


        public async Task<Response> GetBiltyByDo(decimal donumber) {

            var DTOBiltyToDo = await _db.BiltyToDos.Where(x => x.Donumber == donumber).FirstOrDefaultAsync();


            var DTO = await _db.Bilties.Where(x => x.BiltyNo == DTOBiltyToDo.Biltyno).FirstOrDefaultAsync();

            if (DTO != null)
            {
                var Obj = Mapper.Map<Bilty, BiltyVM>(DTO);

                return GenericResponses<BiltyVM>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Obj);
            }
            else
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, 0);

            }


        }



        public async Task<Response> GetDoByBilty(decimal biltynumber) {
           
            var DTOBiltyToDo = await _db.BiltyToDos.Where(x => x.Biltyno == biltynumber).ToListAsync();

            if (DTOBiltyToDo != null)
            {

                return GenericResponses<IEnumerable<BiltyToDo>>.ResponseStatus(false, Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, DTOBiltyToDo);
            }
            else {

                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, 0);
            }


        }


        public async Task<Response> RemoveBilty(BiltyVM bilty)
        {
            var DTObilty = await _db.BiltyToDos.Where(x => x.Biltyno == bilty.BiltyNo).ToListAsync();
            int result = 0;

            foreach (BiltyToDo obj in DTObilty) {

                _db.BiltyToDos.Remove(obj);
                result = await _db.SaveChangesAsync();

            }


           

           
                try
                {
                    var DTO = await _db.Bilties.Where(x => x.BiltyNo == bilty.BiltyNo).FirstOrDefaultAsync();

                    _db.Bilties.Remove(DTO);

                    int resultbilty = await _db.SaveChangesAsync();

                    if (resultbilty == 1)
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

   

