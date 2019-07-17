using ProTrukRepo.Interface;
using ProTrukRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProTrukWeb.Controllers
{
    public class RoleController : Controller
    {
        readonly ProTrukRepo.Interface.IRoleRepository roleRepository;
        public RoleController(IRoleRepository repository)
        {
            this.roleRepository = repository;
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetAllRoles()
        {
            Response r = await roleRepository.GetAllRoles();
            //List<> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r.Value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> AddRole(ProTrukRepo.ViewModels.RolesVM role)
        {
            Response r = await roleRepository.AddRole(role);
          //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveRole(ProTrukRepo.ViewModels.RolesVM role)
        {
            Response r = await roleRepository.RemoveRole(role);
            //  List<UserVM> employees = ((IEnumerable)r.Value).Cast<UserVM>().ToList(); ;
            return Json(r, JsonRequestBehavior.AllowGet);
        }

        

    }
}