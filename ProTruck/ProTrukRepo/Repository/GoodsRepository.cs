using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProTrukRepo.Util;
using System.Collections;
using ProTrukRepo.ViewModels;
using AutoMapper;

namespace ProTrukRepo.Repository
{
public    class GoodsRepository : IGoodsRepository
    {

        private readonly ProTruckEntities _db;
        private Hashtable Units = new Hashtable();
        private SharedRepository _shareRepo;
        public GoodsRepository()
        {
            _db = new ProTruckEntities();
            //------------------------------
            Units[1] = "ton(s)";
            Units[2] = "Kgs";
            //-------------------------

            AutoMapper.Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GoodsType, GoodsTypeVM>();
                cfg.CreateMap<GoodsTypeVM, GoodsType>();
                /* cfg.CreateMap<User, UserVM>().ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Role1.Trim())); ;
                 cfg.CreateMap<Module, ModuleVM>();
                 cfg.CreateMap<Role, RolesVM>();
                 cfg.CreateMap<UserVM, User>();
                 */
            });

            _shareRepo = new SharedRepository();
        }

        public async Task<Response> GetALLGoods()
        {
            try
            {
                List<GoodsTypeVM> response = new List<GoodsTypeVM>();
                //var users =  _db.Users.Select(x => x).ToList();
                 var goods = await _db.GoodsTypes.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                response = Mapper.Map<IEnumerable<GoodsType>, List<GoodsTypeVM>>(goods);
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<GoodsTypeVM>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<GoodsTypeVM>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<GoodsTypeVM>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddGood(GoodsTypeVM goods)
        {

            var goodsDto = Mapper.Map<GoodsTypeVM, GoodsType>(goods);

            GoodsType goodsExist = await _db.GoodsTypes.Where(x => x.Goods.Trim() == goods.Goods.Trim()).FirstOrDefaultAsync();
            if (goodsExist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.GoodsTypes.Add(goodsDto);

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

        public async Task<Response> RemoveGood(GoodsTypeVM goods)
        {
            try
            {
                var goodsDTO = await _db.GoodsTypes.Where(x => x.Id == goods.Id).FirstOrDefaultAsync();

                _db.GoodsTypes.Remove(goodsDTO);

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

        public Response GetallUnits()
        {

            return _shareRepo.GetallUnits();
        }


        
    }
}
