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
    public class DriverController : Controller
    {
        readonly ProTrukRepo.Interface.IDriversRepository Repository;
        public DriverController(IDriversRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetallDrivers()
        {
            Response r = await Repository.GetallDrivers();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddDriver(DriverVM driver)
        {
            driver.CreatedOn = DateTime.Today;
            driver.EcomID = (int)Session["Comp"];
            Response r = await Repository.AddDriver(driver);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveDriver(DriverVM driver)
        {
            Response r = await Repository.RemoveDriver(driver);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetDriverByVehicle(int vehicleId)
        {
            Response r = await Repository.GetDriverByVehicle(vehicleId);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        

    }
}