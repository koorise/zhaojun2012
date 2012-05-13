using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WangxiaoCN;
using Ext.Net;
using Panel = System.Web.UI.WebControls.Panel;
using TreeNode = Ext.Net.TreeNode;

public partial class Admin_Add : System.Web.UI.Page
{
    private TreeNode root;
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

        var win = new Window
        {
            ID = "Window1",
            Title = "权限细分",
            Width = Unit.Pixel(600),
            Height = Unit.Pixel(400),
            Modal = true,
            Collapsible = true,
            Maximizable = true,
            Hidden = true
        };

        win.AutoLoad.Url = "~/Admin/Powerpage.aspx?adminID=" + adminID;
        win.AutoLoad.Mode = LoadMode.IFrame;

        win.Render(this.Form);
        win.Show();
         
       
    }
}