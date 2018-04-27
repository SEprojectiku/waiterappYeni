using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace waiterApp
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown fdp = new fillDropDown();
        insertions insert = new insertions();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = fdp.getOrderDetails(Convert.ToInt32(Session["orderID"].ToString())); // sessiondan gelen orderid yazılacak
            DataList1.DataBind();

            Total.Text = fdp.getOrderTotal(Convert.ToInt32(Session["orderID"].ToString()));
            orderdate.Text = fdp.getOrderDate(Convert.ToInt32(Session["orderID"].ToString()));
        }

        protected void paybutton_Click(object sender, EventArgs e)
        {
            insert.insertPayment(Convert.ToInt32(Session["bID"]), Convert.ToInt32(Session["userID"]), Convert.ToDecimal(Total.Text), Convert.ToInt32(Session["orderID"]), 1); //şimdilik direk confirm yapıyor, business için confirm sayfası yok

            connection.Open();
            SqlCommand delete = new SqlCommand("delete from orders.orderDetails where orderID = " + Session["orderID"].ToString(), connection);
            delete.ExecuteNonQuery();
            SqlCommand delete2 = new SqlCommand("update orders.orders set orderStatus = 0", connection);
            delete2.ExecuteNonQuery();
            connection.Close();
        }
    }
}