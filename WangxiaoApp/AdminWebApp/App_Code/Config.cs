using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Config 的摘要说明
/// </summary>
public class Config
{
	public Config()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static Guid g
    {
        get
        {
            Guid guid = new Guid(System.Web.Configuration.WebConfigurationManager.AppSettings["g"]);
            return guid;
        }
        
    }
    public static Guid c
    {
        get
        {
            Guid guid = new Guid(System.Web.Configuration.WebConfigurationManager.AppSettings["c"]);
            return guid;
        }

    }
}