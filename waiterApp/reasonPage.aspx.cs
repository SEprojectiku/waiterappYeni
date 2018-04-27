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
    public partial class reasonPage : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM AllcancelReasons", connection);
                connection.Open();
                DataTable dt = new DataTable();
                query.Fill(dt);  
                connection.Close();

                DropDownList1.DataTextField = "reasonName";
                DropDownList1.DataValueField = "reasonID";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();



                SqlCommand query2 = new SqlCommand("SELECT bID, reasonID, count(bID) as total FROM business.BusinessCancelReasons WHERE bID=@bid and reasonID = 1 group by bID, reasonID", connection);
                query2.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Session["bID"].ToString(); // sessiondan gelen kullanıcı id si yazılacak
                connection.Open();
                SqlDataReader dr = query2.ExecuteReader();
                if (dr.Read())
                {
                    countlbl.Text = dr["total"].ToString();

                }
                connection.Close();

                myName.Text = Session["bName"].ToString();
                navbarname.Text = Session["bName"].ToString();
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand kayit = new SqlCommand("insert into business.BusinessCancelReasons(reasonID,bID,reasondesc)values(@rID,@bid,@desc)", connection);
            kayit.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Session["bID"].ToString(); //session yazılacak
            kayit.Parameters.Add("@rID", SqlDbType.NVarChar).Value = DropDownList1.SelectedValue;
            kayit.Parameters.Add("@desc", SqlDbType.NVarChar).Value = TextBox2.Text;
            kayit.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            SqlCommand updatestatus = new SqlCommand("update [orders].[orders] set orderStatus = 0 where orderID = " + Session["orderID"].ToString(), connection); //35 yerine session yazılacak
            updatestatus.ExecuteNonQuery();
            connection.Close();

            Server.Transfer("BusinessListMenus.aspx", true);
        }
    }
}