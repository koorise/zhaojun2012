//****************************************************************************************************
//            Author:          Koorise
//            DateTime:        2012/5/21 23:19:44
//            SearchMe:        http://www.Utopia-Studio.com
//            FileName:        Tools
//            Function:                
//            Description:    
//
//****************************************************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DataCollectionApp
{
    public class Tools
    {
        /// <summary>
        /// 保存图片并过滤字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFilterStr(string str)
        {
            List<string> ImgUrlsOld = imgUrl(str);
            foreach (var s in ImgUrlsOld)
            {
                string imgurl = SaveImg(ConfigurationSettings.AppSettings["targetUrl"] + s, ConfigurationSettings.AppSettings["path"]);
                str = str.Replace(s, imgurl);
            }
            return str;
        }
        /// <summary>
        /// 字符串替换
        /// </summary>
        /// <param name="aStr"></param>
        /// <param name="bStr"></param>
        /// <param name="cStr"></param>
        /// <returns></returns>
        public static string strReplace(string aStr,string bStr,string cStr)
        {
            return aStr.Replace(bStr, cStr);
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        /// <returns>图片地址</returns>
        public static string SaveImg(string url,string path)
        {
            WebClient mywebclient = new WebClient();
             
            string newfilename =  Guid.NewGuid()+".gif";
            string filepath =  AppDomain.CurrentDomain.BaseDirectory + path+"\\"+ newfilename;
            try
            {
                mywebclient.DownloadFile(url, filepath); 
            }
            catch (Exception ex)
            {
                return null;
            }
            return path + "/" + newfilename;
        }

        /// <summary>
        /// 正则获取图片链接
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static List<string> imgUrl(string htmlText)
        {
            string pattern = @"(?<=<[iI][mM][gG].*? src="")(?:http)?[^""]+(?="")";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> strs = new List<string>();
            MatchCollection matchCollection = regex.Matches(htmlText);
            foreach (Match m in matchCollection)
            {
                strs.Add(m.Value);
            }
            return strs;
        } 
        /// <summary>
        /// Unescape 字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串</returns>
        public static string unescape(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }
        /// <summary>
        /// 分组获取指定指定HTML
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="html"></param>
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
