using ProTrukRepo.Interface;
using ProTrukRepo.Model;
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
    public class ContractController : Controller
    {

        readonly ProTrukRepo.Interface.IContractRespository Repository;
        public ContractController(IContractRespository repository)
        {
            this.Repository = repository;
        }
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> ContactNumberAutoComplete()
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();


           Response result=  await   Repository.GetallContacts();
            
            List<ContractVM> lst = ((IEnumerable)result.Value).Cast<ContractVM>().ToList();
            if (result.IsError == false) {

                foreach (var t in lst) {

                    dict.Add(t.ContractNo.ToString(), null);

                }
            }


            return Json(dict, JsonRequestBehavior.AllowGet);
        }

    }
}