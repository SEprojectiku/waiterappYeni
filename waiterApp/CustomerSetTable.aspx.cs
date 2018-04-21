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
    public partial class CustomerSetTable : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        fillDropDown filldropdownlist = new fillDropDown();
        PagedDataSource pagesource;
        timedatecalculater tdc = new timedatecalculater();
            string date1, date2;
            int time;
        protected void Page_Load(object sender, EventArgs e)
        {
            fill();
        }

        protected void editbutton_Click(object sender, EventArgs e)
        {
            Button Button1 = (Button)sender;
            Session["tableID"] = Button1.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand update = new SqlCommand("update [business].[tableinfo] set isAvailable = 0 where tID = " + Button1.CommandArgument, con);
            update.ExecuteNonQuery();
        }

        private void fill()
        {

            string[] arr = tdc.datetimeNowformatterforDate();
            date1 = arr[0];
            date2 = arr[1];
            time = tdc.datetimeNowformatterforTime();

            DataSet ds = filldropdownlist.listSetteableTables(1, date1, date2, time); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
            pagesource = new PagedDataSource();
            pagesource.DataSource = ds.Tables[0].DefaultView;
            pagesource.PageSize = 10;
            pagesource.AllowPaging = true;

            DataList1.DataSource = pagesource;
            DataList1.DataBind();
        }
    }
}