using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Cookies.Clear("cGID");
        Cookies.Clear("cMD5");
        Response.Redirect("~/login.aspx");
    }
}