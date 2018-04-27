using System;
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
    public partial class CustomerBusinessPage : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);
                query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Session["bID"].ToString(); // sessiondan gelen kullanici id si yazilacak
                connection.Open();
                SqlDataReader dr = query.ExecuteReader();
                if (dr.Read())
                {
                    myName.Text = dr["bName"].ToString();
                 //   navbarname.Text = dr["bName"].ToString();

                }
                connection.Close();
                navbarname.Text = Session["userName"].ToString();

                
            }
        }

        protected void sitbutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerSetTable.aspx", true);
        }

        protected void rezbutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerReservation.aspx", true);
        }

        protected void ViewMenubutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerViewMnu.aspx", true);
        }
    }
}