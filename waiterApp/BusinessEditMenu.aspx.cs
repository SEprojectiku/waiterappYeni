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
    public partial class BusinessEditMenu : System.Web.UI.Page
    {
        fillDropDown fdp = new fillDropDown();
        insertions insert = new insertions();
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = fdp.menucategories();
                DropDownList0.DataTextField = "catName";
                DropDownList0.DataValueField = "catID";
                DropDownList0.DataSource = dt;
                DropDownList0.DataBind();


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
        ArrayList catid = new ArrayList();
            ArrayList name = new ArrayList();
            ArrayList ingr = new ArrayList();
            ArrayList price = new ArrayList();
            ArrayList pretime = new ArrayList();
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string strValue = "";

            int i = 0;
            foreach (string key in Request.Form.Keys)
            {
                if(i == 0)
                {
                   // strValue += DropDownList0.SelectedValue.ToString();
                    catid.Add(DropDownList0.SelectedValue.ToString());
                }
                if(key.Contains("select"))
                {
                    //strValue += Request.Form[key].ToString();
                    catid.Add(Request.Form[key].ToString());
                }
                if (key.Contains("name"))
                {
                   // strValue += Request.Form[key].ToString();
                    name.Add(Request.Form[key].ToString());
                }
                if(key.Contains("price"))
                {
                    price.Add(Request.Form[key].ToString());
                   // strValue += Request.Form[key].ToString();
                }
                if (key.Contains("indgr"))
                {
                    ingr.Add(Request.Form[key].ToString());
                    // strValue += Request.Form[key].ToString();
                }
                if (key.Contains("pretime"))
                {
                    pretime.Add(Request.Form[key].ToString());
                    // strValue += Request.Form[key].ToString();
                }
                i++;

            }
            int menuid = Convert.ToInt32(Session["menuID"].ToString());
            insert.insertMenu(catid, name, price, ingr, pretime, i, menuid);
            
        }
    }
}