using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PC.Common;
using LCSS.Model;
using PC.DBUtility;

public partial class LoadSalary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            aa();
        }
    }
    /// <summary>
    /// 根据登录账号判断是否有导入权限
    /// </summary>
    void aa()
    {
        LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        //oLoginInfo.LoginID 根据账号查找是否有权限
        //P001
        string sql = "  select count(*) from [View_UserRolePowerList] where [ACCT_LoginID]='" + oLoginInfo.LoginID + "' and [RP_Power_Code]='P001'";
        object obj=DbHelperSQL.ReturnValue(sql);
        int num=Convert.ToInt32(obj);
        if (num <= 0)
            throw new Exception("你没有访问权限！");
    }
}