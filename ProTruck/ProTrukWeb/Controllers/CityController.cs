using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb.Controllers
{
    public class CityController : Controller
    {
        readonly ProTrukRepo.Interface.ICityRepository Repository;
        public CityController(ICityRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetALLCities()
        {
            Response r = await Repository.GetALLCities();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddCity(CityVM city)
        {
            city.EcomID = (int)Session["Comp"];
            city.CreatedOn = DateTime.Today;
            Response r = await Repository.AddCity(city);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveCityy(CityVM city)
        {
            Response r = await Repository.RemoveCity(city);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCitiesSelectList()
        {
            Response r = Repository.GetCitiesSelectList();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
    }
}