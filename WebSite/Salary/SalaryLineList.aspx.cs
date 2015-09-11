using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LCSS.Model;
using PC.Common;
using PC.DBUtility;

public partial class SalaryLineList : System.Web.UI.Page
{
    protected string defaultWhere = string.Empty;
    protected string type = string.Empty;
    private string refType = "call";
    protected string call = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString[refType] == null)
                return;
            call = Request.QueryString[refType].ToString();
            CheckAuthority();
        }
    }
    /// <summary>
    /// 根据登录账号判断是否有访问权限
    /// </summary>
    void CheckAuthority()
    {
        LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
        { Response.Redirect("../Login.aspx"); }
        //oLoginInfo.LoginID 根据账号查找是否有权限
        string sql = @"  select count(*) from [dbo].[T_ConferAuthority]
            where [CA_ObjCode]='{0}' or [CA_ObjCode] in (select distinct [AR_Role_Code] from [dbo].[T_Account_Role] where [AR_ACCT_LoginID]='{0}') and [CA_Aut_Code]='{1}'";
        object obj = DbHelperSQL.ReturnValue(string.Format(sql, oLoginInfo.LoginID, getAuthority(call)));
        int num = Convert.ToInt32(obj);
        if (num <= 0)
            throw new Exception("你没有访问权限！");
    }
    string getAuthority(string call)
    {
        switch (call)
        {
            case "1":
                return PageAuthorityName.rgcb;
            case "9":
                return PageAuthorityName.rgcb;
            case "2":
                return PageAuthorityName.drls;
            case "3":
                return PageAuthorityName.grsr;
            default:
                return "你没有访问权限";
        }
    }
}