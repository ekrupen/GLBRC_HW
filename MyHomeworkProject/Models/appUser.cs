using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyHomeworkProject.Models
{
    public class appUser
    {
        [Display(Name = "Your Name")]
        [MaxLength(50)]
        public string userName { set; get; }
        public appUser()
        {
            userName = "Anonymous";
        }
    }
}