using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waiterApp
{
    public partial class CustomerBusinessPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sitbutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerSetTable.aspx", true);
        }

        protected void rezbutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerReservation.aspx", true);
        }

        protected void ViewMenubutton_Click(object sender, EventArgs e)
        {
            Server.Transfer("CustomerViewMnu.aspx", true);
        }
    }
}