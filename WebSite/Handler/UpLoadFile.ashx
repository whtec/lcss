<%@ WebHandler Language="C#" Class="UpLoadFile" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Data;
using LCSS.Model;
using PC.Common;

public class UpLoadFile : IHttpHandler, IRequiresSessionState
{
    //string colMatch = "是否匹配";
    //string colEmpCode = "工号";
    //string colEmpName = "姓名";
    //string colRowNum = "序号";
    //string colInvalid = "无效列";
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain"; 不能指定，否则不会回调
        try
        {
            string json = ReadExcel(context);
            //-----------------------返回结果---------------------------------- 
            //sHtml = context.Server.UrlEncode(sHtml);
            context.Response.Write("<script>window.parent.uploadFile(true," + json + ");</script>");

        }
        catch (Exception ex)
        {
            //context.Response.Write("<script>window.parent.uploadFile(false,'1');</script>");
            context.Response.Write("<script>window.parent.uploadFile(false,'" + Microsoft.JScript.GlobalObject.escape(ex.ToString()) + "');</script>");
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    string ReadExcel(HttpContext context)
    {
        HttpPostedFile file1 = null;
        if (context.Request.Files.Count > 0)
        {
            file1 = context.Request.Files[0];
        }
        string xlsPath = FileOper.objFileOper.uploadFile(file1);

        DataTable dtExcel = ExcelHelper.ExcelToDataTableByNPOI(null, xlsPath, true);
        if (dtExcel == null)
        {
            throw new Exception("无法读取文件，请检查文件是否正确！");
        }

        //dtExcel.Columns.Add(new DataColumn(colMatch, System.Type.GetType("System.Boolean")));
        dtExcel.Columns.Add(new DataColumn(ConstClass.colMatch, System.Type.GetType("System.String")));
        dtExcel.Columns.Add(new DataColumn(ConstClass.colEmpCode, System.Type.GetType("System.String")));
        //自动匹配姓名或工号
        LCSS.BLL.Employees emp = new LCSS.BLL.Employees();
        string name = string.Empty;
        string code = string.Empty;
        foreach (DataRow dr in dtExcel.Rows)
        {
            name = dr[ConstClass.colEmpName].ToString();
            code = emp.GetCodeByName(name);
            if (string.IsNullOrEmpty(code))
            {
                dr[ConstClass.colMatch] = "否";//false;
            }
            else
            {
                dr[ConstClass.colMatch] = "是";//true;
                dr[ConstClass.colEmpCode] = code;
            }
        }
        LoginInfo oLoginInfo = (LoginInfo)context.Session[PageSessionName.LoginObject];
        //放在gvExcel绑定前，dtExcel数据貌似被改变，只含筛选后结果
        int errCount = 0;
        System.Text.StringBuilder errColName = new System.Text.StringBuilder();
        LCSS.BLL.CompensationItem CIBLL = new LCSS.BLL.CompensationItem();
        DataTable dtTemp = dtExcel.Copy();
        for (int i = 0; i < dtExcel.Columns.Count; i++)
        {
            //排除固定列
            if (dtExcel.Columns[i].ColumnName == ConstClass.colMatch || dtExcel.Columns[i].ColumnName == ConstClass.colEmpCode || dtExcel.Columns[i].ColumnName == ConstClass.colEmpName || dtExcel.Columns[i].ColumnName == ConstClass.colRowNum)
                continue;
            //string SL_CI_Code = CIBLL.GetCodeByName(dtExcel.Columns[i].ColumnName, oLoginInfo.OrgCode);
            LCSS.Model.CompensationItem model = CIBLL.GetModelByName(dtExcel.Columns[i].ColumnName, oLoginInfo.OrgCode);
            if (model == null || string.IsNullOrEmpty(model.CI_Code))
            {
                errCount++;
                dtExcel.Columns[i].ColumnName = ConstClass.colInvalid + errCount + ":" + dtExcel.Columns[i].ColumnName;
                dtTemp.Columns[i].ColumnName = ConstClass.colInvalid + errCount;
                errColName.Append("," + dtTemp.Columns[i].ColumnName);
            }
            else
            {
                //if (ConstClass.minusType.Contains(model.CI_Type))
                //    dtTemp.Columns[i].ColumnName = ConstClass.minusLabel + model.CI_Code + ConstClass.colCutOff + dtExcel.Columns[i].ColumnName;
                //else
                    dtTemp.Columns[i].ColumnName = model.CI_Code + ConstClass.colCutOff + dtExcel.Columns[i].ColumnName;
            }
        }
        //缓存表删除无效列
        if (errColName.Length > 0)
        {
            errColName.Remove(0, 1);
            string[] colsName = errColName.ToString().Split(',');
            foreach (string colname in colsName)
            {
                dtTemp.Columns.Remove(colname);
            }
        }
        //缓存用编号做列名的表，并且只保存有效行
        DataView dvValid = dtTemp.DefaultView;
        dvValid.RowFilter = ConstClass.colMatch + "='是'";//"=true";
        context.Session["dtValid"] = dvValid.ToTable();
        //返回匹配后的文件表格
        return DataToJSON.GetGridJson(dtExcel);
    }


}