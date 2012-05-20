using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WangxiaoCN;
using SubSonic;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WXAdminUser wx=new WXAdminUser();
        wx.GID = Guid.NewGuid();
        wx.AdminUserName = "AAA";
    }
}