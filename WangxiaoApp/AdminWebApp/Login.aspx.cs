using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SubSonic;
using WangxiaoCN;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Cookies.Clear("cGID");
        //Cookies.Clear("cMD5");
        switch (mCookies.Cookie.MD5CookiesCheck("cGID", "cMD5"))
        {
            case 1:
                Response.Redirect("~/default.aspx");
                break;
            default: break;

        }
    }
     protected void btnLogin_Click(object sender, DirectEventArgs e)
     {
         //bool result = WXAdminUser.Exists(x => x.AdminUserName == txtUsername.Text && x.AdminPassWord == txtPasswd.Text);
         var q = from c in WXAdminUser.All()
                 where c.AdminUserName == txtUsername.Text && c.AdminPassWord == txtPasswd.Text
                 select c;
         if(q.Count()!=0)
         {
             mCookies.Cookie.SaveCookie("cGID",q.First().GID.ToString(),0);
             mCookies.Cookie.SaveCookie("cMD5", mCookies.Cookie.MD5CookiesSet(q.First().GID.ToString()), 0);
             Response.Redirect("~/Default.aspx");
         }
         else
         {
             X.Msg.Alert("警告","用户名或密码错误！").Show();
         }
     }
}