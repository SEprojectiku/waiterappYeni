using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waiterApp
{
    public partial class Login2 : System.Web.UI.Page
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        encyption enc = new encyption();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM users.userinfo WHERE email=@email AND userPassword=@pass", connection);

            query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailLogin.Text;
            query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = enc.CreateMD5(passwordLogin.Text);

            connection.Open();

            SqlDataReader dr = query.ExecuteReader();
            // Eğer bir kayıt varsa
            if (dr.Read())
            {
                HttpCookie myCookie = new HttpCookie("user");
                myCookie["name"] = emailLogin.Text;
                myCookie.Expires = DateTime.Now.AddDays(1);



                myCookie["userID"] = dr["userID"].ToString();
                //myCookie["fname"] = dr["FirstName"].ToString();
                //myCookie["lname"] = dr["LastName"].ToString();
                //myCookie["isAdmin"] = dr["isAdmin"].ToString();
                Response.Cookies.Add(myCookie);
                Response.Redirect("Index.aspx");

            }
            else
            {

                err_lbl.Visible = true;
            }
            dr.Close();
            connection.Close();
        }

        protected void busslogin_Click(object sender, EventArgs e)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM business.memberinfo WHERE email=@email AND userPassword=@pass", connection);

            query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailBusiness.Text;
            query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = enc.CreateMD5(passBus.Text);

            connection.Open();

            SqlDataReader dr = query.ExecuteReader();
            // Eğer bir kayıt varsa
            if (dr.Read())
            {
                HttpCookie myCookie = new HttpCookie("user");
                myCookie["name"] = emailLogin.Text;
                myCookie.Expires = DateTime.Now.AddDays(1);



                myCookie["userID"] = dr["memberID"].ToString();
                //myCookie["fname"] = dr["FirstName"].ToString();
                //myCookie["lname"] = dr["LastName"].ToString();
                //myCookie["isAdmin"] = dr["isAdmin"].ToString();
                Response.Cookies.Add(myCookie);
                Response.Redirect("Index.aspx");

            }
            else
            {

                err_lbl.Visible = true;
            }
            dr.Close();
            connection.Close();
        }
    }
}