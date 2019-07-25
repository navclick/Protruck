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
    public class DOController : Controller
    {
        readonly ProTrukRepo.Interface.IDoRepository _Repository;
        public DOController(IDoRepository repository)
        {
            this._Repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllDos()
        {
            Response r = await _Repository.GetAllDos();
            
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> RemoveDo(DorderVM dorder)
        {
            Response r = await _Repository.RemoveDo(dorder);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddDo()
        {
            return View();
        }
    }
}