using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Repository;
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
    public class BiltyController : Controller
    {
        readonly ProTrukRepo.Interface.IBiltyRepository Repository;
        public BiltyController(IBiltyRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Bilty
        public async Task<ActionResult> Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<JsonResult> GetAllBilties()
        {
            Response r = await Repository.GetAllBilties();

            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        

             public async Task<ActionResult> AddBilty()
        {
            IVehicleRepository vehiclerepo = new VehicleRepository();
            Response vehcleresult = vehiclerepo.GetallSelectListVehicles();


            List<DropDownListModel> list = ((IEnumerable)vehcleresult.Value).Cast<DropDownListModel>().ToList();
            var selectListItemsvehcle = list.Select(x => new SelectListItem() { Value = x.Value.ToString(), Text = x.Text }).ToList();
            ViewBag.vehcles = selectListItemsvehcle;

            IDriversRepository driverrepo = new DriverRepository();

            Response driverresult = await driverrepo.GetallDrivers();

            List<DriverVM> listDrivers = ((IEnumerable)driverresult.Value).Cast<DriverVM>().ToList();
            var selectListItemsDrivers = listDrivers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
            ViewBag.Drivers = selectListItemsDrivers;


            IPartyRepository partyrepo = new PartyRepository();

            Response partyresult = await partyrepo.GetALLSenderParties();

            List<PartyVM> listparties = ((IEnumerable)partyresult.Value).Cast<PartyVM>().ToList();
            var selectListItemsParties = listparties.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Party1 }).ToList();
            ViewBag.Parties = selectListItemsParties;
            BiltyVM bilty = new BiltyVM();
            bilty.Rate = 0;
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return View(bilty);
        }

        [HttpPost]
        public async Task<ActionResult> AddBilty(BiltyVM bilty, FormCollection frm)
        {
            bilty.CreateDate = DateTime.Today;
            string[] tokens = frm["selectDos"].Split(',');
            decimal[] Dos = Array.ConvertAll<string, decimal>(tokens, decimal.Parse);
            Response Result = await Repository.AddBilty(bilty, Dos);


            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<JsonResult> RemoveBilty(BiltyVM bilty)
        {
            Response r = await Repository.RemoveBilty(bilty);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}