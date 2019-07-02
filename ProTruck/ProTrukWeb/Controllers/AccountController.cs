using ProTrukRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProTrukRepo.ViewModels;
using ProTrukRepo.Model;
using System.Web.Script.Serialization;

namespace ProTrukWeb.Controllers
{
    public class AccountController : Controller
    {

        readonly ProTrukRepo.Interface.IUserMasterRepository userRepository;
        public AccountController(IUserMasterRepository repository)
        {
            this.userRepository = repository;
        }
        // GET: Account

        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            ProTrukRepo.Model.Response response = userRepository.ValidateUser(user);

            ProTrukRepo.Model.Response responseModules = userRepository.GetModules();
            if (response.IsError)
            {
                ViewBag.Msg = response.Message;
                return View();
            }
            else {
                UserVM dbUser =(UserVM) response.Value;
                Session["UserID"] = dbUser.Id.ToString();
                Session["FullName"] = dbUser.FullName;
                Session["Picture"] = dbUser.Picture;
                Session["RoleID"] = dbUser.RoleID;
                var json= new JavaScriptSerializer().Serialize(responseModules.Value);
                Session["Modules"] = json;

                return RedirectToAction("Index","Home") ;
            }
            
        }
    }
}