using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHomeworkProject.Models
{
    public class UserLink
    {

        public int linkId { set; get; }
        public string LinkName { set; get; }
        public string LinkURL { set; get; }
        public bool isDefault { set; get; }
    }
}