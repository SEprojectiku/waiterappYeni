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
            DataList1.DataSource = fdp.getOrderDetails(2); // sessiondan gelen orderid yazılacak
            DataList1.DataBind();

            Total.Text = fdp.getOrderTotal(2);
            orderdate.Text = fdp.getOrderDate(2);
        }

        protected void paybutton_Click(object sender, EventArgs e)
        {
            insert.insertPayment(2, 1, Convert.ToDecimal(Total.Text), 1, 1);

            connection.Open();
            SqlCommand delete = new SqlCommand("delete from orders.orderDetails where orderID = 2", connection);
            delete.ExecuteNonQuery();
            SqlCommand delete2 = new SqlCommand("update orders.orders set orderStatus = 0", connection);
            delete2.ExecuteNonQuery();
            connection.Close();
        }
    }
}