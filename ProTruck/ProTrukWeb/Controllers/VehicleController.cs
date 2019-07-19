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
    public class VehicleController : Controller
    {
        readonly ProTrukRepo.Interface.IVehicleRepository Repository;
        public VehicleController(IVehicleRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetallVehicles()
        {
            Response r = await Repository.GetallVehicles();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddVehicle(VehicleVM vehicle)
        {
            vehicle.CreatedOn = DateTime.Today;
            vehicle.EcomID = (int)Session["Comp"];
            Response r = await Repository.AddVehicle(vehicle);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }


       

        [HttpPost]
        public async Task<JsonResult> RemoveVehicle(VehicleVM  vehicle)
        {
            vehicle.EcomID =(int) Session["Comp"];
            vehicle.CreatedOn = DateTime.Today;
            Response r = await Repository.RemoveVehicle(vehicle);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getUnits()
        {
            Response r = Repository.GetallUnits();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getallVehicleType()
        {
            Response r = Repository.GetallVehicleType();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getallVehicleStatus()
        {
            Response r = Repository.GetallVehicleStatus();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetallSelectListVehicles()
        {
            Response r = Repository.GetallSelectListVehicles();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }

        
    }
}