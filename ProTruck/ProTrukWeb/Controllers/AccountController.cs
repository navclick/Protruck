using ProTrukRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProTrukRepo.ViewModels;
using ProTrukRepo.Model;
using System.Web.Script.Serialization;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

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
        public async Task<ActionResult> Index()
        {
           
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Login()
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
                UserVM dbUser = (UserVM)response.Value;
                Session["UserID"] = dbUser.Id.ToString();
                Session["FullName"] = dbUser.FullName;
                Session["Picture"] = dbUser.Picture;
                Session["RoleID"] = dbUser.RoleID;
                Session["Comp"] = dbUser.EcomID;
                var json = new JavaScriptSerializer().Serialize(responseModules.Value);
                Session["Modules"] = json;

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public async Task<JsonResult>  GetAllUsers()
        {
            Response r = await userRepository.GetAllUsers();
            List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public async Task<ActionResult> Adduser()
        {
            Response result = await userRepository.GetAllRoles();
            List<RolesVM> list = ((IEnumerable)result.Value).Cast<RolesVM>().ToList();
            var selectListItems = list.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Role1 }).ToList();
            ViewBag.roles = selectListItems;
            return View();
        }
        [HttpPost]
        public ActionResult Adduser(UserVM user, HttpPostedFileBase file)
        {
            user.AccountStatus = 1;
            user.CreatedOn = DateTime.Today.ToShortDateString();
            user.EcomID = (int)Session["Comp"];
            if (file != null && file.ContentLength > 0)
            {

                try
                {
                    string path = Path.Combine(Server.MapPath("~" + ProTrukRepo.Util.Constant.PathUserImage),
                                               Path.GetFileName(Session["UserID"] + file.FileName));
                    file.SaveAs(path);

                    user.Picture = ProTrukRepo.Util.Constant.PathUserImage + Session["UserID"] + file.FileName;
                    userRepository.Adduser(user);


                }
                catch (Exception ex)
                {
                    
                }



            }
            else {
                user.Picture = ProTrukRepo.Util.Constant.PathUserDefultImage;
                userRepository.Adduser(user);
            }

            return RedirectToAction("Index", "Account");
        }

    }
    }