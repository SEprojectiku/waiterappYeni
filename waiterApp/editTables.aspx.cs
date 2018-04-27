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
    public partial class editTables : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown fdp = new fillDropDown();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);
            query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Convert.ToInt32(Session["bID"].ToString()); // sessiondan gelen kullanıcı id si yazılacak
            connection.Open();
            SqlDataReader dr = query.ExecuteReader();
            if (dr.Read())
            {
                myName.Text = dr["bName"].ToString();
                navbarname.Text = dr["bName"].ToString();

            }
            connection.Close();

            Repeater1.DataSource = fdp.tableTypes(1);
                Repeater1.DataBind();

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand komut = new SqlCommand("SELECT * FROM [business].[tableinfo] ti inner join [dbo].[tableTypes] tt on ti.tableType = tt.typeID where tt.typeID=" + Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "typeID")), con);// işletmeye özel sorgu için businessID GİRİLECEK eKSİK
            con.Open();
            Repeater rp = (Repeater)e.Item.FindControl("Repeater2");
            rp.DataSource = komut.ExecuteReader();
            rp.DataBind();
            komut.Dispose();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button Button1 = (Button)sender;
            int count = 0;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand checkres = new SqlCommand("select count(t.tID) as resSayisi, t.tID from [business].[reservation] r inner join [business].[tableinfo] t on t.tID = r.tableID where t.tID = '"+ Button1.CommandArgument +"' group by t.tID ", con);
            SqlDataReader dr = checkres.ExecuteReader();

            while (dr.Read()) {
               count = Convert.ToInt32(dr["resSayisi"].ToString()); 
            }
            con.Close();
            
            if(count == 0)
            {
            con.Open();
            SqlCommand delete = new SqlCommand("delete from [business].[tableinfo] where tID = '" + Button1.CommandArgument + "'", con);
            delete.ExecuteNonQuery();
            con.Close();

            Repeater1.DataSource = fdp.tableTypes(Convert.ToInt32(Session["bID"].ToString()));
            Repeater1.DataBind();
            }
            

        }


            
        }
    
}