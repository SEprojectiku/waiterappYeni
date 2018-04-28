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
    
    public partial class signup : System.Web.UI.Page
    {

        static bool signUpType = true;
        fillDropDown filldropdownlist = new fillDropDown();
         static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        insertions insert = new insertions();
        encyption enc = new encyption();
        protected void Page_Load(object sender, EventArgs e)
        {
            pass1.Attributes["value"] = pass1.Text;
            pass2.Attributes["value"] = pass2.Text;
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

                for (int i = 0; i <= 31; i++)
                    day.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                day.SelectedItem.Text = "Day";
                for (int i = 0; i <= 12; i++)
                    mount.Items.Insert(i, new ListItem(i.ToString(), i.ToString()));
                mount.SelectedItem.Text = "Month";
                for (int i = 1940; i <= 2018; i++)
                    year.Items.Insert(i-1940, new ListItem(i.ToString(), i.ToString()));
                year.SelectedItem.Text = "Year";
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

        protected void businessBtn_Click(object sender, EventArgs e)
        {

            signUpType = false;
            businessBtn.CssClass = "btn btn-primary btn-lg";
            customerBtn.CssClass = "btn btn-light btn-lg";
             

            
            

            
            currencylist.Visible = true;
            Label11.Visible = false;
           
        }

        protected void customerBtn_Click(object sender, EventArgs e)
        {

            signUpType = true;
            businessBtn.CssClass = "btn btn-light btn-lg";
            customerBtn.CssClass = "btn btn-primary btn-lg";



           // string password = enc.CreateMD5(pass1.Text.Trim());
            currencylist.Visible = true;
            Label11.Visible = true;
           
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string table="";
            if (signUpType)
                table = "insert into users.userinfo(firstName,lastName,userName,phoneNumber,email,userPassword,birthDay,gender,city,lang " +
                                                                    ", currency, registerDate, membershipStatus, photoPath) " +
                                                                    "VALUES(@fname,@lname,@uname,@phone,@email,@password,@bday,@gendr,@city,@lang,@curr,@regisdate,@memstatus,@phopath)";
            else
                table = "insert into business.memberinfo(firstName,lastName,userName,phone1,email,userPassword,birthDay,gender,city,lang " +
                                                                    ", registerDate, membershipStatus, photoPath) " +
                                                                    "VALUES(@fname,@lname,@uname,@phone,@email,@password,@bday,@gendr,@city,@lang,@regisdate,@memstatus,@phopath)";


         //      string password = enc.CreateMD5(pass1.Text.Trim());

            string birth = year.SelectedValue.ToString() + "-" + mount.SelectedValue.ToString() + "-" +
                         day.SelectedValue.ToString();

            try
            {


                int basarili;
                connection.Open();
                SqlCommand submit = new SqlCommand(table);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    submit.Parameters.AddWithValue("@fname ", nameBox.Text.Trim());
                    submit.Parameters.AddWithValue("@lname ", srnameBox.Text.Trim());
                    submit.Parameters.AddWithValue("@uname ", usernameBox.Text.Trim());
                    submit.Parameters.AddWithValue("@email ", email_txtb.Text.Trim());
                    submit.Parameters.AddWithValue("@phone ", phone1.Text.Trim());
                    submit.Parameters.AddWithValue("@password ", pass1.Text);
                    submit.Parameters.AddWithValue("@bday ", birth);
                    submit.Parameters.AddWithValue("@gendr ", gender.SelectedValue);
                    submit.Parameters.AddWithValue("@city ", cityist.SelectedIndex+1);
                    submit.Parameters.AddWithValue("@lang ", langlist.SelectedIndex+1);
                    submit.Parameters.AddWithValue("@curr ", currencylist.SelectedIndex+1);
                    submit.Parameters.AddWithValue("@regisdate ", DateTime.Now);
                    submit.Parameters.AddWithValue("@memstatus ", 1);
                    submit.Parameters.AddWithValue("@phopath ", "sdfasdf");
                    submit.Connection = connection;

                    basarili = Convert.ToInt32(submit.ExecuteScalar());
                    connection.Close();

                }

                if (signUpType == false)
                {

                    connection.Open();
                    SqlCommand getid = new SqlCommand("select * from business.memberinfo where email = '" + email_txtb.Text.Trim()+ "'", connection);
                    SqlDataReader dr = getid.ExecuteReader();
                    if (dr.Read())
                    {
                        Session["memberID"] = dr["memberID"].ToString();
                        Server.Transfer("BusinessAddInfo.aspx", true);
                    }
                    connection.Close();
                }

                errorr_panel.Visible = true;
                success.Visible = true;
                fail.Visible = false;

            }
            catch (Exception)
            {
                errorr_panel.Visible = true;
                fail.Visible = true;
                success.Visible = false;
            }

            
                

           
        }

       
    }
}