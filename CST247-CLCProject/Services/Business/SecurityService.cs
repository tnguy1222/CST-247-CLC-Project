using CST247_CLCProject.Models;
using CST247_CLCProject.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Models.Business
{
    public class SecurityService
    {
        // findUserByEmail method calls findUserByEmail in SecurityDAO
        public bool findUserByEmail(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.findUserByEmail(user);
        }

        // create method calls create in SecurityDAO
        public bool create(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.create(user);

        }

        // authenticate method calls authenticate in SecurityDAO
        public bool authenticate(CredentialModel credential)
        {
            SecurityDAO service = new SecurityDAO();
            return service.authenticate(credential);
        }
    }
}