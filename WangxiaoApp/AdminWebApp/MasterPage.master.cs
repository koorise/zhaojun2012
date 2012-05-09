using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (mCookies.Cookie.MD5CookiesCheck("cGID", "cMD5"))
        {
            case 0:
                Response.Redirect("~/login.aspx");
                break;
             
            case -1:
                Response.Redirect("~/login.aspx");
                break;
            default: break;

        }
    }
}
