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
    {  string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
    fillDropDown filldropdownlist = new fillDropDown();
    PagedDataSource pagesource;
        protected void Page_Load(object sender, EventArgs e)
        {
            fill();
        }
        private void fill()
        {
            DataSet ds = filldropdownlist.listAlltables(1); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
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