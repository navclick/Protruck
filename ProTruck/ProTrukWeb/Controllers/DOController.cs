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

            
            Response resultUnits = _repogoods.GetallUnits();

            List<DropDownListModel> listunits = ((IEnumerable)resultUnits.Value).Cast<DropDownListModel>().ToList();

            var selectListUnits = listunits.Select(x => new SelectListItem() { Value = x.Value.ToString(), Text = x.Text }).ToList();
            ViewBag.LstUnits = selectListUnits;

            ISettingRepository _setting = new SettingRepository();
            DorderVM Do = new DorderVM();
            bool autoInc = _setting.GetDoAutoIncrement();
            if (autoInc)
            {

                Do.DoNumber = (_setting.GetLastDoNumber() + 1);
            }
            else
            {
                Do.DoNumber = _setting.GetLastDoNumber();


            }

            Do.ContractNumber = _setting.GetLastContractNumber();

            ViewBag.isAutoIncrement = autoInc;
            Do.BagsPerWeight = _setting.GetPackPerWeight();
            return View(Do);
        }

        
        [HttpPost]
        public async Task<ActionResult> AddDo(DorderVM dorder, FormCollection frm)
        {
             

            int saveCopy = Convert.ToInt32( frm["SaveCopy"]);
            decimal lastDoNumber = 0;
            decimal lastContractNumber = 0;
            double totalQty = 0;
            int party =(int) dorder.Party;
            if (saveCopy == 1)
            {
                dorder.EcomID = (int)Session["Comp"];
                dorder.CreatedOn = DateTime.Today;
                lastDoNumber = (decimal) dorder.DoNumber;
                lastContractNumber = (decimal) dorder.ContractNumber;
                Response reslut = await _Repository.AddDo(dorder);
                totalQty =(double) dorder.Weight;
                if (!reslut.IsError)
                {


                    ISettingRepository _setting = new SettingRepository();
                    _setting.UpdateDoAutoIncrement(dorder.autoincrement);
                    _setting.UpdateLastContractNumber((decimal)dorder.ContractNumber);
                    _setting.UpdateLastDoNumber((lastDoNumber + 1));


                    IContractRespository _contract = new ContractRepository();
                    ContractVM contract = new ContractVM();
                    contract.Party = party;
                    contract.PartyName = dorder.PartyName;
                    contract.TotatQty = totalQty;
                    contract.Unit = dorder.Unit;
                    contract.EcomID = (int)Session["Comp"];
                    contract.CreatedOn = DateTime.Today;
                    contract.ContractType = dorder.ContractType;
                    contract.ContractNo = dorder.ContractNumber;
                    if (_contract.isInsertable(contract))
                    {
                        await _contract.AddContract(contract);
                    }
                    else {
                        await _contract.UpdateContractQty(contract);

                    }

                    IAddressHistoryRepository _addresHistory = new AddressHistoryRepository();
                    AdressHistory addressHistory = new AdressHistory();

                    addressHistory.Party = dorder.Party;
                    addressHistory.EnglisgAddress = dorder.AddressEng;
                    addressHistory.UrduAddress = dorder.AddressUrd;

                    if (_addresHistory.isInsertable((int)addressHistory.Party))
                    {
                        _addresHistory.AddAddressHistory(addressHistory);

                    }

                    else {
                        _addresHistory.updqateAddressHistory(addressHistory);
                    }
                }


                

            }

            else
            {
                lastDoNumber = (decimal)dorder.DoNumber;
                for (int i = 0; i < saveCopy; i++)
                {

                    dorder.EcomID = (int)Session["Comp"];
                    dorder.CreatedOn = DateTime.Today;
                    dorder.DoNumber = lastDoNumber;
                    lastContractNumber = (decimal)dorder.ContractNumber;
                    Response reslutloop = await _Repository.AddDo(dorder);
                    totalQty = totalQty +(double) dorder.Weight;
                    lastDoNumber++;
                }

                ISettingRepository _setting = new SettingRepository();
                _setting.UpdateDoAutoIncrement(dorder.autoincrement);
                _setting.UpdateLastContractNumber((decimal)dorder.ContractNumber);
                _setting.UpdateLastDoNumber((lastDoNumber));

                IContractRespository _contract = new ContractRepository();
                ContractVM contract = new ContractVM();
                contract.Party = party;
                contract.PartyName = dorder.PartyName;
                contract.TotatQty = totalQty;
                contract.Unit = dorder.Unit;
                contract.EcomID = (int)Session["Comp"];
                contract.CreatedOn = DateTime.Today;
                contract.ContractType = dorder.ContractType;
                contract.ContractNo = dorder.ContractNumber;

                if (_contract.isInsertable(contract))
                {
                    await _contract.AddContract(contract);
                }
                else
                {
                    await _contract.UpdateContractQty(contract);

                }

                IAddressHistoryRepository _addresHistory = new AddressHistoryRepository();
                AdressHistory addressHistory = new AdressHistory();

                addressHistory.Party = dorder.Party;
                addressHistory.EnglisgAddress = dorder.AddressEng;
                addressHistory.UrduAddress = dorder.AddressUrd;

                if (_addresHistory.isInsertable((int)addressHistory.Party))
                {
                    _addresHistory.AddAddressHistory(addressHistory);

                }

                else
                {
                    _addresHistory.updqateAddressHistory(addressHistory);
                }

            }

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetPartyAddressHistory(int party)
        {


            IAddressHistoryRepository _addressrepo = new AddressHistoryRepository();

            
            Response result = await _addressrepo.GetAddressHistory(party);
            return Json(result, JsonRequestBehavior.AllowGet);
            /*
            if (result.IsError == false)
            {
                AdressHistoryVM Obj = (AdressHistoryVM)result.Value;
                return Json(Obj, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(result.Message, JsonRequestBehavior.AllowGet);
            }

            */
        }


        [HttpGet]
        public async Task<JsonResult> GetDoJson(decimal donumber)
        {
            Response r = await _Repository.GetDo(donumber);

            return Json(r, JsonRequestBehavior.AllowGet);
        }

    }
}