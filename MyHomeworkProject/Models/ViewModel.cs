using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomeworkProject.Models
{
    public class ViewModel
    {

        public IEnumerable<UserLink> UserLinkSet { set; get; }
        public IEnumerable< SelectListItem > AddLinkSet { get; set; }
      
    }
}