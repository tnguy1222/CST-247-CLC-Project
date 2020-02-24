using CST247_CLCProject.Models;
using CST247_CLCProject.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST247_CLCProject.Controllers
{
    public class LoginController : Controller
    {
        static Game game = new Game();
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(CredentialModel credential)
        {

            //Call the Security Business Service authenticate method from the Login() method
            
            SecurityService securityService = new SecurityService();
          
            // If satetement check for data validation
            if (ModelState.IsValid)
            {
                // the results of the method call is saved in local method sucess
                Boolean success = securityService.authenticate(credential);

                if (success)
                {
                    //if the success variable returns true, navigate to LoginSuccess View
                    return View("LoginSuccess");

                }
                else
                {
                    //if the success variable returns false, navigate to LoginFailed View
                    return View("LoginFailed");
                }
            }
            else
            {
                return View("Login");
            }
            
        }


    }
}