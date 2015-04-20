using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalaryLineList : System.Web.UI.Page
{
    protected string defaultWhere = string.Empty;
    protected string type = string.Empty;
    private string refType = "type";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString[refType] == null)
                return;
            type = Request.QueryString[refType].ToString();
            if (type == "self")
            {
                //获取当前登录用户ID
            }
            else
            { 
                //判断权限是否可以查看所有人

            }
        }
        //根据类型参数查看个人收入明细（获取登录用户）
        //具有权限-查看人工成本列表（公司所有人）
    }
}