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
    public partial class CutomerProfilePage : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        PagedDataSource pagesource;
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            DataTable dt = filldropdownlist.currency();
            currencylist.DataTextField = "currency";
            currencylist.DataValueField = "id";
            currencylist.DataSource = dt;
            currencylist.DataBind();

            DataTable dt2 = filldropdownlist.languages();
            langlist.DataTextField = "name";
            langlist.DataValueField = "id";
            langlist.DataSource = dt2;
            langlist.DataBind();

            SqlCommand query = new SqlCommand("SELECT * FROM users.userinfo WHERE userID=@uid", connection);
            query.Parameters.Add("@uid", SqlDbType.NVarChar).Value = Session["userID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
            connection.Open();
            SqlDataReader dr = query.ExecuteReader();
            if (dr.Read())
            {
                myName.Text = dr["userName"].ToString();
                navbarname.Text = dr["userName"].ToString();
                langlist.SelectedValue = dr["lang"].ToString();
                currencylist.SelectedValue = dr["currency"].ToString();
            }
            connection.Close();

                //for active orders

                SqlCommand query2 = new SqlCommand("select b.bName, o.orderDate, o.orderID, sum(md.price * od.piece) as total from[orders].[orders] o inner join[business].[Businessinfo] b on b.bID = o.bID inner join[orders].[orderDetails] od on od.orderID = o.orderID inner join[business].[menudetails] md on md.foodbeveragesID = od.foodbeveragesID where o.userID = @uid and o.orderStatus = 1 and o.isConfirmed = 1 group by b.bName, o.orderDate, o.orderID", connection);
                query2.Parameters.Add("@uid", SqlDbType.NVarChar).Value = Session["userID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
                connection.Open();
                SqlDataReader dr2 = query2.ExecuteReader();
                if (dr2.Read())
                {
                    bname.Text = dr2["bName"].ToString();
                    date.Text = dr2["orderDate"].ToString();
                    orderid.Text = dr2["orderID"].ToString();
                    total.Text = dr2["total"].ToString();
                    paybutton.CommandArgument = dr2["orderID"].ToString();

                    bname.Visible = true;
                    date.Visible = true;
                    orderid.Visible = true;
                    total.Visible = true;
                    paybutton.Visible = true;

                }
                connection.Close();

                //end active orders


                DataSet ds = filldropdownlist.listComingResforcustomer(Convert.ToInt32(Session["userID"].ToString())); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
            pagesource = new PagedDataSource();
            pagesource.DataSource = ds.Tables[0].DefaultView;
            pagesource.PageSize = 10;
            pagesource.AllowPaging = true;

            DataList1.DataSource = pagesource;
            DataList1.DataBind();
            }
           
        }

        protected void detailbutton_Click(object sender, EventArgs e)
        {
            Button Button1 = (Button)sender;
           Session["resID"]= Button1.CommandArgument.ToString();
            Server.Transfer("CancelReservation.aspx", true);
        }

        protected void currencylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand update = new SqlCommand("update users.userinfo set currency = @curr where userID = @uid", connection);
            update.Parameters.Add("@uid", SqlDbType.NVarChar).Value = Session["userID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
            update.Parameters.Add("@curr", SqlDbType.NVarChar).Value = currencylist.SelectedValue.ToString();
            update.ExecuteNonQuery();
            connection.Close();
        }

        protected void langlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand update = new SqlCommand("update users.userinfo set lang = @lang where userID = @uid", connection);
            update.Parameters.Add("@uid", SqlDbType.NVarChar).Value = Session["userID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
            update.Parameters.Add("@lang", SqlDbType.NVarChar).Value = langlist.SelectedValue.ToString();
            update.ExecuteNonQuery();
            connection.Close();
        }

        protected void paybutton_Click(object sender, EventArgs e)
        {
            Button buton1 = (Button)sender;
            Session["orderID"] = buton1.CommandArgument.ToString();
            Server.Transfer("PaymentPage.aspx", true);
        }
    }
}