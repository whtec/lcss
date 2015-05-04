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
            CheckAuthority();
        }
    }
    /// <summary>
    /// 根据登录账号判断是否有导入权限
    /// </summary>
    void CheckAuthority()
    {
        LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
            Response.Redirect("../Login.aspx");
        //根据账号查找是否有权限
        string sql = @"  select count(*) from [dbo].[T_ConferAuthority]
            where [CA_ObjCode]='{0}' or [CA_ObjCode] in (select distinct [AR_Role_Code] from [dbo].[T_Account_Role] where [AR_ACCT_LoginID]='{0}') and [CA_Aut_Code]='{1}'";
        object obj = DbHelperSQL.ReturnValue(string.Format(sql, oLoginInfo.LoginID, PageAuthorityName.LoadSalary));
        int num = Convert.ToInt32(obj);
        if (num <= 0)
            throw new Exception("你没有访问权限！");
    }
}