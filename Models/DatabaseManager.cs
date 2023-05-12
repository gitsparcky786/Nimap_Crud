using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD1.Models
{
    public class DatabaseManager
    {
        protected string MyCommandText;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd = new SqlCommand();
        public DatabaseManager()
        {
            cmd.Connection = con;
        }
        protected bool InsertedUpdatedOrDeleted()
        {
            cmd.CommandText = MyCommandText;
            if (con.State == ConnectionState.Closed)
                con.Open();
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count > 0 ? true : false;
        }
        protected DataTable GetQueriedData()
        {

            SqlDataAdapter da = new SqlDataAdapter(MyCommandText, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}