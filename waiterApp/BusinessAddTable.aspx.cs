using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
namespace waiterApp
{
    public partial class BusinessAddTable : System.Web.UI.Page
    {
        fillDropDown fdp = new fillDropDown();
        insertions insert = new insertions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = fdp.tabletypes();
                DropDownList0.DataTextField = "tableType";
                DropDownList0.DataValueField = "typeID";
                DropDownList0.DataSource = dt;
                DropDownList0.DataBind();
            }
        }
            ArrayList type = new ArrayList();
            ArrayList name = new ArrayList();
            ArrayList chair = new ArrayList();
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string strValue = "";
            int i = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (i == 0)
                {
                    type.Add(DropDownList0.SelectedValue.ToString());
                   //  strValue += DropDownList0.SelectedValue.ToString();
                }
                if (key.Contains("select"))
                {
                    type.Add(Request.Form[key].ToString());
                   //  strValue += Request.Form[key].ToString();
                }
                if (key.Contains("name"))
                {
                    name.Add(Request.Form[key].ToString());
                   //  strValue += Request.Form[key].ToString();
                }
                if (key.Contains("chair"))
                {
                    chair.Add(Request.Form[key].ToString());
                   //  strValue += Request.Form[key].ToString();
                }
                i++;
               
            }
            // TextBox2.Text = strValue;

            insert.insertTable(type, name, chair, i, 1);
        }
    }
}