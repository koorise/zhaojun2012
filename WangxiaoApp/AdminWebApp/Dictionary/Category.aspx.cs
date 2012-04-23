using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Repository;
using Ext.Net;
using WangxiaoCN;
using TreeNode = Ext.Net.TreeNode;
 
public partial class Dictionary_Category : System.Web.UI.Page
{
    private TreeNode root;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !X.IsAjaxRequest)
        {
            this.BuildTree(TreePanel1.Root);
        }
    }
    protected void TreeBind()
    {
        
        TreePanel1.Listeners.Click.Handler = txtParent.ClientID + ".setValue(node.text,false);" + txtParentID.ClientID + ".setValue(node.id,false);";

        root = new TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;

        TreePanel1.Root.Add(root);
        TreeNodes(root, Config.g);
    }
    protected void TreeNodes(TreeNode t,Guid guid)
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

    private Ext.Net.TreeNodeCollection BuildTree(Ext.Net.TreeNodeCollection nodes)
    {
        if (nodes == null)
        {
            nodes = new Ext.Net.TreeNodeCollection();
        }

        //TreePanel1.Listeners.Click.Handler = txtParent.ClientID + ".setValue(node.text,false);" + txtParentID.ClientID + ".setValue(node.id,false);";

        root = new TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;

        nodes.Add(root);
        TreeNodes(root, Config.g); 
         

        return nodes;
    }

    [DirectMethod]
    protected string RefreshMenu()
    {
        Ext.Net.TreeNodeCollection nodes = this.BuildTree(TreePanel1.Root);

        return nodes.ToJson();
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
            wx.isDeep = 1;
            wx.Save(); 
            
        }
        else
        {
            var q = WXSysExamCategory.SingleOrDefault(x => x.GID == GID);
            wx.PID = GID;
            wx.path = q.path + "|" + gg;
            wx.isDeep = 1;
            wx.Save();
            
            WXSysExamCategory w = new WXSysExamCategory(x=>x.path==q.path);
            w.isDeep = 0;
            w.Save();

        } 
       // X.Msg.Notify("成功", "增加分类成功！").Show(); 
    }

    protected void btn_Click2(object s, DirectEventArgs e)
    {
        Guid GID = new Guid(txtParentID.Text);
        WXSysExamCategory wx = new WXSysExamCategory(x=>x.GID==GID);
        wx.className = txtSelf.Text;
        wx.Save();
        X.Msg.Notify("成功", "修改该分类成功！").Show();
    }
    protected void btn_Click3(object s, DirectEventArgs e)
    {
        Guid GID = new Guid(txtParentID.Text);
        bool result = WXSysExamCategory.Exists(x => x.PID == GID);
        if(result)
        {
            X.Msg.Notify("错误", "请删除该分类下的子分类。").Show();
        }
        else
        {
            WXSysExamCategory.Delete(x=>x.GID==GID);
            X.Msg.Notify("成功", "删除该分类成功！").Show();
        }
    }
}