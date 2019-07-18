using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Util;
using ProTrukRepo.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb.Controllers
{
    public class GoodsController : Controller
    {
        readonly ProTrukRepo.Interface.IGoodsRepository goodsRepository;
        public GoodsController(IGoodsRepository repository)
        {
            this.goodsRepository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllGoods()
        {
            Response r = await goodsRepository.GetALLGoods();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddGoods(GoodsTypeVM good)
        {
            Response r = await goodsRepository.AddGood(good);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getUnits()
        {
             Response r = goodsRepository.GetallUnits();
                  return Json(r.Value, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveGoods(GoodsTypeVM good)
        {
            Response r = await goodsRepository.RemoveGood(good);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



    }
}