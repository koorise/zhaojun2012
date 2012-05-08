using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WangxiaoCN;
using Ext.Net;

public partial class Admin_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnAdd_Click(object s,DirectEventArgs e)
    {
        if (txtPassWD1.Text.Length < 5)
        {
            X.Msg.Alert("错误", "密码长度小于6！").Show();
        }
        else
        {
            if (txtPassWD1.Text == txtPassWD2.Text)
            {
                WXAdminUser w = new WXAdminUser();
                w.GID = Guid.NewGuid();
                w.AdminUserName = txtUsername.Text;
                w.AdminPassWord = txtPassWD1.Text;
                w.AdminLevelID = 1;
                w.Save();
                Store1.DataBind();
            }
            else
            {
                X.Msg.Alert("错误", "两次输入密码不一致！").Show();
            }
        }

    }
    protected void BtnCMD_Click(object s, DirectEventArgs e)
    {
        string adminID = e.ExtraParams["AdminID"].ToString();
        Window1.Show();
    }
}