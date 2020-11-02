using Hff.Business.Abstract;
using Hff.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hff.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var admin = _adminService.GetList(p=>p.UserName==model.UserName&&p.Password==model.Password).FirstOrDefault();
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["UserName"] = admin.UserName; 
                return RedirectToAction("Index", "Statistics");
            }
            return PartialView();
        }
    }
}