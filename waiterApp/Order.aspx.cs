﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;


namespace waiterApp
{
    public partial class Order : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            fillDropDown fdp = new fillDropDown();
        insertions insert = new insertions();
        int[] itemid = new int[100];
       // int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);
                query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = Session["bID"].ToString(); // sessiondan gelen kullanici id si yazilacak
                connection.Open();
                SqlDataReader dr2 = query.ExecuteReader();
                if (dr2.Read())
                {
                    myName.Text = dr2["bName"].ToString();
                 //   navbarname.Text = dr2["bName"].ToString();

                }
                connection.Close();

              //  myName.Text = Session["bName"].ToString();
                navbarname.Text = Session["userName"].ToString();
                Repeater2.DataSource = fdp.listActiveMenuitems(Convert.ToInt32(Session["bID"].ToString()));
                Repeater2.DataBind();

                //DataList1.DataSource = fdp.listActiveMenuitems(1);
                //DataList1.DataBind();

            }
         int i = 0;
             connection.Open();
            SqlCommand cmd = new SqlCommand("select * from [business].[menu] m inner join[business].[menudetails] md on m.menuID = md.menuID where bID = '"+Session["bID"].ToString()+"' and m.isMenuOnline = 1 and md.visibility = 1", connection); 
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                itemid[i] = Convert.ToInt32(dr["foodbeveragesID"].ToString());
                i++;
            }
            connection.Close();

        }
        ArrayList itemlist = new ArrayList();
        ArrayList quantitylist = new ArrayList();

        protected void orderbutton_Click(object sender, EventArgs e)
        {

            int i = 0, j = 0;
       
            foreach(RepeaterItem ri in Repeater2.Items)
            {
                TextBox txt = (TextBox)ri.FindControl("quantitytxt");
                string quantity = txt.Text;
                if(quantity != "0")
                {
                itemlist.Add(Convert.ToInt32(itemid[i].ToString()));
                quantitylist.Add(Convert.ToInt32(quantity));
                    j++;
                }

                i++;
            }


            insert.insertOrder(Convert.ToInt32(Session["bID"].ToString()), Convert.ToInt32(Session["tableID"].ToString()), Convert.ToInt32(Session["userID"].ToString()));
            int orderid = 1;

            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from orders.orders where userID = " + Session["userID"].ToString(), connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                orderid = Convert.ToInt32(dr["orderID"].ToString());
            }
            connection.Close();
            Session["orderID"] = orderid;
            int toplam = j;
            insert.insertOrderDetails(orderid, itemlist, quantitylist, toplam);

            Server.Transfer("CutomerProfilePage.aspx", true);
        }
    }
}