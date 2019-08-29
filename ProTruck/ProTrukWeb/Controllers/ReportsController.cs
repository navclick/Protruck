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
using System.Threading.Tasks;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;

namespace ProTrukWeb.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        readonly ProTrukRepo.Interface.IVehicleRepository _repovehicel;
        public ReportsController(IVehicleRepository repository)
        {
            this._repovehicel = repository;
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
            model.Controller = "Reports";
            model.Action = "Bilty";




            return View(model);
        }

        [HttpPost]
        public async Task< ActionResult> Bilty(ReportSearchVM searchobj)
        {
            IBiltyRepository _repoBilty = new BiltyRepository();

           

            IDriversRepository _repodriver = new DriverRepository();


            Response resultbilty =await _repoBilty.GetAllBiltiesForReport(searchobj);



            List<Bilty> BiltiesLst = ((IEnumerable)resultbilty.Value).Cast<Bilty>().ToList(); ;

            DataSet ds = new DataSet();
            DataTable DT = new DataTable();

            DT.Columns.Add("BiltyNo");
            DT.Columns.Add("Vehicle");
            DT.Columns.Add("Driver");
            DT.Columns.Add("Party");
            DT.Columns.Add("Address");
            DT.Columns.Add("GoodsType");
            DT.Columns.Add("Weight");
            DT.Columns.Add("Qty");
            DT.Columns.Add("Dos");
            DT.Columns.Add("Rate");
            DT.Columns.Add("TotalAmount");
            DT.Columns.Add("PainAmount");
            DT.Columns.Add("RemainingAmount");
            DT.Columns.Add("Date");
            DT.Columns.Add("Sender");
            DT.Columns.Add("Billing");
            DT.TableName = "Bilty";
            ds.Tables.Add(DT);



            foreach (Bilty obj in BiltiesLst)
            {

                DataRow row = ds.Tables[0].NewRow();

                vehicle vehicel;
                DriverVM driver;
                Response resulvehicle = _repovehicel.GetVehicleById((int)obj.VehicleId);

                Response resulDos = await _repoBilty.GetDoByBilty(obj.BiltyNo);
                


                if (!resulvehicle.IsError)
                {

                    vehicel = (vehicle)resulvehicle.Value;

                    row["Vehicle"] = vehicel.RegNumber;


                    Response resultdriver = await _repodriver.GetDriverByVehicle(vehicel.Id);
                    driver = (DriverVM)resultdriver.Value;
                    row["Driver"] = driver.Name;


                }
                else {
                    row["Vehicle"] = "NA";
                    row["Driver"] = "NA";
                }
                row["BiltyNo"] = obj.BiltyNo.ToString();


                row["Party"] = obj.Party.Party1.ToString();
                
                row["Address"] = obj.Address.ToString();
                row["GoodsType"] = obj.GoodsType.Goods.ToString();
                row["Weight"] = obj.Weight.ToString();
                row["Qty"] = obj.Qty.ToString();
               
                row["Rate"] = obj.Rate.ToString();
                row["TotalAmount"] = obj.TotalAmount.ToString();
                row["PainAmount"] = obj.PaidAmount.ToString();
                row["Date"] = Convert.ToDateTime(obj.BiltyDate).ToString("dd-MMM-yyyy");
                row["Sender"] = obj.PaidAmount.ToString();



                row["Billing"] = "";

                List<BiltyToDo> lstDos = ((IEnumerable)resulDos.Value).Cast<BiltyToDo>().ToList(); 


                string r = "";
                foreach (var i in lstDos)
                {


                    r = r + "  " + i.Donumber.ToString();
                }

                row["Dos"] = r;

                ds.Tables[0].Rows.Add(row);



            }

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            // reportViewer.Width = Unit.Percentage(900);
            //reportViewer.Height = Unit.Percentage(900);

            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\BiltyReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("reportdata_bilty", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;


            return View("ReportView");
        }
        }
    }