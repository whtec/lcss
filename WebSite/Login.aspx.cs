using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PC.Common;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        LCSS.Model.T_Account oAccount = new LCSS.BLL.T_Account().GetLoginInfo(txtUserName.Value, txtPassword.Value);
        if (oAccount == null)
        {
            //throw new Exception("用户名或密码错误");
            lblmsg.InnerText = "用户名或密码错误!";
            return;
        }
        LCSS.Model.LoginInfo oLoginInfo = new LCSS.Model.LoginInfo();
        oLoginInfo.Agent = Request.UserAgent;
        oLoginInfo.HostName = Request.UserHostName;
        oLoginInfo.IPAdr = Request.UserHostAddress;
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
        Session[PageSessionName.LoginObject] = oLoginInfo;
        Response.Redirect("Default.aspx");        
    }
}