using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using WangxiaoCN;
using TreeNode = Ext.Net.TreeNode;

public partial class Admin_PowerPage : System.Web.UI.Page
{
    private TreeNode root;
    protected void Page_Load(object sender, EventArgs e)
    {
        string adminID = Request["adminID"];
        var q = from c in WXAdminPowerTree.All()
                where c.AdminID == int.Parse(adminID)
                select c;
        List<string> strs = new List<string>();
        foreach (var str in q)
        {
            strs.Add(str.GGID.ToString());
        }
        TreeBind(strs);
    }
    protected void TreeBind(List<string> strs)
    {
        //TreePanel1.ClearContent();
        //TreePanel1.Listeners.Click.Handler = DropDownField1.ClientID + ".setValue(node.text,false);";
        root = new Ext.Net.TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;

        TreePanel1.Root.Add(root);
        TreeNodes(root, Config.g, strs);

         
    }
    protected void TreeNodes(Ext.Net.TreeNode t, Guid guid, List<string> strs)
    {
        var q = from c in WXSysExamCategory.All()
                where c.PID == guid
                select c;
        foreach (var wx in q)
        {
            ThreeStateBool chk = ThreeStateBool.False;
            Ext.Net.TreeNode tn = new TreeNode();
            tn.NodeID = wx.GID.ToString();
            tn.Text = wx.className;
            
            if (strs.Contains(wx.GID.ToString()))
            {
                chk = ThreeStateBool.True;
            }
            tn.Checked = chk;
            if (guid == Config.g)
            {
                root.Nodes.Add(tn);
            }
            else
            {
                t.Nodes.Add(tn);
            }
            TreeNodes(tn, wx.GID, strs);
        }
    }
    protected  void BtnAdd(object s , DirectEventArgs e )
    {
        WXAdminPowerTree.Delete(x=>x.AdminID==int.Parse(Request["adminID"]));
        foreach (var v in TreePanel1.CheckedNodes)
        {
            Guid gg=new Guid(v.NodeID);
            WXAdminPowerTree wpt = new WXAdminPowerTree();
            wpt.GID = Guid.NewGuid();
            wpt.AdminID = int.Parse(Request["adminID"]);
            wpt.GGID = gg;
            wpt.CURD = 7;
            wpt.Save();
        }
        X.Msg.Notify("提示", "操作完毕").Show();
    }
}