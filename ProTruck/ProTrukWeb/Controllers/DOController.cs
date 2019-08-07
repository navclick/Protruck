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
        public async Task<ActionResult> AddDo()
        {
            IContractTypeRepository _repo = new ContractTypeRepository();
            Response result = await _repo.GetallContractTrypes();
            List<ContractTypeVM> list = ((IEnumerable)result.Value).Cast<ContractTypeVM>().ToList();
            var selectListItems = list.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Type }).ToList();
            ViewBag.LstContractType = selectListItems;


            ICityRepository _repocity = new CityRepository();
            Response resultcity = await _repocity.GetALLCities();
            List<CityVM> listcity = ((IEnumerable)resultcity.Value).Cast<CityVM>().ToList();
            var selectListItemscity = listcity.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.City1 }).ToList();
            ViewBag.LstCities = selectListItemscity;


            IPartyRepository _repoparty = new PartyRepository();
            Response resultparty = await _repoparty.GetALLParties();
            List<PartyVM> listparty = ((IEnumerable)resultparty.Value).Cast<PartyVM>().ToList();
            var selectListItemsparty = listparty.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Party1 }).ToList();
            ViewBag.LstParty = selectListItemsparty;


            IGoodsRepository _repogoods = new GoodsRepository();
            Response resultgoods = await _repogoods.GetALLGoods();
            List<GoodsTypeVM> listgoods = ((IEnumerable)resultgoods.Value).Cast<GoodsTypeVM>().ToList();
            var selectListItemsgoods = listgoods.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Goods }).ToList();
            ViewBag.LstGoods = selectListItemsgoods;

            ISettingRepository _setting = new SettingRepository();
            DorderVM Do = new DorderVM();
            bool autoInc = _setting.GetDoAutoIncrement();
            if (autoInc)
            {

                Do.DoNumber = (_setting.GetLastDoNumber() + 1);
            }
            else {
                Do.DoNumber = _setting.GetLastDoNumber();


            }

            Do.ContractNumber = _setting.GetLastContractNumber();

            ViewBag.isAutoIncrement = autoInc;
            return View(Do);
        }
    }
}