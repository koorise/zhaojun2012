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
            
            string aHtml = getContent("http://ks.233.com/"+textBox1.Text+"/");
            string bHtml = GetHtml("<div class=\"contlist\">", "</div>", aHtml);
            List<string> strs = GetHtmls("\">", "</A>", bHtml);
            List<string> strs2 = GetHtmls("\"/", "/\"", bHtml);
            
            Guid guid = Guid.NewGuid();
            Guid cGuid=new Guid("85F3F1E6-13A4-4BDA-903A-C5D6106343DF");
            WXSysExamCategory wx=new WXSysExamCategory();
            wx.GID = guid;
            wx.PID = cGuid;
            wx.className = textBox2.Text;
            wx.path = cGuid.ToString() + "|" + guid.ToString();
            wx.isDeep = 0;
            wx.ksID = int.Parse(textBox1.Text);
            wx.Save();
            int i = 0;
            foreach (var str in strs)
            {
                Guid guid1= Guid.NewGuid();

                WXSysExamCategory w= new WXSysExamCategory();
                w.GID = guid1;
                w.PID = guid;
                w.className = str;
                w.path = wx.path + "|" + guid1.ToString();
                w.isDeep = 1;
                w.ksID = int.Parse(strs2[i]);
                w.Save();

                string aHtml1 = getContent("http://ks.233.com/" + strs2[i] + "/");
                string bHtml1 = GetHtml("<div class=\"contlist\">", "</div>", aHtml1);
                List<string> _strs = GetHtmls("\">", "</A>", bHtml1);
                List<string> _strs2 = GetHtmls("\"/", "/\"", bHtml1);
                int t = 0;
                
                    foreach (var s in _strs)
                    {
                        if (_strs2.Count != strs2.Count)
                        {
                            Guid guid2 = Guid.NewGuid();
                            WXSysExamCategory w2 = new WXSysExamCategory();
                            w2.GID = guid2;
                            w2.PID = guid1;
                            w2.className = s;
                            w2.path = w.path + "|" + guid2.ToString();
                            w2.isDeep = 2;
                            w2.ksID = int.Parse(_strs2[t]);
                            w2.Save();
                        }
                        t++;
                    }
                i++;
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
