using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LCSS.Model;
using LCSS.BLL;
using PC.Common;

public partial class System_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginInfoDataBind();
        }
    }
    void LoginInfoDataBind()
    {
        LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        if (oLoginInfo == null)
        { Response.Redirect("../Login.aspx"); }

        txtAccount.Value = oLoginInfo.LoginID;
        txtAccount.Disabled = true;
    }
    void ChangePassword()
    {
        //前端校验2次密码输入是否一致
        LCSS.Model.T_Account model = new LCSS.Model.T_Account();
        model.ACCT_LoginID = txtAccount.Value;
        model.ACCT_Pwd = txtCurrent.Value;
        LCSS.BLL.T_Account T_AccountBLL = new LCSS.BLL.T_Account();
        bool isRight = T_AccountBLL.Exists(txtAccount.Value, txtCurrent.Value);
        if (isRight)
        {
            if (T_AccountBLL.UpdatePassword(txtAccount.Value, DESEncrypt.Encrypt(txtNew.Value.Trim())))
            {
                Response.Write("<script>alert('修改成功，请使用新密码重新登陆！');window.parent.location.href='../Login.aspx';</script>");
                //Response.Redirect("../Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('密码修改失败，请联系管理员！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('当前密码输入不正确，请重新输入！');</script>");
        }
    }
    protected void btnChange_ServerClick(object sender, EventArgs e)
    {
        ChangePassword();
    }
}