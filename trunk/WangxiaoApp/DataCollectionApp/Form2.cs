using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

        private delegate int delegateItemAdd(string PaperID);
        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("试卷编号", typeof(int));
            DataColumn dc2 = new DataColumn("题目数量", typeof(string)); 
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            Thread myThread = new Thread(ExamItemAdd);
            myThread.IsBackground = true;
            myThread.Start();
            dataGridView1.DataSource = dt;  
        }

        private void ExamItemAdd()
        {
            var q = from c in WXExamPaper.All()
                    where c.tExamID>=int.Parse(textBox1.Text)
                    orderby c.tExamID ascending 
                    select c.tExamID;
            foreach (var _q in q)
            {
                delegateItemAdd delegateItem = ExamItemAddShow;
                IAsyncResult asyncResult = BeginInvoke(delegateItem, new object[] { _q.ToString() });
                while (!asyncResult.AsyncWaitHandle.WaitOne(-1, false))
                {
                    Thread.Sleep(100);
                }
            }
        }
        private  int ExamItemAddShow(string PaperID)
        {
            int sss = PaperAdd(PaperID);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;                 //   设置为选中.(index为选重的记录索引)
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;     //   设置在当前区域的第一行显示 
            DataRow dr = dt.NewRow();
            dr[0] = int.Parse(PaperID);
            dr[1] = sss; 
            dt.Rows.Add(dr); 

            //PaperUrl(ksID, typeid, page);
            return sss;
        }
        #region 委托： myDelegate

        private delegate int MyDelegate(string ksID, string typeid, string page);
         
         
        
        #endregion
        private DataTable dt = new DataTable("dt");

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("KSID", typeof(int));
            DataColumn dc2 = new DataColumn("分类", typeof(string));
            DataColumn dc3 = new DataColumn("数量", typeof(string));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3); 

            Thread myThread = new Thread(MyEvent); 
            myThread.IsBackground = true;
            myThread.Start(); 
            dataGridView1.DataSource = dt;  
             
        }

        private void MyEvent()
         {
             var q = from c in WXSysExamCategory.All()
                    where c.isBottom == 1 && c.ksID>=int.Parse(textBox1.Text)
                    orderby c.ksID ascending 
                    select c;
            WXDataCollection.Delete(x=>x.ksid>=int.Parse(textBox1.Text));
            WXExamPaper.Delete(x=>x.tKSID>=int.Parse(textBox1.Text));
             foreach (var w in q)
             {
                 MyDelegate myDelegate2 = ShowMessage;
                 IAsyncResult asyncResult2 = BeginInvoke(myDelegate2, new object[] { w.ksID.ToString(), "2", "" });
                 while (!asyncResult2.AsyncWaitHandle.WaitOne(-1, false))
                 {
                    Thread.Sleep(500);
                 }

                 MyDelegate myDelegate3 = ShowMessage;
                 IAsyncResult asyncResult3 = BeginInvoke(myDelegate3, new object[] { w.ksID.ToString(), "3", "" });
                 while (!asyncResult3.AsyncWaitHandle.WaitOne(-1, false))
                 {
                     Thread.Sleep(500);
                 }

                 MyDelegate myDelegate6 = ShowMessage;
                 IAsyncResult asyncResult6 = BeginInvoke(myDelegate6, new object[] { w.ksID.ToString(), "6", "" });
                 while (!asyncResult6.AsyncWaitHandle.WaitOne(-1, false))
                 {
                     Thread.Sleep(500);
                 }
             }
         }

        private   int ShowMessage(string ksID, string typeid, string page)
        {
           
            int sss = PaperUrl(ksID, typeid, page);
            dataGridView1.Rows[dataGridView1.Rows.Count-1].Selected = true;                 //   设置为选中.(index为选重的记录索引)
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;     //   设置在当前区域的第一行显示 
            DataRow dr = dt.NewRow();
            dr[0] = int.Parse(ksID);
            dr[1] = typeid;
            dr[2] = sss;
            dt.Rows.Add(dr);
            WXDataCollection wx = new WXDataCollection();
            wx.ksid = int.Parse(ksID);
            wx.typeid = int.Parse(typeid);
            wx.icount = sss;
            wx.intime = DateTime.Now;
            wx.Save();
            
            //PaperUrl(ksID, typeid, page);
            return sss;
        }
        #region 采集试题编号
        /// <summary>
        /// 采集试题
        /// </summary>
        /// <param name="ksID"></param>
        /// <param name="typeid"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static int PaperUrl(string ksID, string typeid, string page)
        {
            int ppp = 0;
            string PaperListUrl = string.Format(ConfigurationSettings.AppSettings["PaperListUrl"], ksID, typeid, page);
            WebBrowser webBrowser=new WebBrowser();
            IEBrowser ie = new IEBrowser(webBrowser);
            ie.Navigate(PaperListUrl);
            try
            { 
                ie.IEFlow.Wait(new UrlCondition("wait", PaperListUrl, StringCompareMode.StartWith),10);
            }
            catch (Exception)
            {
                ie.Dispose();
                webBrowser.Dispose();
                return 9999;
            }
            

            if (ie.Document.Body.InnerHtml.Contains("服务器错误"))
            {
                 ie.Dispose();
                 webBrowser.Dispose();
                 return ppp;
            }
            if(ie.Document.Body.InnerHtml.Contains("nginx"))
            {
                ie.Dispose();
                webBrowser.Dispose();
                return 9998;
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
                    ie.Dispose();
                    webBrowser.Dispose();
                    return ppp;
                }
                int pid;
                if(!int.TryParse(PaperID,out pid))
                {
                    ie.Dispose();
                    webBrowser.Dispose();
                    return ppp;
                }
                WXExamPaper wp=new WXExamPaper();
                wp.ExamGID = Guid.NewGuid();
                wp.tExamID = int.Parse(PaperID);
                wp.eTitle = PaperTitle;
                wp.tKSID = int.Parse(ksID);
                wp.ExamTypeID = int.Parse(ksID);
                wp.Save();
                ppp++;
            }
            //执行下一页
            
            ie.ExecuteJQuery(JQuery.Create("'.next'"), "__Nxts");
            int pCount = ie.ExecuteJQuery<int>(JQuery.Create("__Nxts").Length());
            if (pCount != 0)
            {
                Thread.Sleep(2000);
                ie.ExecuteJQuery(JQuery.Create("__Nxts").Eq("0"), "__Nxt");
                string url = ie.ExecuteJQuery<string>(JQuery.Create("__Nxt").Attr("'href'"));
                string pid = url.Substring(url.Length - 7, 2);
                ppp += PaperUrl(ksID, typeid, pid);
                
            }
            ie.Dispose();
            webBrowser.Dispose();
            return ppp;
        }
        #endregion

        #region 采集试题内容
        /// <summary>
        /// 采集试题内容
        /// </summary>
        /// <param name="PaperID"></param>
        /// <param name="webBrowser"></param>
        public int PaperAdd(string PaperID)
        {
            int ttt = 0;
            WebBrowser webBrowser = new WebBrowser();
            string PaperUrl = string.Format(ConfigurationSettings.AppSettings["PaperUrl"], PaperID);
            IEBrowser ie = new IEBrowser(webBrowser);
            ie.Navigate(PaperUrl);
            try
            {
                ie.IEFlow.Wait(new UrlCondition("wait", PaperUrl, StringCompareMode.StartWith),20);
            }
            catch (Exception)
            {
                
                throw;
            }
            
            ie.InstallTrace();
            
            var json = ie.__GetJSON("PaperData"); 
            JArray jo = JArray.Parse(json.ToString());
            List<ExamXRules> examXRuleses = new List<ExamXRules>();
            foreach (var item in jo)
            {
                JObject j = JObject.Parse(item.ToString());
                string RulesID = j.SelectToken("RulesID").ToString();

                //试卷题型分组获取
                string ItemUrl = string.Format(ConfigurationSettings.AppSettings["ItemUrl"], PaperID, RulesID);
                IEBrowser _ie = new IEBrowser(webBrowser);
                _ie.Navigate(ItemUrl);
                try
                {
                    _ie.IEFlow.Wait(new UrlCondition("wait", ItemUrl, StringCompareMode.StartWith),20);
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
                string jsonItem = _ie.Document.Body.InnerHtml;
                ExamXRules examXRules = JsonConvert.DeserializeObject<ExamXRules>(jsonItem);
                examXRuleses.Add(examXRules);
                _ie.Dispose();
            }
            ie.Dispose();
            webBrowser.Dispose();
            var q = WXExamPaper.All().FirstOrDefault(x => x.tExamID == int.Parse(PaperID));
                      
            Guid ExamGuid = Guid.Parse(q.ExamGID.ToString());
            foreach (ExamXRules exs in examXRuleses)
            {
                int s = int.Parse(exs.S);
                foreach (ExamRules ex in exs.Rules)
                {
                    Guid exrGuid = Guid.NewGuid();
                    WXExamRule exr = new WXExamRule();
                    exr.S_Sorts = s;
                    exr.GID = exrGuid;
                    exr.ExamGID = ExamGuid;
                    exr.RulesTitle = Tools.unescape(ex.RulesTitle);
                    exr.RulesScore = decimal.Parse(ex.RulesScore);
                    exr.RulesScoreSet = ex.RulesScoreSet;
                    exr.Save();
                    foreach (ExamItem ei in ex.examlist)
                    {
                        int selectNum =0;
                        int.TryParse(ei.SelectNum,out selectNum);
                        int orderid = 0;
                        int.TryParse(ei.OrderID, out orderid);
                        int examType = 0;
                        int.TryParse(ei.Exam_Type, out examType);
                        WXExamDetail wx= new WXExamDetail();
                        wx.RulesGID = exrGuid;
                        wx.QGID = Guid.NewGuid();
                        wx.ExamGID = ExamGuid;
                        wx.qContent = Tools.unescape(ei.Content);
                        wx.qType = examType;
                        wx.qSelectNum = selectNum;
                        wx.qOrderNum = orderid;
                        wx.qAnswer = ei.Answer;
                        wx.Analysis = Tools.unescape(ei.Analysis);
                        wx.CreateTime = DateTime.Now;
                        wx.ExamID = int.Parse(PaperID);
                        wx.ReviewCount = ei.ReviewCount;
                        wx.AnalyseNum =  ei.AnalyseNum;
                        wx.Save();
                        ttt++;
                    }
                } 
            }
            return ttt;
        }
        #endregion

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

        private void button3_Click(object sender, EventArgs e)
        {
            PaperAdd(textBox1.Text);
        }
        
    }

}
