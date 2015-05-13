using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using LCSS.Model;
using PC.Common;

public partial class Default : System.Web.UI.Page
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
        LoginInfo oLoginInfo = (LoginInfo)Session[PageSessionName.LoginObject];
        if (oLoginInfo != null)
        {
            lblUserName.InnerText = oLoginInfo.UserName;
        }
        else
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        string sql = @"select distinct [S_Menu].* from [dbo].[S_Menu]
                    left join [T_ConferAuthority] on [S_Menu].[Menu_Aut_Code]=[T_ConferAuthority].[CA_Aut_Code]
                    where [CA_ObjCode]='{0}' or [CA_ObjCode] in (select distinct [AR_Role_Code] from [dbo].[T_Account_Role] where [AR_ACCT_LoginID]='{0}') ";
        DataSet dsMenu = PC.DBUtility.DbHelperSQL.Query(string.Format(sql, oLoginInfo.LoginID));
        Dictionary<string, StringBuilder> dicMenu = new Dictionary<string, StringBuilder>();
        if (dsMenu != null && dsMenu.Tables.Count == 1)
        {
            DataTable dtMenu = dsMenu.Tables[0];
            foreach (DataRow dr in dtMenu.Rows)
            {
                string sCategory = dr["Menu_Category"].ToString();
                if (!dicMenu.ContainsKey(sCategory))
                    dicMenu[sCategory] = new StringBuilder();
                dicMenu[sCategory].AppendFormat("<li><a href=\"#\" id=\"{0}\" onclick=\"indexleft1('#{0}','{2}')\">{1}</a></li>", dr["Menu_Code"].ToString(), dr["Menu_Name"].ToString(), dr["Menu_Url"].ToString());
            }
            StringBuilder sMenuHtml = new StringBuilder();
            int count = 1;
            foreach (string key in dicMenu.Keys)
            {
                sMenuHtml.Append("      <div class=\"panel panel-default\">");
                sMenuHtml.AppendFormat("    <div class=\"panel-heading\" role=\"tab\" id=\"heading{0}\">", count.ToString());
                sMenuHtml.Append("              <h4 class=\"panel-title\">");
                sMenuHtml.AppendFormat("            <a data-toggle=\"collapse\" data-parent=\"#accordion1\" href=\"#collapse{1}\" aria-expanded=\"true\" aria-controls=\"collapse{1}\">{0}</a>", key, count.ToString());
                sMenuHtml.Append("              </h4>");
                sMenuHtml.Append("          </div>");
                sMenuHtml.AppendFormat("    <div id=\"collapse{0}\" class=\"panel-collapse collapse in\" role=\"tabpanel\" aria-labelledby=\"heading{0}\">", count.ToString());
                sMenuHtml.Append("              <div class=\"panel-body\">");
                sMenuHtml.Append("                  <ul>");
                sMenuHtml.Append(dicMenu[key]);
                sMenuHtml.Append("                  </ul>");
                sMenuHtml.Append("              </div>");
                sMenuHtml.Append("          </div>");
                sMenuHtml.Append("      </div>");
                count++;
            }
            accordion.InnerHtml = sMenuHtml.ToString();
            //<div class="panel panel-default">
            //    <div class="panel-heading" role="tab" id="headingOnexsssssssssssxx">
            //        <h4 class="panel-title">
            //            <a data-toggle="collapse" data-parent="#accordionxxx" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">信息导入
            //            </a>
            //        </h4>
            //    </div>
            //    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
            //        <div class="panel-body">
            //            <ul>
            //                <li><a href="#" id="gzdr">工资导入</a></li>
            //                <li><a href="#" id="jxdr">绩效导入</a></li>
            //                <li><a href="#" id="fldr">福利导入</a></li>
            //            </ul>
            //        </div>
            //    </div>
            //</div>
        }
    }

}