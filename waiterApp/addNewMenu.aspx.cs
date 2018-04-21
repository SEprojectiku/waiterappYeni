using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace waiterApp
{
    public partial class addNewMenu : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);
            query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Session["bID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
            connection.Open();
            SqlDataReader dr = query.ExecuteReader();
            if (dr.Read())
            {
                myName.Text = dr["bName"].ToString();
                navbarname.Text = dr["bName"].ToString();

            }
            connection.Close();

        }
        ArrayList name = new ArrayList();
        insertions insert = new insertions();
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (string key in Request.Form.Keys)
            {
               
                if (key.Contains("name"))
                {
                    name.Add(Request.Form[key].ToString());
                }
                
                i++;

            }
            insert.insertnewMenu(1,name, i); // 1 yerine business Id gelecek
        }
    }
}