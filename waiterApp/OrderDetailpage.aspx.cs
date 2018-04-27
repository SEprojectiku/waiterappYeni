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
    public partial class OrderDetailpage : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Repeater1.DataSource = filldropdownlist.getOrderDetailsForBusiness(35,1); //session yazılacak
                Repeater1.DataBind();

                SqlCommand query = new SqlCommand("	select o.orderDate, o.orderID, o.bID, o.userID, u.userName, o.tableID, t.tName, md.foodbeveragesName, od.piece, md.price, (od.piece * md.price) as semitotal from[orders].[orders] o inner join[orders].[orderDetails] od on o.orderID = od.orderID inner join[business].[menudetails] md on md.foodbeveragesID = od.foodbeveragesID inner join[users].[userinfo] u on u.userID = o.userID inner join[business].[tableinfo] t on t.tID = o.tableID where o.orderID = @orderid", connection);
                query.Parameters.Add("@orderid", SqlDbType.NVarChar).Value = Session["orderID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
                connection.Open();
                SqlDataReader dr = query.ExecuteReader();
                if (dr.Read())
                {
                    uname.Text = dr["userName"].ToString();
                    date.Text = dr["orderDate"].ToString();

                }
                connection.Close();
            }
        }

        protected void cancelbutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("reasonPage.aspx", true);
        }

        protected void confirmbutton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand update = new SqlCommand("update orders.orders set isConfirmed = 1 where orderID = " + Session["orderID"].ToString(), connection);
            update.ExecuteNonQuery();
            connection.Close();
        }
    }
}