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
    public partial class CancelReservation : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        timedatecalculater tdc = new timedatecalculater();
        insertions insert = new insertions();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM users.userinfo WHERE userID=@uid", connection);
            query.Parameters.Add("@uid", SqlDbType.NVarChar).Value = "1"; // sessiondan gelen kullanıcı id si yazılacak
            connection.Open();
            SqlDataReader dr2 = query.ExecuteReader();
            if (dr2.Read())
            {
                navbarname.Text = dr2["userName"].ToString();
            }
            connection.Close();

            SqlCommand query2 = new SqlCommand("select b.bID, r.resID, b.bName, b.workOpen, b.workClose, rules.latestCancelTime, rules.lateCancelFine, r.reservationDate, r.reservationTime, c.symbol from[business].[Businessinfo] b inner join[business].[reservationRules] rules on rules.bID = b.bID inner join[business].[tableinfo] t on t.bID = b.bID inner join[business].[reservation] r on r.tableID = t.tID inner join [users].[userinfo] u on r.userID = u.userID inner join[dbo].[currency] c on u.currency = c.id where r.resID = @resid", connection);
            query2.Parameters.Add("@resid", SqlDbType.NVarChar).Value = Session["resID"]; 
            connection.Open();
            SqlDataReader dr = query2.ExecuteReader();
            if (dr.Read())
            {
                //Session["resID"] = dr["resID"].ToString();
                rname.Text = dr["bName"].ToString() + "  ( " + dr["workOpen"].ToString() + ".00 - " + dr["workClose"].ToString() + ".00 )";
                date.Text = dr["reservationDate"].ToString();
                time.Text = dr["reservationTime"].ToString();
                canceltime.Text = dr["latestCancelTime"].ToString();
                cancelfine.Text = dr["lateCancelFine"].ToString() + " " + dr["symbol"].ToString(); //parayı change yap
            }
            connection.Close();

        }

        protected void cancelbutton_Click(object sender, EventArgs e)
        {
            int curr, fineint;
            decimal fine = 0;


            SqlCommand query2 = new SqlCommand("select b.bID, r.resID, b.bName, b.workOpen, b.workClose, rules.latestCancelTime, rules.lateCancelFine, r.reservationDate, r.reservationTime, c.symbol, c.id from[business].[Businessinfo] b inner join[business].[reservationRules] rules on rules.bID = b.bID inner join[business].[tableinfo] t on t.bID = b.bID inner join[business].[reservation] r on r.tableID = t.tID inner join [users].[userinfo] u on r.userID = u.userID inner join[dbo].[currency] c on b.currency = c.id where r.resID = @resid", connection);
            query2.Parameters.Add("@resid", SqlDbType.NVarChar).Value = Session["resID"]; // sessiondan gelen kullanıcı id si yazılacak
            connection.Open();
            SqlDataReader dr = query2.ExecuteReader();
            if (dr.Read())
            {
                date.Text = dr["reservationDate"].ToString();
                time.Text = dr["reservationTime"].ToString();
                canceltime.Text = dr["latestCancelTime"].ToString();
                fine = Convert.ToDecimal(dr["lateCancelFine"].ToString());
                curr =Convert.ToInt32(dr["id"].ToString()); //kullanıcnın gerçek para birimini alıyor. bunu dolara çevirmek gerekiyor


            }
            fineint = Convert.ToInt32(fine);
             if((DateTime.Now.ToShortDateString() + " 12:00:00 AM") == date.Text)
            {
                if((Convert.ToInt32(time.Text) - tdc.datetimeNowformatterforTime()) < Convert.ToInt32(canceltime.Text))
                {
                    //  insert.paymentForLateCancel(Convert.ToInt32(Session["bID"].ToString()), Convert.ToInt32(Session["userID"].ToString()), fine);
                    insert.paymentForLateCancel(1, 1, fine);
                    insert.CancelRes(Convert.ToInt32(Session["resID"].ToString()));
                    cancelbutton.Text = "ödeme gerek";
                }
                else cancelbutton.Text = "ödeme yok";
            }
             else cancelbutton.Text = "ödeme yok";
        }
    }
}