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

namespace ProTrukRepo.Repository
{
public    class GoodsRepository : IGoodsRepository
    {

        private readonly ProTruckEntities _db;
        private Hashtable Units = new Hashtable();
        public GoodsRepository()
        {
            _db = new ProTruckEntities();

            Units[1] = "ton(s)";
            Units[2] = "Kgs";

        }

        public async Task<Response> GetALLGoods()
        {
            try
            {
                List<GoodsType> response = new List<GoodsType>();
                //var users =  _db.Users.Select(x => x).ToList();
                 response = await _db.GoodsTypes.ToListAsync();
                //   Mapper.Initialize(cfg => cfg.CreateMap<User, UserVM>());
                
                if (response.Count() > 0)
                {
                    return GenericResponses<IEnumerable<GoodsType>>.ResponseStatus(false, response.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, response);
                }
                else
                {
                    return GenericResponses<IEnumerable<GoodsType>>.ResponseStatus(false, Constant.MDGNoRecordFound, (int)Constant.httpStatus.NoContent, response.ToList());
                }
            }
            catch (Exception e)
            {
                return GenericResponses<GoodsType>.ResponseStatus(true);
            }
        }

        public async Task<Response> AddGood(GoodsType goods)
        {

           

            GoodsType goodsExist = await _db.GoodsTypes.Where(x => x.Goods.Trim() == goods.Goods.Trim()).FirstOrDefaultAsync();
            if (goodsExist != null)
            {
                return GenericResponses<int>.ResponseStatus(true, Constant.MDGNoAlreadyExist, (int)Constant.httpStatus.NoContent, 0);
            }

            _db.GoodsTypes.Add(goods);

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

        public async Task<Response> RemoveGood(GoodsType goods)
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

            List<DropDownListModel> Lst = new List<DropDownListModel>();
            foreach (DictionaryEntry entry in Units)
            {
                DropDownListModel obj = new DropDownListModel();
                obj.Value = (int)entry.Key;
                obj.Text = entry.Value.ToString();
                Lst.Add(obj);
                // Console.WriteLine("{0}, {1}", entry.Key, entry.Value);
            }

            return GenericResponses<List<DropDownListModel>>.ResponseStatus(false, Lst.Count() + Constant.MSGRecordFound, (int)Constant.httpStatus.Ok, Lst);
        }


    }
}
