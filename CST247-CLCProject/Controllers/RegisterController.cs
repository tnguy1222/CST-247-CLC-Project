using CST247_CLCProject.Models;
using CST247_CLCProject.Models.Business;
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
            //Call the Security Business Service create and findUserByEmail method from the Register() method
            SecurityService securityService = new SecurityService();

            // If satetement check for data validation
            if (ModelState.IsValid)
            { 
                // the results of findByUserByEmail method call is saved in local method exist
                Boolean exist = securityService.findUserByEmail(user);
                if (!exist)
                {
                    // the results of create method call is saved in local method sucess
                    Boolean success = securityService.create(user);

                    if (success)
                    {
                        //if the success variable returns true, navigate to RegisterSuccess View
                        return View("RegisterSuccess") ;
                    }
                    else
                    {
                        //if the success variable returns true, navigate to RegisterFailed View
                        return View("RegisterFailed");
                    }
                }
                else
                {
                    //if the exist variable returns true, navigate to RegisterExisted View
                    return View("RegisterExisted");
                }
            }
            return View("Register");
        }
    }
}