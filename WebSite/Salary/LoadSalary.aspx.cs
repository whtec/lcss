using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PC.Common;

public partial class LoadSalary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRead_ServerClick(object sender, EventArgs e)
    {
        lbl1.InnerText = File1.PostedFile.ContentType;
        //判断文件类型是否正确或者用后缀
        //判断文件大小禁止0

        //打开路径读取文件
        string xlsPath = File1.PostedFile.FileName;
        DataTable dtExcel = ExcelHelper.ExcelToDataTableByNPOI(null, xlsPath, true);
        if (dtExcel == null)
        {
            lbl1.InnerText = "提示:Excel没有可读的数据！";
            return;
        }
        //固定非薪酬项目列，后续文字用参数代替
        dtExcel.Columns.Add(new DataColumn("是否匹配", System.Type.GetType("System.Boolean")));
        dtExcel.Columns.Add(new DataColumn("工号", System.Type.GetType("System.String")));
        //自动匹配姓名或工号
        LCSS.BLL.Employees emp = new LCSS.BLL.Employees();
        string name = string.Empty;
        string code = string.Empty;
        foreach (DataRow dr in dtExcel.Rows)
        {
            name = dr["姓名"].ToString();//固定非薪酬项目列，后续文字用参数代替
            code = emp.GetCodeByName(name);
            if (string.IsNullOrEmpty(code))
            {
                dr["是否匹配"] = false;//固定非薪酬项目列，后续文字用参数代替
            }
            else
            {
                dr["是否匹配"] = true;//固定非薪酬项目列，后续文字用参数代替
                dr["工号"] = code;//固定非薪酬项目列，后续文字用参数代替
            }
        }
        gvExcel.DataSource = dtExcel;
        gvExcel.DataBind();

        //放在gvExcel绑定前，dtExcel数据貌似被改变，只含筛选后结果
        LCSS.BLL.CompensationItem CIBLL = new LCSS.BLL.CompensationItem();
        int errCount = 0;
        foreach (DataColumn dc in dtExcel.Columns)
        {
            //固定非薪酬项目列，后续文字用参数代替
            if (dc.ColumnName == "是否匹配" || dc.ColumnName == "工号" || dc.ColumnName == "姓名" || dc.ColumnName == "序号")
                continue;
            string SL_CI_Code = CIBLL.GetCodeByName(dc.ColumnName, "Org01");
            if (string.IsNullOrEmpty(SL_CI_Code))
            {
                errCount++;
                dc.ColumnName = "无效列" + errCount;//固定非薪酬项目列，后续文字用参数代替
            }
            else
            { dc.ColumnName = SL_CI_Code; }
        }
        DataView dvExcel = dtExcel.DefaultView;
        dvExcel.RowFilter = "是否匹配=true";//固定非薪酬项目列，后续文字用参数代替
        DataTable dtValid = dvExcel.ToTable();
        ViewState["dtValid"] = dtValid;
    }
    protected void btnImport_ServerClick(object sender, EventArgs e)
    {
        LCSS.Model.Salary oSalary = new LCSS.Model.Salary();
        oSalary.Sal_Add_User = "420001";//当前用户
        oSalary.Sal_Org_Code = "Org01";//当前用户所属组织
        LCSS.BLL.Salary SalaryBLL = new LCSS.BLL.Salary();
        oSalary.Sal_ID = SalaryBLL.Add(oSalary);
        //循环插入数据库（排除空数据）
        LCSS.Model.SalaryLine oSalaryLine;
        LCSS.BLL.CompensationItem CIBLL = new LCSS.BLL.CompensationItem();
        LCSS.BLL.SalaryLine SLBLL = new LCSS.BLL.SalaryLine();

        DataTable dtValid = (DataTable)ViewState["dtValid"];
        //后续考虑优化循环执行效率，例如提供list 在执行时拼接SQL一次执行
        foreach (DataRow dr in dtValid.Rows)
        {
            foreach (DataColumn dc in dr.Table.Columns)
            {
                //后续文字用参数代替
                if (dc.ColumnName.Contains("无效列"))//固定非薪酬项目列，后续文字用参数代替
                    continue;
                //固定非薪酬项目列，后续文字用参数代替
                if (dc.ColumnName == "是否匹配" || dc.ColumnName == "工号" || dc.ColumnName == "姓名" || dc.ColumnName == "序号")
                    continue;
                if (string.IsNullOrWhiteSpace(dr[dc.ColumnName].ToString()))
                    continue;
                oSalaryLine = new LCSS.Model.SalaryLine();
                oSalaryLine.SL_CI_Code = dc.ColumnName;
                oSalaryLine.SL_Emp_Code = dr["工号"].ToString();
                oSalaryLine.SL_Pay = Convert.ToDecimal(dr[dc.ColumnName].ToString());
                oSalaryLine.SL_Sal_ID = oSalary.Sal_ID;
                SLBLL.Add(oSalaryLine);
            }
        }
        gvExcel.DataSource = dtValid;
        gvExcel.DataBind();
    }
}