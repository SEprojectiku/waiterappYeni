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
    public partial class BusinessAddInfo : System.Web.UI.Page
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

                //SqlCommand query = new SqlCommand("SELECT * FROM business.businessinfo WHERE bID=@bid", connection);

                //query.Parameters.Add("@bid", SqlDbType.NVarChar).Value = bID.ToString();


                //connection.Open();

                //SqlDataReader dr = query.ExecuteReader();
                //if (dr.Read())
                //{
                //    bname.Text = dr["bName"].ToString();
                //    bdesc.Text = dr["bdesc"].ToString();
                //    p1.Text = dr["phone1"].ToString();
                //    p2.Text = dr["phone2"].ToString();
                //    email.Text = dr["email"].ToString();
                //    cityist.SelectedValue = dr["city"].ToString();
                //    lat.Text = dr["lat"].ToString();
                //    lng.Text = dr["lng"].ToString();
                //    avg.Text = dr["avaragePrice"].ToString();
                //    wopen.Text = dr["workOpen"].ToString();
                //    wclose.Text = dr["workClose"].ToString();
                //    lng.Text = dr["lng"].ToString();
                //    lng.Text = dr["lng"].ToString();
                //    currencylist.SelectedValue = dr["currency"].ToString();
                //    langlist.SelectedValue = dr["lang"].ToString();
                //}

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
            try
            {


                int basarili;
                connection.Open();
                SqlCommand submit = new SqlCommand("insert  business.Businessinfo(bName,bdesc,city,establishedYear,registerDate,phone1,phone2,email,lat,lng " +
                                                                    ", avaragePrice, tableNumber, workOpen, workClose,memberID) " +
                                                                    "VALUES(@bName,@bdesc,@city,@establishedYear,@registerDate,@phone1,@phone2,@email,@lat,@lng,@avaragePrice,@tableNumber, @workOpen,@workClose,@memberID)");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    submit.Parameters.AddWithValue("@bName ", bname.Text );
                    submit.Parameters.AddWithValue("@bdesc ", bdesc.Text);
                   
                    submit.Parameters.AddWithValue("@city ", 3);
                    submit.Parameters.AddWithValue("@establishedYear ", 1234);
                    submit.Parameters.AddWithValue("@registerDate ","1995-11-11");
                    submit.Parameters.AddWithValue("@phone1 ", p1.Text);
                    submit.Parameters.AddWithValue("@phone2 ", p2.Text);
                    submit.Parameters.AddWithValue("@email ", email.Text);
                    submit.Parameters.AddWithValue("@lat ", currencylist.SelectedIndex + 1);
                    submit.Parameters.AddWithValue("@lng ", langlist.SelectedIndex + 1);
                    submit.Parameters.AddWithValue("@avaragePrice ", avg.Text);
                    submit.Parameters.AddWithValue("@tableNumber ", 1);
                    submit.Parameters.AddWithValue("@workOpen ", wopen.Text);
                    submit.Parameters.AddWithValue("@workClose ", wclose.Text);
                    submit.Parameters.AddWithValue("@memberID ", 1);
                    submit.Connection = connection;

                    basarili = Convert.ToInt32(submit.ExecuteScalar());
                    connection.Close();
                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "basicModal", "$('#basicModal').modal();", true);
                success.Visible = true; fail.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "basicModal", "$('#basicModal').modal();", true);
                fail.Visible = true; success.Visible = false;
            }
            
        }
    }
}