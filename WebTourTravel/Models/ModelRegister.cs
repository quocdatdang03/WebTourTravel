using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebTourTravel.Models
{
    public class ModelRegister
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord{ get; set; }

        [Required]
        public string ComfirmPassWorld { get; set; }

        [Required]
        public string Email{ get; set; }


        public ModelRegister() { }

        public ModelRegister(string username , string passworld ,string passComfirm, string email)
        {
            this.UserName = username;
            this.PassWord = passworld;
            this.Email = email;
            this.PassWord = passComfirm;
        }




}
}