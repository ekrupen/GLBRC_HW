using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Buisnesslogic
{
  public static class LinkProcessor
    {
        /*  public static void GetLinkList(string PersonName)
          {
              Model.Link data = new Model.Link();
              return 
          } */

        public static bool DeleteLink(int userId, int LinkId)
        {
            string sql = "stp_DeleteLinkForUser";
           return dbAccess.changeLinkForUser(userId, LinkId, sql);
        }

        public static bool AddLink(int userId, int LinkId)
        {
            string sql = "stp_AddLinkForUser";
            return dbAccess.changeLinkForUser(userId, LinkId, sql);
        }
        public static List<Model.Link> getLinks(int  userId   )
        {
         
            return dbAccess.LoadLinks(userId);
        }

        public static int getUserId(string userName)
        {
            
            return dbAccess.getUserId(userName);
        }
    }
}
