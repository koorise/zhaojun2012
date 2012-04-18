using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using WangxiaoCN;
public partial class Dictionary_year : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
           BindData();
        }
    }
    private void BindData()
    {
        var q = from c in WXSysYear.All()
                select c;
        Store1.DataSource = q;
        Store1.DataBind();
    }

    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        this.BindData();
    } 
    protected void  BtnDel(object s ,DirectEventArgs e)
    {
        string id = e.ExtraParams["CID"].ToString();
        WXSysYear.Delete(x => x.ID == int.Parse(id));
        BindData();
        X.Msg.Notify("提示", "删除成功！").Show();
        
    }
    protected void BtnAdd(object s,DirectEventArgs e)
    {
        WXSysYear wx = new WXSysYear();
        wx.Years = int.Parse(txtYears.Text);
        wx.Save(); 
        BindData();
        X.Msg.Notify("提示", "添加成功！").Show();
    }
    [DirectMethod(Namespace = "CompanyX")]
    public void AfterEdit(int id, string field, string oldValue, string newValue, object customer)
    {
        string message = "<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

        // Send Message...
        X.Msg.Notify("编辑成功 #" + id.ToString(), string.Format(message, id, field, oldValue, newValue)).Show();
        WXSysYear wx = new WXSysYear(x=>x.ID==id);
        wx.Years = int.Parse(newValue);
        wx.Save();

        this.GridPanel1.Store.Primary.CommitChanges();
    }
}