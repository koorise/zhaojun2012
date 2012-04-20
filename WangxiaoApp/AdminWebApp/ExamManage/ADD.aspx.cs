using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using WangxiaoCN;
using TreeNode = Ext.Net.TreeNode;

public partial class ExamManage_ADD : System.Web.UI.Page
{
    private TreeNode root;
    protected void Page_Load(object sender, EventArgs e)
    {
        TreeBind();
        Store1_DataBind();
    }
    protected void Store1_DataBind()
    {
        var q = from c in vwExamPaperExamCategory.All()
                orderby c.ID descending 
                select c;
        Store1.DataSource = q;
        Store1.DataBind();
    }
    protected void TreeBind()
    {

        TreePanel1.Listeners.Click.Handler = DropDownField1.ClientID + ".setValue(node.text,false);" + txtClassGID.ClientID + ".setValue(node.id,false);";

        root = new TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;
        
        TreePanel1.Root.Add(root);
        TreeNodes(root, Config.g);

        root = new TreeNode(Config.g.ToString(), "Root", Icon.FolderHome);
        root.Expanded = true;
        TreePanel2.Root.Add(root);
        TreePanel2.Listeners.Click.Handler = DropDownField2.ClientID + ".setValue(node.text,false);";
        TreeNodes2(root, Config.g);
    }
    
    protected void TreeNodes2(TreeNode t, Guid guid)
    {
        var q = from c in WXSysExamCategory.All()
                where c.PID == guid
                select c;
        foreach (var wx in q)
        {
            TreeNode tn = new TreeNode();
            tn.NodeID = wx.path.ToString();
          
            tn.Text = wx.className;

            if (guid == Config.g)
            {
                root.Nodes.Add(tn);
            }
            else
            {
                t.Nodes.Add(tn);
            }
            TreeNodes2(tn, wx.GID);
        }
    }
    protected void SearchClick(object s,DirectEventArgs e)
    {
        string path = e.ExtraParams["SelectedID"].ToString();
        var q = from c in vwExamPaperExamCategory.All()
                where c.path.StartsWith(path)
                select c;
        Store1.DataSource = q;
        Store1.DataBind();
    }
    protected void TreeNodes(TreeNode t, Guid guid)
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
    protected void Store1_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        Store1_DataBind();
    }
    protected void ClearGrid(object s ,DirectEventArgs e)
    {
        RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;
        sm.SelectedRows.Clear();
        sm.UpdateSelection();
    }
    protected void RowSelect(object sender, DirectEventArgs e)
    {
        Guid ExamGID = new Guid(e.ExtraParams["ExamGID"].ToString());
        var q = vwExamPaperExamCategory.SingleOrDefault(x => x.ExamGID == ExamGID) ;
                 
        this.FormPanel1.SetValues(new
                                      {
                                          q.ExamGID,
                                          q.className,
                                          q.ClassGID,
                                          q.eTitle,
                                          q.pName,
                                          q.eYear,
                                          q.eStars,
                                          q.eTotalScore,
                                          q.ePassingScore,
                                          q.eFrom,
                                          q.eHot,
                                          q.ePoints
                                      });
    }
    protected void BtnAdd(object s,DirectEventArgs e)
    {
        Guid ExamGID = Guid.NewGuid();
        Guid ClassGID = new Guid(txtClassGID.Value.ToString());
        WXExamPaper wx = new WXExamPaper();
        wx.ExamGID = ExamGID;
        wx.ClassGID = ClassGID;
        wx.PvcID = int.Parse(ComboBox2.SelectedItem.Value);
        wx.eTitle = txteTitle.Text;
        wx.eYear = int.Parse(ComboBox1.SelectedItem.Value);
        wx.eStars = int.Parse(txteStars.Text);
        wx.eTotalScore = int.Parse(txteTotalScore.Text);
        wx.ePassingScore = int.Parse(txtePassingScore.Text);
        wx.eFrom = txteFrom.Text;
        wx.eHot = int.Parse(txteHot.Text);
        wx.ePoints = int.Parse(txtePoints.Text);
        wx.Save();
        Store1_DataBind();
        X.Msg.Notify("添加成功", "试题："+txteTitle.Text).Show();


    }
    protected  void BtnEdit(object s, DirectEventArgs e)
    {
        Guid ExamGID = new Guid(txtExamGID.Text);
        Guid ClassGID = new Guid(txtClassGID.Value.ToString());
        WXExamPaper wx = new WXExamPaper(x=>x.ExamGID==ExamGID); 
        wx.ClassGID = ClassGID;
        //wx.PvcID = int.Parse(ComboBox2.SelectedItem.Value);
        wx.eTitle = txteTitle.Text;
        wx.eYear = int.Parse(ComboBox1.SelectedItem.Value);
        wx.eStars = int.Parse(txteStars.Text);
        wx.eTotalScore = int.Parse(txteTotalScore.Text);
        wx.ePassingScore = int.Parse(txtePassingScore.Text);
        wx.eFrom = txteFrom.Text;
        wx.eHot = int.Parse(txteHot.Text);
        wx.ePoints = int.Parse(txtePoints.Text);
        wx.Save(); 
        ClearGrid(s, e);
        X.Msg.Notify("修改成功", "试题：" + txteTitle.Text).Show();
    }
}