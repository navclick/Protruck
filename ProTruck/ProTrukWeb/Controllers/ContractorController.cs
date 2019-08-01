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
    public class ContractorController : Controller
    {
        // GET: Contractor
        readonly ProTrukRepo.Interface.IContractorRepository Repository;
        public ContractorController(IContractorRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetallContactors()
        {
            Response r = await Repository.GetallContactors();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddContractor(ContractorVM contractor)
        {
            contractor.EcomID = (int)Session["Comp"];

            Response r = await Repository.AddContractor(contractor);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveContractor(ContractorVM contractor)
        {
            Response r = await Repository.RemoveContractor(contractor);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetallSelectListContractors()
        {
            Response r = Repository.GetallSelectListContractors();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
    }
}