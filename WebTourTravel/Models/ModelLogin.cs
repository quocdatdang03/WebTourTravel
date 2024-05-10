using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTourTravel.Models
{
    public class ModelLogin
    {
        [Required()]
        public string UserName { get; set; }
        [Required]
        public string PassWorld { get; set; }


        public ModelLogin() { }
        public ModelLogin(string username , string passworld)
        {
            this.UserName = username;
            this.PassWorld = passworld;
           
        }
    }
}