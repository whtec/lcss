<%@ WebHandler Language="C#" Class="SalaryHandler" %>

using System;
using System.Web;
using System.Data;
using PC.Common;
public class SalaryHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        try
        {
            string json = GetGridDataJSON(context);
            context.Response.Write(json);
        }
        catch (Exception ex)
        {
            context.Response.Write("{\"msg\":\"1\",\"text\":\"执行失败:" + Microsoft.JScript.GlobalObject.escape(ex.Message) + "\"}");
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    string GetGridDataJSON(HttpContext context)
    {
        int PageSize = 20, PageIndex = 1;
        string OrderBy = string.Empty, strWhere = " 1=1 ", Org_Code = string.Empty;

        PageSize = Convert.ToInt32(context.Request.Params["pageSize"]);
        PageIndex = Convert.ToInt32(context.Request.Params["page"]);
        OrderBy = context.Request.Params["sortname"] + " " + context.Request.Params["sortorder"];
        strWhere += context.Request.Params["where"];
        //return "";
        if (string.IsNullOrWhiteSpace(OrderBy))
            OrderBy = "工号 asc";
        
        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();
        DataSet ds = SLBLL.GetListSalaryLine(PageSize, PageIndex, OrderBy, strWhere, "Org01");
        return DataToJSON.GetGridJson(ds);
    }

}