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
             TreePanel tree = new TreePanel();
             this.PlaceHolder1.Controls.Add(tree);
               
             tree.ID = "TreePanel1";
             tree.Width = Unit.Pixel(300);
             tree.Region = Region.West;
             tree.Icon = Icon.BookOpen;
             tree.Title = "分类目录";
             tree.AutoScroll = true;
             tree.Listeners.Click.Handler = txtParent.ClientID + ".setValue(node.id+'-'+node.text,false);" ;
              
            root = new TreeNode("0","Root",Icon.FolderHome);
            root.Expanded = true;
            
            tree.Root.Add(root); 
            TreeNodes(root,0);
        }
    }
    public void TreeNodes(TreeNode t,int bigid)
    {
        var q = from c in WXSysExamCategory.All()
                where c.ID == bigid
                select c;
        foreach (var wx in q)
        {
            TreeNode tn = new TreeNode();
            tn.NodeID = wx.ID.ToString();
            tn.Text = wx.className;
           
            if(bigid==0)
            {
                root.Nodes.Add(tn); 
            }
            else
            {
                t.Nodes.Add(tn);
            }
            TreeNodes(tn, wx.ID);
        } 
    }
    protected void btn_Click1(object s, DirectEventArgs e)
    {
        int ID = int.Parse(txtSelf.Text.Split('-')[0]);

        var q = WXSysExamCategory.SingleOrDefault(x => x.ID == ID);
         
        
        X.Msg.Alert("AA",txtParent.Text).Show();
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