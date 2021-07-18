using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Model
{
  public  class Link
    {
        public  int linkId { set; get; }
        public string LinkName { set; get; }
        public string LinkURL { set; get; }
        public bool isDefault { set; get; }
    }
}
