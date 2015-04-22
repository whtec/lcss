using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    private int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        count++;
        if (!IsPostBack)
        {
            count++;
            if(Request.QueryString["t"]!=null)
                count=0;
        }
    }
}