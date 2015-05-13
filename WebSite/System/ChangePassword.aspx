<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="System_ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="stylesheet" type="text/css" href="../Styles/bootstrapg/css/bootstrap.css" />
    <link href="../Styles/bootstrapg/css/todc-bootstrap.css" rel="stylesheet" />
    <link href="../Styles/styles.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/bootstrapg/js/bootstrap.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="chaxun-info">
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">当前账号：</label>
                    <div class="chaxun-info-input">
                        <input id="txtAccount" type="text" class="form-control inputxt" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">当前密码:</label>
                    <div class="chaxun-info-input">
                        <input id="txtCurrent" type="password" class="form-control inputxt" value="" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">新密码：</label>
                    <div class="chaxun-info-input">
                        <input id="txtNew" type="password" class="form-control inputxt" value="" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">新密码确认：</label>
                    <div class="chaxun-info-input">
                        <input id="txtConfirm" type="password" class="form-control inputxt" value="" runat="server" />
                    </div>
                </div>
                <%--<button type="button" class="btn btn-primary col-md-1 col-md-offset-9" runat="server">提 交</button>--%>

                <br />
            </div>
            <input id="btnChange" type="button" class="btn btn-primary col-md-1" value="提 交" runat="server" onserverclick="btnChange_ServerClick"></input>
        </div>
    </form>
</body>
</html>
