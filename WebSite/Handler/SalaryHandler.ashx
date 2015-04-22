<%@ WebHandler Language="C#" Class="SalaryHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using PC.Common;

public class SalaryHandler : IHttpHandler, IRequiresSessionState
{
    string colMatch = "是否匹配";
    string colEmpCode = "工号";
    string colEmpName = "姓名";
    string colRowNum = "序号";
    string colInvalid = "无效列";
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        try
        {
            string json = string.Empty;
            string opt = context.Request.QueryString["opt"].ToString();
            switch (opt)
            {
                case "queryList":
                    json = GetGridDataJSON(context);                    
                    break;
                case "Import":
                    json = Import(context);
                    break;
                default:
                    break;
            }
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
    string Import(HttpContext context)
    {
        LCSS.Model.Salary oSalary = new LCSS.Model.Salary();
        oSalary.Sal_Add_User = "420001";//获取当前用户 @TODO
        oSalary.Sal_Org_Code = "Org01";//获取当前用户所属组织 @TODO
        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        oSalary.Sal_ID = SalaryBLL.Add(oSalary);
        //循环插入数据库（排除空数据）
        LCSS.Model.SalaryLine oSalaryLine;
        LCSS.BLL.CompensationItem CIBLL = new LCSS.BLL.CompensationItem();
        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();

        //DataTable dtValid = (DataTable)ViewState["dtValid"];
        DataTable dtValid = (DataTable)context.Session["dtValid"];
       
        IList<LCSS.Model.SalaryLine> ilSalaryLine = new List<LCSS.Model.SalaryLine>();
        foreach (DataRow dr in dtValid.Rows)
        {
            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (dc.ColumnName.Contains(colInvalid))
                    continue;
                if (dc.ColumnName == colMatch || dc.ColumnName == colEmpCode || dc.ColumnName == colEmpName || dc.ColumnName == colRowNum)
                    continue;
                if (string.IsNullOrWhiteSpace(dr[dc.ColumnName].ToString()))
                    continue;
                oSalaryLine = new LCSS.Model.SalaryLine();
                oSalaryLine.SL_CI_Code = dc.ColumnName;
                oSalaryLine.SL_Emp_Code = dr[colEmpCode].ToString();
                oSalaryLine.SL_Pay = Convert.ToDecimal(dr[dc.ColumnName].ToString());
                oSalaryLine.SL_Sal_ID = oSalary.Sal_ID;
                ilSalaryLine.Add(oSalaryLine);//SLBLL.Add(oSalaryLine);
            }
        }
        SLBLL.AddMul(ilSalaryLine);
        context.Session["dtValid"] = null;
        context.Session.Remove("dtValid");

        //返回匹配后的文件表格
        return DataToJSON.GetGridJson(dtValid);
    }
    

}