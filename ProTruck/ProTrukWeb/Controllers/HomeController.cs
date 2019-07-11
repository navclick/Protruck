using ProTrukRepo.Interface;
using ProTrukWeb.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb.Controllers
{
   
    public class HomeController : Controller

    {
        readonly ProTrukRepo.Interface.IUserMasterRepository userRepository;
        public HomeController(IUserMasterRepository repository)
        {
            this.userRepository = repository;
        }

       [UserAuthenticationFilter]
        public ActionResult Index()
        {
           //ProTrukRepo.Model.Response Result = userRepository.GetAllUsers();
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}