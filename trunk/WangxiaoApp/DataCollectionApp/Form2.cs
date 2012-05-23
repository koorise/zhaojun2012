using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 
using zoyobar.shared.panzer;
using zoyobar.shared.panzer.web;
using zoyobar.shared.panzer.web.ib;
using System.Configuration;
using SubSonic;
using WangxiaoCN;


namespace DataCollectionApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaperUrl("916", "6", "");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var q = from c in WXSysExamCategory.All()
                    where c.isBottom == 1  
                    select c;
            foreach (var w in q)
            {
                PaperUrl(w.ksID.ToString(), "6", "");
            }
        }
        public   bool PaperUrl(string ksID,string typeid,string page)
        {
            string PaperListUrl = string.Format(ConfigurationSettings.AppSettings["PaperListUrl"], ksID, typeid, page);
            WebBrowser webBrowser=new WebBrowser();
            IEBrowser ie = new IEBrowser(webBrowser);
            ie.Navigate(PaperListUrl);
            ie.IEFlow.Wait(new UrlCondition("wait", PaperListUrl, StringCompareMode.StartWith));

            if (ie.Document.Body.InnerHtml.Contains("服务器错误"))
            {
                 return false;
            }
            // 安装 jquery 脚本.
            ie.InstallJQuery(JQuery.CodeMin);

            ie.ExecuteJQuery(JQuery.Create("'.cBlue'"), "__jAs");
            int count = ie.ExecuteJQuery<int>(JQuery.Create("__jAs").Length());

            for (int index = 0; index < count; index++)
            { 
                ie.ExecuteJQuery(JQuery.Create("__jAs").Eq(index.ToString()), "__jA");


                string PaperTitle = ie.ExecuteJQuery<string>(JQuery.Create("__jA").Text());
                string PaperID = ie.ExecuteJQuery<string>(JQuery.Create("__jA").Attr("'href'"));
                if(PaperID!=null)
                {
                    PaperID = PaperID.ToLower().Replace("http://wx.233.com/search/UserCenter/examCenter/answer.asp?PaperID=".ToLower(), "").Replace("&guest=1", "");
                }
                else
                {
                    return false;
                }
                int pid;
                if(!int.TryParse(PaperID,out pid))
                {
                    return false;
                }
                WXExamPaper wp=new WXExamPaper();
                wp.ExamGID = Guid.NewGuid();
                wp.tExamID = int.Parse(PaperID);
                wp.eTitle = PaperTitle;
                wp.tKSID = int.Parse(ksID);
                wp.Save();
            }
            //执行下一页
            
            ie.ExecuteJQuery(JQuery.Create("'.next'"), "__Nxts");
            int pCount = ie.ExecuteJQuery<int>(JQuery.Create("__Nxts").Length());
            if (pCount != 0)
            {
                ie.ExecuteJQuery(JQuery.Create("__Nxts").Eq("0"), "__Nxt");
                string url = ie.ExecuteJQuery<string>(JQuery.Create("__Nxt").Attr("'href'"));
                string pid = url.Substring(url.Length - 7, 2);
                PaperUrl(ksID, typeid, pid);
            }
            webBrowser.Dispose();
            return true;
        }
        public void PaperAdd(string PaperID,WebBrowser webBrowser)
        { 
            string PaperUrl = string.Format(ConfigurationSettings.AppSettings["PaperUrl"], PaperID);
            IEBrowser ie = new IEBrowser(webBrowser);
            ie.Navigate(PaperUrl);
            ie.IEFlow.Wait(new UrlCondition("wait", PaperUrl, StringCompareMode.StartWith));
            ie.InstallTrace();
            
            var json = ie.__GetJSON("PaperData"); 
            JArray jo = JArray.Parse(json.ToString());
            ExamPaper examPaper = new ExamPaper();
            foreach (var item in jo)
            {
                JObject j = JObject.Parse(item.ToString());
                string RulesID = j.SelectToken("RulesID").ToString();

                //试卷题型分组获取
                string ItemUrl = string.Format(ConfigurationSettings.AppSettings["ItemUrl"], PaperID, RulesID);
                IEBrowser _ie = new IEBrowser(webBrowser);
                _ie.Navigate(ItemUrl);
                _ie.IEFlow.Wait(new UrlCondition("wait", ItemUrl, StringCompareMode.StartWith));
                string jsonItem = _ie.Document.Body.InnerHtml; 
                ExamXRules examXRules = JsonConvert.DeserializeObject<ExamXRules>(jsonItem);

            }
            
        }
       

        private void Form2_Load(object sender, EventArgs e)
        {
            var q = from c in WXSysProvince.All()
                    select c;
            foreach (var wsp in q)
            {
                ComboxItem ci = new ComboxItem();
                ci.Text = wsp.pName;
                ci.Value = wsp.pID.ToString(); 
            }
        }
    }

}
