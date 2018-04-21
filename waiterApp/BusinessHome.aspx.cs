using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace waiterApp
{
    public partial class BusinessHome : System.Web.UI.Page
    {
        fillDropDown filldropdownlist = new fillDropDown();
        PagedDataSource pagesource;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = filldropdownlist.listReservations(1, 1); // 1 yerine session dan gelen veri yazolacak -- seçilen restoranın numarası
            pagesource = new PagedDataSource();
            pagesource.DataSource = ds.Tables[0].DefaultView;
            pagesource.PageSize = 10;
            pagesource.AllowPaging = true;

            DataList1.DataSource = pagesource;
            DataList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("viewReservations.aspx", true);
        }
    }
}