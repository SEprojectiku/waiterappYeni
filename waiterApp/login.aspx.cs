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
    public partial class login : System.Web.UI.Page
    {
        static bool loginType = true;
        encyption enc = new encyption();
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void businessBtn_Click(object sender, EventArgs e)
        {

            loginType = false;
            businessBtn.CssClass = "btn btn-primary btn-lg";
            customerBtn.CssClass = "btn btn-light btn-lg";








        }
        protected void customerBtn_Click(object sender, EventArgs e)
        {

            loginType = true;
            businessBtn.CssClass = "btn btn-light btn-lg";
            customerBtn.CssClass = "btn btn-primary btn-lg";






        }

        protected void login_Click(object sender, EventArgs e)
        {
            string password = enc.CreateMD5(passBox.Text.Trim());
            if(loginType)
            {
                
                SqlCommand query = new SqlCommand("SELECT * FROM users.userinfo WHERE email=@email AND userPassword=@pass", connection);

                query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailBox.Text;
                query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;// enc.CreateMD5(passBox.Text);

                connection.Open();

                SqlDataReader dr = query.ExecuteReader();
                // Eğer bir kayıt varsa
                if (dr.Read())
                {
                    HttpCookie myCookie = new HttpCookie("user");
                    myCookie["name"] = emailBox.Text;
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
            else
            {
                SqlCommand query = new SqlCommand("SELECT * FROM business.memberinfo WHERE email=@email AND userPassword=@pass", connection);

                query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailBox.Text;
                query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = enc.CreateMD5(passBox.Text);

                connection.Open();

                SqlDataReader dr = query.ExecuteReader();
                // Eğer bir kayıt varsa
                if (dr.Read())
                {
                    HttpCookie myCookie = new HttpCookie("user");
                    myCookie["name"] = emailBox.Text;
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
        
        //protected void Login_Click(object sender, EventArgs e)
        //{
        //    SqlCommand query = new SqlCommand("SELECT * FROM users.userinfo WHERE email=@email AND userPassword=@pass", connection);

        //    query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailLogin.Text;
        //    query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = enc.CreateMD5(passwordLogin.Text);

        //    connection.Open();

        //    SqlDataReader dr = query.ExecuteReader();
        //    // Eğer bir kayıt varsa
        //    if (dr.Read())
        //    {
        //        HttpCookie myCookie = new HttpCookie("user");
        //        myCookie["name"] = emailLogin.Text;
        //        myCookie.Expires = DateTime.Now.AddDays(1);



        //        myCookie["userID"] = dr["userID"].ToString();
        //        //myCookie["fname"] = dr["FirstName"].ToString();
        //        //myCookie["lname"] = dr["LastName"].ToString();
        //        //myCookie["isAdmin"] = dr["isAdmin"].ToString();
        //        Response.Cookies.Add(myCookie);
        //        Response.Redirect("Index.aspx");

        //    }
        //    else
        //    {

        //        err_lbl.Visible = true;
        //    }
        //    dr.Close();
        //    connection.Close();
        //}

        //protected void busslogin_Click(object sender, EventArgs e)
        //{
        //    SqlCommand query = new SqlCommand("SELECT * FROM business.memberinfo WHERE email=@email AND userPassword=@pass", connection);

        //    query.Parameters.Add("@email", SqlDbType.NVarChar).Value = emailBusiness.Text;
        //    query.Parameters.Add("@pass", SqlDbType.NVarChar).Value = enc.CreateMD5(passBus.Text);

        //    connection.Open();

        //    SqlDataReader dr = query.ExecuteReader();
        //    // Eğer bir kayıt varsa
        //    if (dr.Read())
        //    {
        //        HttpCookie myCookie = new HttpCookie("user");
        //        myCookie["name"] = emailLogin.Text;
        //        myCookie.Expires = DateTime.Now.AddDays(1);



        //        myCookie["userID"] = dr["memberID"].ToString();
        //        //myCookie["fname"] = dr["FirstName"].ToString();
        //        //myCookie["lname"] = dr["LastName"].ToString();
        //        //myCookie["isAdmin"] = dr["isAdmin"].ToString();
        //        Response.Cookies.Add(myCookie);
        //        Response.Redirect("Index.aspx");

        //    }
        //    else
        //    {

        //        err_lbl.Visible = true;
        //    }
        //    dr.Close();
        //    connection.Close();
        //}
    }
}