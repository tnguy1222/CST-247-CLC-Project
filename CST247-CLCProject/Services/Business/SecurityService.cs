using CST247_CLCProject.Models;
using CST247_CLCProject.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Services.Business
{
    public class SecurityService
    {
        public bool create(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.create(user);

        }

        public bool authenticate(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.authenticate(user);
        }
    }
}