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
    public class PartiesController : Controller
    {
        readonly ProTrukRepo.Interface.IPartyRepository Repository;
        public PartiesController(IPartyRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetALLParties()
        {
            Response r = await Repository.GetALLParties();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddParty(PartyVM party)
        {
            party.EcomID = (int)Session["Comp"];
            party.CreatedOn = DateTime.Today;
            Response r = await Repository.AddParty(party);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveExpense(PartyVM party)
        {
            Response r = await Repository.RemoveParty(party);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }




    }
}