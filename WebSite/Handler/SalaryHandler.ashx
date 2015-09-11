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
                case "QuerySalaryDDL":
                    json = QuerySalaryDDLByDate(context);
                    break;
                case "Delete":
                    json = Delete(context);
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

        //LoginInfo oLoginInfo = new LoginInfo();
        //oLoginInfo.LoginID = "42000062";
        //oLoginInfo.OrgCode = "Org01";
        //oLoginInfo.UserID = "42000062";


        int PageSize = 20, PageIndex = 1;
        string OrderBy = string.Empty, strWhere = " 1=1 ", Call = string.Empty;

        PageSize = Convert.ToInt32(context.Request.Params["pageSize"]);
        PageIndex = Convert.ToInt32(context.Request.Params["page"]);
        OrderBy = context.Request.Params["sortname"] + " " + context.Request.Params["sortorder"];
        //strWhere += context.Request.Params["where"];
        Call = context.Request.Params["call"];
        if (string.IsNullOrWhiteSpace(OrderBy))
            OrderBy = "年度 desc,月度 desc,工号 asc";

        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();
        DataSet ds = null;
        switch (Call)
        {
            case "1":
                {
                    string ecode, year;
                    ecode = context.Request.Params["ecode"];
                    year = context.Request.Params["year"];
                    strWhere = string.Format("[工号]='{0}' and [年度]={1}",ecode,year);
                    ds = SLBLL.GetSalaryLineByMonth(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.OrgCode);
                    break;
                }                
            case "9":
                ds = SLBLL.GetSalaryLineByYear(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.OrgCode);
                break;
            case "2":
                ds = SLBLL.GetList_SalaryLineBySalary(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.OrgCode);
                break;
            case "3":
                ds = SLBLL.GetList_SalaryLineByEmployees(PageSize, PageIndex, OrderBy, strWhere, oLoginInfo.UserID);
                break;
            case "4":
                {
                    LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
                    if (CheckAuthority(oLoginInfo.LoginID, PC.Common.PageAuthorityName.ckdrls))
                    {
                        strWhere = " 1=1 ";
                    }
                    else
                    {
                        strWhere = " 工号='" + oLoginInfo.LoginID + "'";
                    }
                    ds = SalaryBLL.GetList_Salary(PageSize, PageIndex, OrderBy, strWhere);
                }
                break;
            case "5":
                {
                    string said = context.Request.Params["said"];
                    if (said == "-1")
                    {
                        string[] date = context.Request.Params["date"].ToString().Split('-');
                        int iYear = Convert.ToInt32(date[0]);
                        int iMonth = Convert.ToInt32(date[1]);
                        /*******************************************************************/
                        //简单粗暴权限控制
                        //根据账号查找是否有权限
                        string sql = @"  select count(*) from [dbo].[T_ConferAuthority]
                        where [CA_ObjCode]='{0}' or [CA_ObjCode] in (select distinct [AR_Role_Code] from [dbo].[T_Account_Role] where [AR_ACCT_LoginID]='{0}') and [CA_Aut_Code]='{1}'";
                        object obj = PC.DBUtility.DbHelperSQL.ReturnValue(string.Format(sql, oLoginInfo.LoginID, PageAuthorityName.rgcb));//同人工成本，限HR主任查看
                        int num = Convert.ToInt32(obj);
                        if (num <= 0)
                            throw new Exception("你没有访问权限！");
                        /*******************************************************************/
                        //ds = SLBLL.GetIncomeList(iYear, iMonth, oLoginInfo.UserID);
                        ds = SLBLL.GetIncomeList(iYear, iMonth, null);
                    }
                    else if (said == "0")
                    {
                        string[] date = context.Request.Params["date"].ToString().Split('-');
                        int iYear = Convert.ToInt32(date[0]);
                        int iMonth = Convert.ToInt32(date[1]);
                        ds = SLBLL.GetList_SalaryLineByEmployees3(iYear, iMonth, oLoginInfo.UserID);
                    }
                    else
                    { ds = SLBLL.GetList_SalaryLineByEmployees2(said.ToString(), oLoginInfo.UserID); }
                }
                break;
            case "7"://查看指定编次的导入列表(全范围，需有权限 @TODO 加入权限判断)
                {
                    string said = context.Request.Params["said"];
                    ds = SLBLL.GetList_SalaryLineByEmployees2(said.ToString(), "");
                }
                break;
            //case "6":
            //    {
            //        string[] date = context.Request.Params["date"].ToString().Split('-');
            //        int iYear =Convert.ToInt32(date[0]);
            //        int iMonth = Convert.ToInt32(date[1]);
            //        ds = SLBLL.GetList_SalaryLineByEmployees3(iYear, iMonth, oLoginInfo.UserID);
            //    }
            //    break;
            //case "8":
            //    {
            //        string[] date = context.Request.Params["date"].ToString().Split('-');
            //        int iYear = Convert.ToInt32(date[0]);
            //        int iMonth = Convert.ToInt32(date[1]);
            //        ds = SLBLL.GetIncomeList(iYear, iMonth, oLoginInfo.UserID);
            //    }
            //    break;
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
            context.Response.Redirect("../../Login.aspx");
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
            string styleColor = string.Empty;
            if (dr["CI_Category"].ToString().Contains(ConstClass.redLabel))
                styleColor = "class=\"red\"";
            else if (dr["CI_Category"].ToString().Contains(ConstClass.greenLabel))
                styleColor = "class=\"green\"";
            dicHtml[sKey].AppendFormat("<li>{0} <span {2}>{1}</span></li>", dr["CI_Name"].ToString(), Money.ToString("F2"), styleColor);
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
            sHtml.AppendFormat("<li>{0} <span class=\"green\">{1}</span></li>", dr["V_SLTG_CT_NAME"].ToString(), decimal.Parse(dr["V_SLTG_SL_Pay"].ToString()).ToString("C"));
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
        if (oLoginInfo == null)
            context.Response.Redirect("../Login.aspx");

        string[] date = context.Request.Params["date"].Split('-');

        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        LCSS.Model.Salary oSalary = new LCSS.Model.Salary();
        oSalary.Sal_Add_User = oLoginInfo.LoginID;//获取当前用户
        oSalary.Sal_Org_Code = oLoginInfo.OrgCode;//获取当前用户所属组织
        oSalary.Sal_Year = int.Parse(date[0]);
        oSalary.Sal_Month = int.Parse(date[1]);
        oSalary.Sal_Description = context.Request.Params["des"];
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
                //if (colname[0].Contains(ConstClass.minusLabel))
                //{
                //    oSalaryLine.SL_Pay = -oSalaryLine.SL_Pay;
                //    oSalaryLine.SL_CI_Code = colname[0].Remove(0, 1);
                //}

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

    string QuerySalaryDDLByDate(HttpContext context)
    {
        LoginInfo oLoginInfo = (LoginInfo)context.Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
            context.Response.Redirect("../Login.aspx");

        string[] date = context.Request.Params["date"].ToString().Split('-');
        int year = Convert.ToInt32(date[0]);
        int month = Convert.ToInt32(date[1]);

        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        DataSet dsSalary = SalaryBLL.GetSalaryList(year, month, oLoginInfo.UserID);
        if (dsSalary == null || dsSalary.Tables.Count == 0)
            return "";

        return JSONHelper.TableToJson(dsSalary.Tables[0]);
    }

    string Delete(HttpContext context)
    {
        string Sal_ID = context.Request.QueryString["id"].ToString();
        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        SalaryBLL.Delete(Convert.ToInt64(Sal_ID));
        return "";
    }


    /// <summary>
    /// 根据登录账号判断是否有访问权限
    /// </summary>
    bool CheckAuthority(string LoginID, string Authority_Code)
    {
        //oLoginInfo.LoginID 根据账号查找是否有权限
        string sql = @"  select count(*) from [dbo].[T_ConferAuthority]
            where [CA_ObjCode]='{0}' or [CA_ObjCode] in (select distinct [AR_Role_Code] from [dbo].[T_Account_Role] where [AR_ACCT_LoginID]='{0}') and [CA_Aut_Code]='{1}'";
        object obj = PC.DBUtility.DbHelperSQL.ReturnValue(string.Format(sql, LoginID, Authority_Code));
        int num = Convert.ToInt32(obj);
        return (num > 0) ? true : false;
    }
}