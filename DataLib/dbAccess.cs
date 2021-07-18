using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLib
{
    public static class dbAccess
    {
        public static string GetConnectionString(String connectionName = "MVC_Database")
        {
            return
                ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

        }

        /// this function will return list of Likns for given user   
        public static List<Model.Link> LoadLinks(int userId)
        {
            string sql = "stp_getLinksByUserId";
            List<Model.Link> LinkList = new List<Model.Link>();
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                      

                        conn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            // iterate through results, printing each to console
                            while (rdr.Read())
                            {

                                Model.Link lk = new Model.Link();
                                lk.linkId = Convert.ToInt32(rdr["LinkId"]);
                                lk.LinkName = rdr["LinkName"].ToString();
                                lk.LinkURL = rdr["LinkURL"].ToString();
                                lk.isDefault = Convert.ToBoolean(rdr["isDefault"]);
                                LinkList.Add(lk);

                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                string mg = ex.Message;
            }
            return LinkList;
        }

        // this function add or delet Link for given user
        public static bool changeLinkForUser(int userId, int LinkId, string sql)
        {
            // string sql = "stp_DeleteLinkForUser";
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("LinkId", SqlDbType.Int).Value = LinkId;
                        cmd.Parameters.Add("PersonId", SqlDbType.Int).Value = userId;



                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }


        }

        public static int getUserId(string userName)
        {
            int  UserId = 0;
            string sql = "stp_getUserIdByUserName";
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    cmd.Parameters["@UserName"].Value = userName;


                    conn.Open();
                    UserId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return UserId;
        }
    }
}
