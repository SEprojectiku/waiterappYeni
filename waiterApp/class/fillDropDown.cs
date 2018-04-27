using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace waiterApp
{

    public class fillDropDown
{
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        public DataTable currency()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from currency", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable languages()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from languages", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable countries()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from countries", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable states(int countryid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from states where country_id = " + countryid.ToString(), con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable menucategories()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from menucategories order by sorting asc", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable menucategories(int menuID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select mc.[catName], mc.catID from menucategories mc inner join[business].[menudetails]md on md.catID = mc.catID where md.menuID = '"+menuID+"' group by mc.catName, mc.catID", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable tabletypes()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tableTypes", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable tableTypes(int bid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            DataTable dt = new DataTable();
            using (var cmd = new SqlCommand("searchTableTypes", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(dt);
            }
            con.Close();
            return dt;
        }
        public DataTable listavaliableTables(int bid, int time, string date1, string date2, int type)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            using (var cmd = new SqlCommand("listAvaliableTables", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                cmd.Parameters.Add(new SqlParameter("@date1", date1));
                cmd.Parameters.Add(new SqlParameter("@date2", date2));
                cmd.Parameters.Add(new SqlParameter("@time", time));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                da.Fill(dt);
            }
           con.Close();
            return dt;
            
        }
        public DataSet listReservations(int bid, int resStatus)
        {

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listReservations", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                cmd.Parameters.Add(new SqlParameter("@resStatus", resStatus));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }
        public DataSet listMenus(int bid)
        {

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listMenus", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }
        public DataSet listActiveMenuitems(int bid)
        {

            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listActiveMenuitems", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }
        public DataTable listActiveMenuitemsCategories(int bid)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listActivemenuitemsCategories", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(dt);
            }
            con.Close();
            return dt;
        }
        public DataTable listActiveMenuitemswithCategories(int bid, int catid)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listActivemenuitemswithCategories", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                cmd.Parameters.Add(new SqlParameter("@catid", catid));
                da.Fill(dt);
            }
            con.Close();
            return dt;
        }
        public DataSet listSetteableTables(int bid,string date1, string date2, int time)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listSetteableTables", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                cmd.Parameters.Add(new SqlParameter("@date1", date1));
                cmd.Parameters.Add(new SqlParameter("@date2", date2));
                cmd.Parameters.Add(new SqlParameter("@time", time));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }
        public DataSet listAlltables(int bid)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listAlltables", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }
        public DataSet listComingResforcustomer(int userid)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("listcomingreservaitonsforcutomer", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@uid", userid));
                da.Fill(ds);
            }
            con.Close();
            return ds;
        }

        public DataTable SelectedCountriesStates()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select s.name+','+c.name as name,s.name,c.name,s.id from [dbo].[states] s inner join [dbo].[countries] c on c.id=s.country_id group by c.name,s.name,s.id", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable BusinessCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select typeID,typeName from businessTypes", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable getBusinessList(string Cityid,string searchbox)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress FROM business.Businessinfo s INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.bName LIKE '%" + searchbox + "%' and s.city=" + Cityid, con);
            adapter.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable getBusinessList(string Cityid)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress FROM business.Businessinfo s INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.city=" + Cityid, con);
            adapter.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable getBusinessListbycity(string searchBox)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress  FROM business.Businessinfo s INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.bName like '%" + searchBox + "%'", con);
            adapter.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable getBusinessListbyCategory(string searchbar, string city, string catid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            if (searchbar != "" && city != "1")
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' AND bt.typeID =" + catid, con);
                adapter.Fill(dt);
                con.Close();
            }
            else if (searchbar == "" && city != "1")
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.city = '" + city + "' AND bt.typeID =" + catid, con);
                adapter.Fill(dt);
                con.Close();
            }
            else if (city == "1" && searchbar != "")
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress  FROM business.Businessinfo s INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE s.bName like '%" + searchbar + "%' AND bt.typeID =" + catid, con);
                adapter.Fill(dt);
                con.Close();
            }
            else if(city == "1" && searchbar == "")
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(" SELECT st.name+','+c.name as stateName,s.bID, s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress  FROM business.Businessinfo s INNER JOIN states st on s.city = st.id INNER JOIN countries c on c.id = st.country_id WHERE bt.typeID =" + catid, con);
                adapter.Fill(dt);
                con.Close();
            }



            return dt;
        }

        /*
        public DataTable sortbusinessList(string searchbar, string city, string catid, int sortType)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            if(sortType == 0)
            {
                if (searchbar != "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' AND bt.typeID = '" + catid+"' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if(searchbar != "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND bt.typeID = '" + catid + "' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' AND bt.typeID ='" + catid + "' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE bt.typeID ='" + catid+ "' order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s order by s.avaragePrice asc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
            }
            else if(sortType == 1)
            {
                if (searchbar != "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' AND bt.typeID = '" + catid + "' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar != "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND bt.typeID = '" + catid + "' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' AND bt.typeID ='" + catid + "' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE bt.typeID ='" + catid + "' order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s order by s.avaragePrice desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
            }
            else if(sortType == 2)
            {
                if (searchbar != "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' AND bt.typeID = '" + catid + "' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar != "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND s.bName like '%" + searchbar + "%' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' AND bt.typeID = '" + catid + "' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (searchbar == "" && city != "0" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s INNER JOIN business.businessType bt ON bt.bID = s.bID WHERE s.city = '" + city + "' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar != "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE s.bName like '%" + searchbar + "%' AND bt.typeID ='" + catid + "' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid != "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s WHERE bt.typeID ='" + catid + "' order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
                else if (city == "0" && searchbar == "" && catid == "")
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(" SELECT s.bName,s.workOpen,s.workClose,s.email,s.city,s.adress, s.avaragePrice  FROM business.Businessinfo s order by s.registerDate desc", con);
                    adapter.Fill(dt);
                    con.Close(); return dt;
                }
            }
            else return dt;

            return dt;

        }
        */


        public DataSet getOrderDetails(int orderid)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("getOrderDetails", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderid", orderid));
                da.Fill(ds);
            }
            con.Close();
            return ds;

        }

        public string getOrderTotal(int orderid)
        {
            string total = "";
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand query = new SqlCommand("getOrderTotal", con);
            query.Parameters.Add("@orderid", SqlDbType.NVarChar).Value = orderid; // sessiondan gelen kullanıcı id si yazılacak
            con.Open();
            query.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = query.ExecuteReader();
            if (dr.Read())
            {
               total = dr["total"].ToString();

            }
            con.Close();
            return total;
        }

        public string getOrderDate(int orderid)
        {
            string date = "";
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand query = new SqlCommand("getOrderDate", con);
            query.Parameters.Add("@orderid", SqlDbType.NVarChar).Value = orderid; // sessiondan gelen kullanıcı id si yazılacak
            con.Open();
            query.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = query.ExecuteReader();
            if (dr.Read())
            {
                date = dr["dates"].ToString();

            }
            con.Close();
            return date;
        }

        public DataSet getOrderDetailsForBusiness(int orderid, int bid)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("getOrderDetailsForBusiness", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                cmd.Parameters.Add(new SqlParameter("@orderid", orderid));
                da.Fill(ds);
            }
            con.Close();
            return ds;

        }
        
         public DataSet getOrderDetailsForBusinessinGeneral(int bid)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (var cmd = new SqlCommand("getOrderDetailsForBusinessinGeneral", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@bid", bid));
                da.Fill(ds);
            }
            con.Close();
            return ds;

        }

    }
}