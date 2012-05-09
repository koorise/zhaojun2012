using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace mCookies
{
    /// <summary>   
    /// Cookie操作类   
    /// </summary>   
    public class Cookie
    {
        /// <summary>   
        /// 保存一个Cookie   
        /// </summary>   
        /// <param name="CookieName">Cookie名称</param>   
        /// <param name="CookieValue">Cookie值</param>   
        /// <param name="CookieTime">Cookie过期时间(小时),0为关闭页面失效</param>   
        public static void SaveCookie(string CookieName, string CookieValue, double CookieTime)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            DateTime now = DateTime.Now;
            myCookie.Value = CookieValue;

            if (CookieTime != 0)
            {
                //有两种方法，第一方法设置Cookie时间的话，关闭浏览器不会自动清除Cookie   
                //第二方法不设置Cookie时间的话，关闭浏览器会自动清除Cookie ,但是有效期   
                //多久还未得到证实。   
                myCookie.Expires = now.AddDays(CookieTime);
                if (HttpContext.Current.Response.Cookies[CookieName] != null)
                    HttpContext.Current.Response.Cookies.Remove(CookieName);

                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
            else
            {
                if (HttpContext.Current.Response.Cookies[CookieName] != null)
                    HttpContext.Current.Response.Cookies.Remove(CookieName);

                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }
        /// <summary>   
        /// 取得CookieValue   
        /// </summary>   
        /// <param name="CookieName">Cookie名称</param>   
        /// <returns>Cookie的值</returns>   
        public static string GetCookie(string CookieName)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            myCookie = HttpContext.Current.Request.Cookies[CookieName];

            if (myCookie != null)
                return myCookie.Value;
            else
                return null;
        }
        /// <summary>   
        /// 清除CookieValue   
        /// </summary>   
        /// <param name="CookieName">Cookie名称</param>   
        public static void ClearCookie(string CookieName)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            DateTime now = DateTime.Now;

            myCookie.Expires = now.AddYears(-2);

            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
        /// <summary>
        /// 检测MD5值
        /// </summary>
        /// <param name="aWords">客户端字段名称</param>
        /// <param name="MD5Cookies">MD5字段名称</param>
        /// <returns>没有登录=0；检测通过=1；非法登录=-1</returns>
        public static int MD5CookiesCheck(string aWords,string MD5Cookies)
        {
            if(GetCookie(aWords)==null || GetCookie(MD5Cookies)==null)
            {
                return 0;//没有登录
            }
            string _md5Str = GetCookie(aWords)+HttpContext.Current.Request.UserHostAddress + Config.c;
            string md5Str = FormsAuthentication.HashPasswordForStoringInConfigFile(_md5Str, "MD5");
            if(md5Str==GetCookie(MD5Cookies))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// MD5Cookies 生成String
        /// </summary>
        /// <param name="cKeys">客户端key值</param> 
        public static string MD5CookiesSet(string cKeys)
        {
            string _md5Str = cKeys + HttpContext.Current.Request.UserHostAddress + Config.c;
            string md5Str = FormsAuthentication.HashPasswordForStoringInConfigFile(_md5Str, "MD5");
            return md5Str;
        }
    }
}