<%@ WebHandler Language="C#" Class="LoginHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using PC.Common;

public class LoginHandler : IHttpHandler,IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        try
        {
            Login(context);
        }
        catch(Exception ex) {
            context.Response.Write(ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    void Login(HttpContext context)
    {
        string uid, pwd,url;
        uid = context.Request.QueryString["uid"].ToString();
        pwd = context.Request.QueryString["pwd"].ToString();
        url = context.Request.QueryString["url"].ToString();
        LCSS.Model.T_Account oAccount = new LCSS.BLL.T_Account().GetLoginInfo(uid, pwd);
        if (oAccount == null)
            throw new Exception("用户名或密码错误");
        LCSS.Model.LoginInfo oLoginInfo = new LCSS.Model.LoginInfo();
        oLoginInfo.HostName = context.Request.UserHostName;
        oLoginInfo.IPAdr = context.Request.UserHostAddress;
        oLoginInfo.LoginID = oAccount.ACCT_LoginID;
        oLoginInfo.LoginTime = System.DateTime.Now.ToString();
        if (string.IsNullOrEmpty(oAccount.ACCT_US_Code))
        {
            oLoginInfo.OrgCode = oAccount.ACCT_Org_Code;
            oLoginInfo.UserName = oAccount.ACCT_UserName;
        }
        else
        {
            LCSS.Model.Employees oEmployees = new LCSS.Model.Employees();
            oEmployees = new LCSS.BLL.Employees().GetModel(oAccount.ACCT_US_Code);
            oLoginInfo.UserID = oEmployees.Emp_Code;
            oLoginInfo.UserName = oEmployees.Emp_Name;
            oLoginInfo.OrgCode = oEmployees.Emp_Org_Code;
        }
        oLoginInfo.OrgName = new LCSS.BLL.Organization().GetModel(oLoginInfo.OrgCode).Org_Name;
        context.Session[PageSessionName.LoginObject] = oLoginInfo;
        context.Response.Redirect("Default.aspx");        
    }

}