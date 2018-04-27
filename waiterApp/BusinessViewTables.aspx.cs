using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace waiterApp
{
  
    public partial class BusinessViewTables : System.Web.UI.Page
    { static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown filldropdownlist = new fillDropDown();
    PagedDataSource pagesource;
        protected void Page_Load(object sender, EventArgs e)
        {
            fill();

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
        private void fill()
        {
            DataSet ds = filldropdownlist.listAlltables(Convert.ToInt32(Session["bID"].ToString())); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
            pagesource = new PagedDataSource();
            pagesource.DataSource = ds.Tables[0].DefaultView;
            pagesource.PageSize = 10;
            pagesource.AllowPaging = true;

            DataList1.DataSource = pagesource;
            DataList1.DataBind();
        }

        protected void setbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Button Button1 = (Button)sender;
            con.Open();
            SqlCommand update = new SqlCommand("update business.tableinfo set isAvailable='" + 0 + "' where tID = '" + Button1.CommandArgument + "'", con);
            update.ExecuteNonQuery();

            con.Close();

            fill();
        }

        protected void unsetbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Button Button1 = (Button)sender;
            con.Open();
            SqlCommand update = new SqlCommand("update business.tableinfo set isAvailable='" + 1 + "' where tID = '" + Button1.CommandArgument + "'", con);
            update.ExecuteNonQuery();

            con.Close();

            fill();
        }
    }
}