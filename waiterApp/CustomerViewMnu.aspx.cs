﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace waiterApp
{
    public partial class CustomerViewMnu : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown fdp = new fillDropDown();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              //  int menuid = Convert.ToInt32(Session["menuID"].ToString());
                Repeater1.DataSource = fdp.listActiveMenuitemsCategories(Convert.ToInt32(Session["bID"].ToString())); //business id girilecek
                Repeater1.DataBind();
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
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           // int menuid = Convert.ToInt32(Session["menuID"].ToString());
            SqlConnection con = new SqlConnection(connectionString);

            /*    SqlCommand komut = new SqlCommand("SELECT * FROM [business].[menudetails] md inner join [business].[menu] m on m.menuID = md.menuID where m.bID = 1 and m.menuID = '" + menuid + "' and md.catID=" + Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "catID")), con);// işletmeye özel sorgu için businessID GİRİLECEK eKSİK
                con.Open();*/
                Repeater rp = (Repeater)e.Item.FindControl("Repeater2");

            rp.DataSource = fdp.listActiveMenuitemswithCategories(Convert.ToInt32(Session["bID"].ToString()), Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "catID")));
            rp.DataBind();

            con.Close();
        }
    }
}