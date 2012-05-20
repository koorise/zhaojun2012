using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WangxiaoCN;

namespace DataCollectionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            Guid guid = Guid.NewGuid();
            Guid cGuid=new Guid("85F3F1E6-13A4-4BDA-903A-C5D6106343DF");
            InsertData(textBox1.Text,cGuid,cGuid.ToString(),1,textBox2.Text);
             
        }
        public void InsertData(string ksid,Guid pid,string path,int isdeep,string classname)
        {

            WXSysExamCategory w = new WXSysExamCategory();
            w.GID = Guid.NewGuid();
            w.PID = pid;
            w.className = classname;
            w.path = path + "|" + w.GID.ToString();
            w.isDeep = isdeep;
            w.ksID = int.Parse(ksid);
            w.Save();

            
            string aHtml = getContent("http://ks.233.com/" + ksid + "/");
            string bHtml = GetHtml("<div class=\"contlist\">", "</div>", aHtml);
            if (bHtml.IndexOf(@"/" + ksid + "/") == -1)
            {
                List<string> _classname = GetHtmls("\">", "</A>", bHtml);
                List<string> _ksid = GetHtmls("\"/", "/\"", bHtml);

                int i = 0;
                foreach (var s in _classname)
                {
                    InsertData(_ksid[i], w.GID, path, isdeep + 1, s);
                    i++;
                }
            }

        }
        private static string getContent(string Url)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求  
                request.Timeout = 30000;
                //设置连接超时时间  
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("GB2312");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch
            {
                throw;
            }
            return strResult;
        }
        public static string GetHtml(string start, string end, string html)
        {
            string ret = string.Empty;
            try
            {
                string pattern = string.Format("{0}(?<g>(.|[\r\n])+?)?{1}", start, end);//匹配URL的模式,并分组
                ret = Regex.Match(html, pattern).Groups["g"].Value;

            }
            catch { }

            return ret;
        }
        /// <summary>
        /// 返回匹配多个的集合值
        /// </summary>
        /// <param name="start">开始html tag</param>
        /// <param name="end">结束html tag</param>
        /// <param name="html">html</param>
        /// <returns></returns>
        public static List<string> GetHtmls(string start, string end, string html)
        {
            List<string> list = new List<string>();
            try
            {
                string pattern = string.Format("{0}(?<g>(.|[\r\n])+?){1}", start, end);//匹配URL的模式,并分组
                MatchCollection mc = Regex.Matches(html, pattern);//满足pattern的匹配集合
                if (mc.Count != 0)
                {
                    foreach (Match match in mc)
                    {
                        GroupCollection gc = match.Groups;
                        list.Add(gc["g"].Value);
                    }
                }
            }
            catch { }
            return list;
        }
    }
}
