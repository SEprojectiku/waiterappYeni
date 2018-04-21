using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace waiterApp
{
    public partial class EditMenuYeni : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown fdp = new fillDropDown();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                int menuid = Convert.ToInt32(Session["menuID"].ToString());
                Repeater1.DataSource = fdp.menucategories(menuid); //menu id girilecek
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int menuid = Convert.ToInt32(Session["menuID"].ToString());
            SqlConnection con = new SqlConnection(connectionString);
            
            SqlCommand komut = new SqlCommand("SELECT * FROM [business].[menudetails] md inner join [business].[menu] m on m.menuID = md.menuID where m.bID = 1 and m.menuID = '"+menuid+"' and md.catID=" + Convert.ToInt32(DataBinder.Eval(e.Item.DataItem,"catID")), con);// işletmeye özel sorgu için businessID GİRİLECEK eKSİK
            con.Open();
            Repeater rp = (Repeater)e.Item.FindControl("Repeater2");
           
            rp.DataSource = komut.ExecuteReader();
            rp.DataBind();
            komut.Dispose();
             con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Button Button1 = (Button)sender;
            con.Open();
            SqlCommand delete = new SqlCommand("delete from [business].[menudetails] where foodbeveragesID = '" + Button1.CommandArgument + "'", con);
            delete.ExecuteNonQuery();

            con.Close();
            int menuid = Convert.ToInt32(Session["menuID"].ToString());
            Repeater1.DataSource = fdp.menucategories(menuid);
            Repeater1.DataBind();
        }

        protected void additem_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("BusinessEditMenu.aspx", true);
        }

        protected void showbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Button Button1 = (Button)sender;
            con.Open();
            SqlCommand update = new SqlCommand("update [business].[menudetails] set visibility ='" + 1 + "' where foodbeveragesID = '" + Button1.CommandArgument + "'", con);
            update.ExecuteNonQuery();
            con.Close();
            int menuid = Convert.ToInt32(Session["menuID"].ToString());
            Repeater1.DataSource = fdp.menucategories(menuid);
            Repeater1.DataBind();
        }

        protected void hidebutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Button Button1 = (Button)sender;
            con.Open();
            SqlCommand update = new SqlCommand("update [business].[menudetails] set visibility ='" + 0 + "' where foodbeveragesID = '" + Button1.CommandArgument + "'", con);
            update.ExecuteNonQuery();
            con.Close();
            int menuid = Convert.ToInt32(Session["menuID"].ToString());
            Repeater1.DataSource = fdp.menucategories(menuid);
            Repeater1.DataBind();
        }
    }


}
