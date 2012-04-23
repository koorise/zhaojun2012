using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SubSonic.Query;
using WangxiaoCN;
public partial class ExamManage_AddItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
    } 
    protected void Store1_DataBind()
    {
        var q = from c in vwExamPaperExamCategory.All()
                orderby c.ID descending
                select c;
        Store1.DataSource = q;
        Store1.DataBind();
    }
    protected void Store1_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        Store1_DataBind();
    }
    protected void Store2_onRefreshData(object s,StoreRefreshDataEventArgs e)
    {
        string id = e.Parameters["ExamID"];
        var q = from c in WXExamDetail.All()
                where c.ExamGID == new Guid(id)
                select c;
        Store2.DataSource = q;
        Store2.DataBind();

    }
    protected void BtnAdd_Click(object s,DirectEventArgs e)
    {

        WXExamDetail wx = new WXExamDetail();
        wx.QGID = Guid.NewGuid();
        wx.ExamGID = new Guid(txtExamGID.Text);
        wx.qContent = txtqContent.Text;
        wx.qType = int.Parse(txtqType.SelectedItem.Value);
        wx.qSelectNum = int.Parse(txtqSelectNum.SelectedItem.Value);
        wx.qOrderNum = int.Parse(txtqOrderNum.Text);
        if (int.Parse(txtqType.SelectedItem.Value) != 4)
        {
            string str = "";
            foreach (var i in txtqAnswer1.SelectedItems)
            {
                str += i.Value+",";
            }
            wx.qAnswer = str.Substring(0, str.Length - 1);

        }
        else
        {
            wx.qAnswer = txtqAnswer2.Text;
        }
        wx.Save();
        var qq = from cc in WXExamDetail.All()
                 where cc.ExamGID == new Guid(txtExamGID.Text)
                 select cc;
        Store2.DataSource = qq;
        Store2.DataBind();
    }
    protected void GridPanel1_Selected(object s,DirectEventArgs e)
    {
        RowSelectionModel sm = this.GridPanel1.SelectionModel.Primary as RowSelectionModel;
        foreach (SelectedRow row in sm.SelectedRows)
        {
            txtExamGID.Text = row.RecordID;
            var q = from c in WXExamDetail.All()
                    select c;
            txtqOrderNum.Text = (q.Count(x => x.ExamGID == new Guid(row.RecordID)) + 1).ToString();
            var qq = from cc in WXExamDetail.All()
                    where cc.ExamGID == new Guid(row.RecordID) 
                    select cc;
            Store2.DataSource = qq;
            Store2.DataBind();
            
        }
         
        
    }
}