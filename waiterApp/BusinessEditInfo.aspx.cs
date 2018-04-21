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
    public partial class BusinessEditInfo : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        insertions insert = new insertions();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = filldropdownlist.currency();
                currencylist.DataTextField = "currency";
                currencylist.DataValueField = "id";
                currencylist.DataSource = dt;
                currencylist.DataBind();

                DataTable dt2 = filldropdownlist.languages();
                langlist.DataTextField = "name";
                langlist.DataValueField = "id";
                langlist.DataSource = dt2;
                langlist.DataBind();

                DataTable dt3 = filldropdownlist.countries();
                countrylist.DataTextField = "name";
                countrylist.DataValueField = "id";
                countrylist.DataSource = dt3;
                countrylist.DataBind();

                int bID = 1;

                SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);

                query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = bID.ToString();


                connection.Open();

                SqlDataReader dr = query.ExecuteReader();
                if(dr.Read())
                {
                    bname.Text = dr["bName"].ToString();
                    bdesc.Text = dr["bdesc"].ToString();
                    p1.Text = dr["phone1"].ToString();
                    p2.Text = dr["phone2"].ToString();
                    email.Text = dr["email"].ToString();
                    cityist.SelectedValue = dr["city"].ToString();
                    lat.Text = dr["lat"].ToString();
                    lng.Text = dr["lng"].ToString();
                    avg.Text = dr["avaragePrice"].ToString();
                    wopen.Text = dr["workOpen"].ToString();
                    wclose.Text = dr["workClose"].ToString();
                    lng.Text = dr["lng"].ToString();
                    lng.Text = dr["lng"].ToString();
                    currencylist.SelectedValue = dr["currency"].ToString();
                    langlist.SelectedValue = dr["lang"].ToString();
                }

            }
        }

        protected void countrylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryid = Convert.ToInt32(countrylist.SelectedValue);
            DataTable dt = filldropdownlist.states(countryid);
            cityist.DataTextField = "name";
            cityist.DataValueField = "id";
            cityist.DataSource = dt;
            cityist.DataBind();
        }

        protected void editmenubutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("BusinessListMenus.aspx", true);
        }

        protected void edittablebutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("editTables.aspx", true);
        }

        protected void savebutton_Click(object sender, EventArgs e)
        {
            insert.updateBusinessinfo(1, bname.Text, bdesc.Text, Convert.ToInt32(cityist.SelectedValue), p1.Text, p2.Text, email.Text, Convert.ToDecimal(lat.Text), Convert.ToDecimal(lng.Text), Convert.ToInt32(avg.Text), Convert.ToInt32(wopen.Text), Convert.ToInt32(wclose.Text), Convert.ToInt32(currencylist.SelectedValue), Convert.ToInt32(langlist.SelectedValue));

        }
    }
}