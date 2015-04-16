<%@ WebHandler Language="C#" Class="SalaryHandler" %>

using System;
using System.Web;
using System.Data;
using PC.Common;
public class SalaryHandler : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        try
        {
            string json = GetGridDataJSON();
            context.Response.Write(json);
        }
        catch (Exception ex)
        {
            context.Response.Write("{\"msg\":\"1\",\"text\":\"执行失败:" + Microsoft.JScript.GlobalObject.escape(ex.Message) + "\"}");
        }
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    string GetGridDataJSON()
    {
        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();
        DataSet ds= SLBLL.GetListSalaryLine(20, 1, " Emp_Code,Sal_Add_Time desc ", " 1=1","Org01");
        return DataToJSON.GetGridJson(ds);
    }

}