using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml;
namespace waiterApp
{
    public partial class CustomerSearchPage : System.Web.UI.Page
    {
        static string locati=null;
        static string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        fillDropDown fdp = new fillDropDown();
        insertions insert = new insertions();
        string catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = fdp.SelectedCountriesStates();
                DataTable CategoryTable = fdp.BusinessCategories();
                CategoryButtonList.DataSource = CategoryTable;
                CategoryButtonList.DataBind();
                SelectState.DataTextField = "name";
                SelectState.DataValueField = "id";
                SelectState.DataSource = dt;
                SelectState.DataBind();
                Panel2.Visible = false;


              

                myName.Text = Session["userID"].ToString();
                navbarname.Text = Session["userName"].ToString();
            }
        }

        protected void SearchResID_Click(object sender, EventArgs e)
        {
            //string city =SelectState.SelectedItem.Value;
            string city;
            if (locati != null)
                city = locati;
            else
                city = SelectState.SelectedItem.Value;
            string searchbar = SearchBox.Text;
            if(searchbar != "" && city != "0")
            {
                BusinessList.DataSource = fdp.getBusinessList(city, searchbar);
              BusinessList.DataBind();
            }
           else if(searchbar == "" && city != "0")
            {
                BusinessList.DataSource = fdp.getBusinessList(city);
                BusinessList.DataBind();
            }
            else if(city == "0" && searchbar != "")
            {
                BusinessList.DataSource = fdp.getBusinessListbycity(searchbar);
                BusinessList.DataBind();
            }

            if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
            }


        }

        protected void Buttons_Click(object sender, EventArgs e)
        {
            string city;
            if (locati != null)
                city = locati;
            else
                city = SelectState.SelectedItem.Value;


            string searchbar = SearchBox.Text;
            LinkButton Button1 = (LinkButton)sender;
            

            BusinessList.DataSource = fdp.getBusinessListbyCategory(searchbar, city, Button1.CommandArgument.ToString());
            BusinessList.DataBind();
            catid = Button1.CommandArgument.ToString();
            if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
            }
        }

        protected void BusinessList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

                SqlDataAdapter komut = new SqlDataAdapter("SELECT bt.typeID, t.typeName FROM [business].businessinfo b INNER JOIN [business].businessType bt on b.bID = bt.bID INNER JOIN businessTypes t on bt.typeID = t.typeID where b.bID=" + Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "bID")), con);
                con.Open();
            DataTable dt = new DataTable();
            komut.Fill(dt);
            Repeater rp = (Repeater)e.Item.FindControl("Repeater2");

            rp.DataSource = dt;
            rp.DataBind();

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button Button1 = (Button)sender;
            Session["bID"] = Button1.CommandArgument.ToString();
            Response.Redirect("~/CustomerBusinessPage.aspx");
        }

        protected void BusinessList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        static string loc = null;
        static string loc1 = null;
        static string loc2 = null;
        protected void location_Click(object sender, EventArgs e)
        {
            
            XmlTextReader rd = new XmlTextReader("http://ip-api.com/xml");
            while (rd.Read())
            {
                if (rd.NodeType == XmlNodeType.Element)
                {
                   
                    if (rd.Name == "country")
                    {
                        rd.Read();
                        loc1 = rd.Value.ToString();
                    }
                    if (rd.Name == "city")
                    {
                        rd.Read();
                         loc2= rd.Value.ToString();


                        
                    }
                 

                }
            }
            loc = loc2 + "," + loc1;


            locati = SelectState.Items.FindByText(loc).Value;
            location.Text = loc;
            other.Visible = true;
            SelectState.Visible = false;
        }

        protected void other_Click(object sender, EventArgs e)
        {
            other.Visible = false;
            SelectState.Visible = true;
            location.Text = "My location";
            locati = null;
        }

        /*  protected void Hightlow_Click(object sender, EventArgs e)
          {
              string city = SelectState.SelectedItem.Value;
              string searchbar = SearchBox.Text;
              BusinessList.DataSource = fdp.sortbusinessList(searchbar, city, catid, 1);
              BusinessList.DataBind();
              if (Panel2.Visible == false)
              {
                  Panel2.Visible = true;
              }
          }

          protected void Lowhigh_Click(object sender, EventArgs e)
          {
              string city = SelectState.SelectedItem.Value;
              string searchbar = SearchBox.Text;
              BusinessList.DataSource = fdp.sortbusinessList(searchbar, city, catid, 0);
              BusinessList.DataBind();
              if (Panel2.Visible == false)
              {
                  Panel2.Visible = true;
              }
          }

          protected void Newold_Click(object sender, EventArgs e)
          {
              string city = SelectState.SelectedItem.Value;
              string searchbar = SearchBox.Text;
              BusinessList.DataSource = fdp.sortbusinessList(searchbar, city, catid,2);
              BusinessList.DataBind();
              if (Panel2.Visible == false)
              {
                  Panel2.Visible = true;
              }
          }*/
    }
}