using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Models
{
    //User Model class
    public class UserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Sex { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Age { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string State { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }

        

       
    }
}