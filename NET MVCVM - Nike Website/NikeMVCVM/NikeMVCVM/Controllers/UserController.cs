using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nike.Business.ViewModels;
using Nike.Business.BusinessLogic;


namespace NikeMVCVM.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            var list = UserBL.displayUserList();
            return View(list);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVm)
        {
            Boolean success = true;
            success =  UserBL.CheckLoginCredentials(loginVm);
            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM registerVm)
        {
            if (UserBL.registerUser(registerVm)) 
            {

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

   
    }
}
