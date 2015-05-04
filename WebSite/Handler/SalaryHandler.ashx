<%@ WebHandler Language="C#" Class="SalaryHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PC.Common;
using LCSS.Model;

public class SalaryHandler : IHttpHandler, IRequiresSessionState
{
    //string colMatch = "是否匹配";
    //string colEmpCode = "工号";
    //string colEmpName = "姓名";
    //string colRowNum = "序号";
    //string colInvalid = "无效列";
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        try
        {
            string json = string.Empty;
            string opt = context.Request.QueryString["opt"].ToString();
            switch (opt)
            {
                case "Query":
                    json = GetGridDataJSON(context);
                    break;
                case "Import":
                    json = Import(context);
                    break;
                case "MyGzt":
                    json = GetMyGztJSON(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(json);
        }
        catch (Exception ex)
        {
            //context.Response.Write("{\"msg\":\"1\",\"text\":\"执行失败:" + Microsoft.JScript.GlobalObject.escape(ex.Message) + "\"}");
            context.Response.Write("{\"msg\":\"1\",\"text\":\"执行失败:" + ex.Message + "\"}");
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
        LoginInfo oLoginInfo = (LoginInfo)context.Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
            context.Response.Redirect("../Login.aspx");

        int PageSize = 20, PageIndex = 1;
        string OrderBy = string.Empty, strWhere = " 1=1 ", Call = string.Empty;

        PageSize = Convert.ToInt32(context.Request.Params["pageSize"]);
        PageIndex = Convert.ToInt32(context.Request.Params["page"]);
        OrderBy = context.Request.Params["sortname"] + " " + context.Request.Params["sortorder"];
        strWhere += context.Request.Params["where"];
        Call = context.Request.Params["call"];
        if (string.IsNullOrWhiteSpace(OrderBy))
            OrderBy = "统计年,统计月,工号 asc";

        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();
        DataSet ds = null;
        switch (Call)
        {
            case "1":
                ds = SLBLL.GetSalaryLineByMonth(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.OrgCode);
                break;
            case "2":
                ds = SLBLL.GetList_SalaryLineBySalary(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.OrgCode);
                break;
            case "3":
                ds = SLBLL.GetList_SalaryLineByEmployees(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.UserID);
                break;
            default:
                return "";
        }
        if (ds == null)
            return "";
        return DataToJSON.GetGridJson(ds);
    }
    string GetMyGztJSON(HttpContext context)
    {
        //throw new Exception("1");
        LoginInfo oLoginInfo = (LoginInfo)context.Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
            context.Response.Redirect("../Login.aspx");
        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();
        DataSet dsDate;
        DataSet dsGzt;
        string sKey = string.Empty;
        int iNum, iTotal, iYear, iMonth;

        iNum = int.Parse(context.Request.Params["count"]);
        dsDate = SalaryBLL.GetSalaryDateList(1, iNum, oLoginInfo.UserID);
        if (dsDate == null || dsDate.Tables.Count == 0)
            return "";

        iTotal = Convert.ToInt32(dsDate.Tables[1].Rows[0][0].ToString());
        if (iNum > iTotal)
            return "";

        iYear = Convert.ToInt32(dsDate.Tables[0].Rows[0][1].ToString());
        iMonth = Convert.ToInt32(dsDate.Tables[0].Rows[0][2].ToString());
        dsGzt = SLBLL.GetMyGongzitiao(iYear, iMonth, oLoginInfo.UserID);
        if (dsGzt == null || dsGzt.Tables.Count == 0)
            return "";

        //return JSONHelper.TableToJson(ds.Tables[0]);
        Dictionary<string, StringBuilder> dicHtml = new Dictionary<string, StringBuilder>();
        foreach (DataRow dr in dsGzt.Tables[0].Rows)
        {
            sKey = dr["CT_NAME"].ToString();
            if (!dicHtml.ContainsKey(sKey))
                dicHtml[sKey] = new StringBuilder();
            decimal Money = decimal.Parse(dr["Money"].ToString());
            if (Money >= 0)
                dicHtml[sKey].AppendFormat("<li>{0} <span>{1}</span></li>", dr["CI_Name"].ToString(), Money.ToString("F2"));
            else
                dicHtml[sKey].AppendFormat("<li>{0} <span class=\"red\">{1}</span></li>", dr["CI_Name"].ToString(), Math.Abs(Money).ToString("F2"));
        }
        StringBuilder sHtml = new StringBuilder();
        sHtml.Append("<li>");
        sHtml.AppendFormat("<time class=\"cbp_tmtime\" datetime=\"\"><span>{0}年</span> <span>{1}月</span></time>", iYear.ToString(), iMonth.ToString());
        sHtml.Append("<div class=\"cbp_tmicon\"></div><div class=\"cbp_tmlabel\">");
        sHtml.AppendFormat("<h4>{0}<small>序号：{1}</small></h4>", oLoginInfo.UserName, iNum.ToString());
        sHtml.Append("<div class=\"pay-content\">");
        foreach (string key in dicHtml.Keys)
        {
            sHtml.Append("<div class=\"pay-base\">");
            sHtml.AppendFormat("<h5>{0}</h5><ul>{1}</ul>", key, dicHtml[key].ToString());
            sHtml.Append("</div>");
        }

        sHtml.Append("</div>");

        sHtml.Append("<div class=\"pay-total\">");
        sHtml.Append("<div class=\"pay-base\">");
        sHtml.Append("<h5>合计金额</h5>");
        sHtml.Append("<ul>");
        foreach (DataRow dr in dsGzt.Tables[1].Rows)
        {
            sHtml.AppendFormat("<li>{0} <span>{1}</span></li>", dr["V_SLTG_CT_NAME"].ToString(), decimal.Parse(dr["V_SLTG_SL_Pay"].ToString()).ToString("C"));
        }
        sHtml.Append("</ul>");
        sHtml.Append("</div>");
        sHtml.Append("</div>");
        sHtml.Append("</li>");

        return sHtml.ToString();//DataToJSON.GetGridJson(ds);
    }

    string Import(HttpContext context)
    {
        LoginInfo oLoginInfo = (LoginInfo)context.Session[PageSessionName.LoginObject];

        LCSS.Model.Salary oSalary = new LCSS.Model.Salary();
        oSalary.Sal_Add_User = oLoginInfo.LoginID;//获取当前用户
        oSalary.Sal_Org_Code = oLoginInfo.OrgCode;//获取当前用户所属组织
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
                if (dc.ColumnName.Contains(ConstClass.colInvalid))
                    continue;
                if (dc.ColumnName == ConstClass.colInvalid || dc.ColumnName == ConstClass.colMatch || dc.ColumnName == ConstClass.colEmpCode || dc.ColumnName == ConstClass.colEmpName || dc.ColumnName == ConstClass.colRowNum)
                    continue;
                if (string.IsNullOrWhiteSpace(dr[dc.ColumnName].ToString()))
                    continue;

                string[] colname = dc.ColumnName.Split(ConstClass.colCutOff);

                oSalaryLine = new LCSS.Model.SalaryLine();
                oSalaryLine.SL_Emp_Code = dr[ConstClass.colEmpCode].ToString();
                oSalaryLine.SL_Sal_ID = oSalary.Sal_ID;
                oSalaryLine.SL_Pay = Convert.ToDecimal(dr[dc.ColumnName].ToString());
                oSalaryLine.SL_CI_Code = colname[0];
                if (colname[0].Contains(ConstClass.minusLabel))
                {
                    oSalaryLine.SL_Pay = -oSalaryLine.SL_Pay;
                    oSalaryLine.SL_CI_Code = colname[0].Remove(0, 1);
                }

                ilSalaryLine.Add(oSalaryLine);//SLBLL.Add(oSalaryLine);
            }
        }
        foreach (DataColumn dc in dtValid.Columns)
        {
            if (dc.ColumnName.Contains(ConstClass.colInvalid))
                continue;
            if (dc.ColumnName == ConstClass.colInvalid || dc.ColumnName == ConstClass.colMatch || dc.ColumnName == ConstClass.colEmpCode || dc.ColumnName == ConstClass.colEmpName || dc.ColumnName == ConstClass.colRowNum)
                continue;

            string[] colname = dc.ColumnName.Split(ConstClass.colCutOff);
            dc.ColumnName = colname[1];
        }

        SLBLL.AddMul(ilSalaryLine);
        context.Session["dtValid"] = null;
        context.Session.Remove("dtValid");

        //返回匹配后的文件表格
        return DataToJSON.GetGridJson(dtValid);
    }
}