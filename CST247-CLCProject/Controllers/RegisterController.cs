using CST247_CLCProject.Models;
using CST247_CLCProject.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST247_CLCProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.create(user);

            if (success)
            {
                return View("LoginSuccess");
            }
            else
            {
                return View("LoginFailed");
            }

        }
    }
}