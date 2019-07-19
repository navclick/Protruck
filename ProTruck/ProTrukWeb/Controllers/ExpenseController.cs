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
    public class ExpenseController : Controller
    {
        readonly ProTrukRepo.Interface.IExpenseRepository Repository;
        public ExpenseController(IExpenseRepository repository)
        {
            this.Repository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetALLExpenses()
        {
            Response r = await Repository.GetALLExpenses();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddExpense(ExpenseVM expense)
        {
            expense.EcomID =(int) Session["Comp"];

            Response r = await Repository.AddExpense(expense);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public async Task<JsonResult> RemoveExpense(ExpenseVM expense)
        {
            Response r = await Repository.RemoveExpense(expense);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetallExpenseTypes()
        {
            Response r = Repository.GetallExpenseTypes();
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }

    }
}