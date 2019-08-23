using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using ProTrukRepo.Repository;
using ProTrukRepo.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Bilty()
        {

            ReportSearchVM model = new ReportSearchVM();

            model.DateFrom = DateTime.Today.ToShortDateString();
            model.DateTo = DateTime.Today.ToShortDateString();
            IPartyRepository _repo = new PartyRepository();
            model.DropdownoneEnable = true;
            model.DropdownoneLable = "Party";
            model.DropdownoneName="PartyID";

            Response result = _repo.GetallSelectListParties();

            List<DropDownListModel> lst = ((IEnumerable)result.Value).Cast<DropDownListModel>().ToList();
            model.DropdownoneList = lst;

            model.FiledoneEnable = true;
            model.FiledoneLabel = "Bilty#";
            model.FiledoneName = "BiltyNo";

            model.FiledtwoEnable = true;
            model.FiledtwoLabel = "Vehicle#";
            model.FiledtwoName = "Vehicle";





            return View(model);
        }
    }
}