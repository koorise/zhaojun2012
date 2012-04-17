using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic.Linq.Structure;
using SubSonic.Repository;
using Ext.Net;
using WangxiaoCN;
using TreeNode = Ext.Net.TreeNode;
 
public partial class Dictionary_Category : System.Web.UI.Page
{
    private TreeNode root;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            TreeBind();
        }
    }
    protected void TreeBind()
    {
        this.PlaceHolder1.Controls.Clear();
        TreePanel tree = new TreePanel();
        this.PlaceHolder1.Controls.Add(tree);

        tree.ID = "TreePanel1";
        tree.Width = Unit.Pixel(300);
        tree.Region = Region.West;
        tree.Icon = Icon.BookOpen;
        tree.Title = "分类目录";
        tree.AutoScroll = true;
        tree.Listeners.Click.Handler = txtParent.ClientID + ".setValue(node.text,false);" + txtParentID.ClientID + ".setValue(node.id,false);";

        root = new TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;

        tree.Root.Add(root);
        TreeNodes(root, Config.g);
    }
    public void TreeNodes(TreeNode t,Guid guid)
    {
        var q = from c in WXSysExamCategory.All()
                where c.PID == guid
                select c;
        foreach (var wx in q)
        {
            TreeNode tn = new TreeNode();
            tn.NodeID = wx.GID.ToString();
            tn.Text = wx.className;

            if (guid == Config.g)
            {
                root.Nodes.Add(tn);
            }
            else
            {
                t.Nodes.Add(tn);
            }
            TreeNodes(tn, wx.GID);
        } 
    }
    protected void btn_Click1(object s, DirectEventArgs e)
    {
        Guid gg = Guid.NewGuid();
        Guid GID = new Guid(txtParentID.Text);

        WXSysExamCategory wx = new WXSysExamCategory();
        wx.GID = gg;
        wx.className = txtSelf.Text;
        if(GID==Config.g)
        {
            wx.PID = Config.g;
            wx.path = Config.g + "|" + gg;
            wx.Save();
        }
        else
        {
            var q = WXSysExamCategory.SingleOrDefault(x => x.GID == GID);
            wx.PID = q.PID;
            var qq = WXSysExamCategory.SingleOrDefault(x => x.GID == q.PID);
            wx.path = qq.path + "|" + gg;
            wx.Save(); 
        }
        TreeBind();
         
    }
    protected void btn_Click2(object s, DirectEventArgs e)
    {
        X.Msg.Alert("AA", txtParent.Text).Show();
    }
    protected void btn_Click3(object s, DirectEventArgs e)
    {
        X.Msg.Alert("AA", txtParent.Text).Show();
    }
}