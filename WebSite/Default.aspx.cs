using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LCSS.Model;
using PC.Common;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind();
        }
    }

    void DataBind()
    {
        //LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        //if (oLoginInfo != null)
        //{
        //    lblUserName.InnerText = oLoginInfo.UserName;            
        //}
        //else
        //{
        //    Session.Clear();
        //    Response.Redirect("Login.aspx");
        //}
    }
}