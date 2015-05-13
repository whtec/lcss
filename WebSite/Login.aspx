<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工资查询系统登录</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="renderer" content="webkit" />
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/todc-bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Styles/styles.css" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="Scripts/Validform_v5.3.2.js"></script>
</head>
<body class="loginbg">
    <div class="loginBox">
        <div id="logo">
            <img src="Image/logo.png" width="400" height="80" alt="" />
        </div>
        <form class="form-horizontal loginFrom" id="loginForm" name="loginForm" runat="server">
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-3 control-label">用户名:</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" id="txtUserName" name="txtUserName" placeholder="您的用户名" runat="server" value="test1" />
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-3 control-label">密码:</label>
                <div class="col-sm-9">
                    <input type="password" class="form-control" id="txtPassword" name="txtPassword" placeholder="您的密码" runat="server" value="1" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-3 col-sm-9">
                    <input type="submit" class="btn btn-primary col-sm-12" id="btnLogin" value="登   入" runat="server" onserverclick="btnLogin_ServerClick" />
                </div>
            </div>
            <div class="form-group">
                <label id="lblmsg" runat="server" style="color:red"></label>
                </div>
        </form>
    </div>
</body>
</html>