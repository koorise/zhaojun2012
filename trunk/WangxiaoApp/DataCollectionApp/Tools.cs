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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataCollectionApp
{
    public class Tools
    {
        /// <summary>
        /// Unescape 字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串</returns>
        public static string unescape(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);

            //StringBuilder sb = new StringBuilder();
            //int len = str.Length;
            //int i = 0;
            //while (i != len)
            //{
            //    if (Uri.IsHexEncoding(str, i))
            //        sb.Append(Uri.HexUnescape(str, ref i));
            //    else
            //        sb.Append(str[i++]);
            //}
            //return sb.ToString(); 

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
