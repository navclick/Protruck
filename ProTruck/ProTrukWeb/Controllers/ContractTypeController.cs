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
    public class ContractTypeController : Controller
    {
        readonly ProTrukRepo.Interface.IContractTypeRepository Repository;
        public ContractTypeController(IContractTypeRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetallContractTrypes()
        {
            Response r = await Repository.GetallContractTrypes();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddContractType(ContractTypeVM contracttype)
        {
            contracttype.CreatedOn = DateTime.Today;
            contracttype.EcomID =(int) Session["Comp"];

            Response r = await Repository.AddContractType(contracttype);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveContractType(ContractTypeVM contracttype)
        {
            Response r = await Repository.RemoveContractType(contracttype);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }
    }
}