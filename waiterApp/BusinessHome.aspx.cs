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
    public partial class BusinessHome : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        PagedDataSource pagesource;
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
            DataSet ds = filldropdownlist.listReservations(1, 1); 
            pagesource = new PagedDataSource();
            pagesource.DataSource = ds.Tables[0].DefaultView;
            pagesource.PageSize = 10;
            pagesource.AllowPaging = true;

            DataList1.DataSource = pagesource;
            DataList1.DataBind();

            Repeater1.DataSource = filldropdownlist.getOrderDetailsForBusinessinGeneral(1); //session yazılacak
                Repeater1.DataBind();

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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("viewReservations.aspx", true);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            Session["orderID"] = button1.CommandArgument.ToString();
            Server.Transfer("OrderDetailpage.aspx", true);
        }

        protected void editinfobutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("BusinessEditInfo.aspx", true);
        }
    }
}