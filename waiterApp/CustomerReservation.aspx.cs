using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Collections;

namespace waiterApp
{
    
    public partial class CustomerReservation : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        insertions insert = new insertions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = filldropdownlist.tableTypes(1); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
                types.DataTextField = "tableType";
                types.DataValueField = "typeID";
                types.DataSource = dt;
                types.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mesaj = messageText.Text.ToString();
            insert.insertReservation(1, Convert.ToInt32(tablename.SelectedValue), Session["date1"].ToString(), Convert.ToInt32(timeList.SelectedValue), mesaj);

        }
        
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {   string date1, date2;
            date1 = Calendar1.SelectedDate.Year.ToString();
            date1 += "-";
            if (Calendar1.SelectedDate.Month < 10 && Calendar1.SelectedDate.Month >= 1)
            {
                date1 += "0";
            }
            date1 += Calendar1.SelectedDate.Month.ToString();
            date1 += "-";
            string date11 = date1;
            if (Calendar1.SelectedDate.Day < 10 && Calendar1.SelectedDate.Day >= 1) date1 += "0";
            date1 += Calendar1.SelectedDate.Day.ToString();
            

            int a = (Convert.ToInt32(Calendar1.SelectedDate.Day) + 1);

            date2 = date11 + a.ToString();
            Session["date1"] = date1;
            Session["date2"] = date2;
            search();
        }

    

        public void types_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  date1 = "2018-11-03";
            //  date2 = "2018-12-04";
            search();
        }

        protected void timeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }
        public void search()
        {
            string date1 = Session["date1"].ToString();
            string date2 = Session["date2"].ToString();
            DataTable dt = filldropdownlist.listavaliableTables(1, Convert.ToInt32(timeList.SelectedValue.ToString()), date1, date2, Convert.ToInt32(types.SelectedValue.ToString()));
            tablename.DataTextField = "tName";
            tablename.DataValueField = "tID";
            tablename.DataSource = dt;
            tablename.DataBind();
        }
    }
}