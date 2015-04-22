<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="renderer" content="webkit">
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/todc-bootstrap.css">
    <link rel="stylesheet" type="text/css" href="Styles/styles.css">
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="Scripts/Validform_v5.3.2.js"></script>

    <script type="text/javascript" >
        var return_url = 'http://www.cnblogs.com/';
        var ajax_url = '/user' + '/signin';
        var enable_captcha = false;
        var is_in_progress = false;

        function setFocus() {
            document.getElementById('input1').focus();
        }

        function check_enter(event) {
            if (event.keyCode == 13) {
                var target = event.target || event.srcElement;
                if (target.id == "input1") {
                    if (document.getElementById('input1').value == '') {
                        $('#tip_input1').html("请输入登录用户名");
                        return;
                    }
                    else if (document.getElementById('input2').value == '') {
                        document.getElementById("input2").focus();
                        return;
                    }
                }
                if (target.id == "input2") {
                    if (document.getElementById('input2').value == '') {
                        $('#tip_input2').html("请输入密码");
                        return;
                    }
                }
                signin_go();
            }
        }

        function signin_go() {
            if(is_in_progress){
                return;
            }

            $('#tip_input1').html('');
            $('#tip_input2').html('');

            var input1 = $.trim($('#input1').val());
            if (!input1) {
                $('#tip_input1').html("请输入登录用户名");
                $('#input1').focus();
                return;
            }
            var input2 = $.trim($('#input2').val());
            if (!input2) {
                $('#tip_input2').html("请输入密码");
                $('#input2').focus();
                return;
            }

            if(enable_captcha)
            {
                var captchaCode = $.trim($('#captcha_code_input').val());
                if (!captchaCode)
                {
                    $('#tip_captcha_code_input').html("请输入验证码");
                    $('#captcha_code_input').focus();
                    return;
                }
            }

            $('#tip_btn').html('提交中...');

            var encrypt = new JSEncrypt();
            encrypt.setPublicKey('MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCp0wHYbg/NOPO3nzMD3dndwS0MccuMeXCHgVlGOoYyFwLdS24Im2e7YyhB0wrUsyYf0/nhzCzBK8ZC9eCWqd0aHbdgOQT6CuFQBMjbyGYvlVYU2ZP7kG9Ft6YV6oc9ambuO7nPZh+bvXH0zDKfi02prknrScAKC0XhadTHT3Al0QIDAQAB');
            var encrypted_input1 = encrypt.encrypt($('#input1').val());
            var encrypted_input2 = encrypt.encrypt($('#input2').val());
            var ajax_data = {
                input1: encrypted_input1,
                input2: encrypted_input2,
                remember: $('#remember_me').prop('checked')
            };

            if(enable_captcha){
                var captchaObj = $("#captcha_code_input").get(0).Captcha;
                ajax_data.captchaId = captchaObj.Id;
                ajax_data.captchaInstanceId = captchaObj.InstanceId;
                ajax_data.captchaUserInput = $("#captcha_code_input").val();
            }
            is_in_progress = true;
            $.ajax({
                url: ajax_url,
                type: 'post',
                data: JSON.stringify(ajax_data),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                headers: {
                    'VerificationToken': 'dmq9gwxLbeKxyrjoYWmrPSJFwTSXNwZd6sC3zBsx8aKakAtk3i7xPJW70nNM05dzzI-cCbaA3qWkiS3ya9Rsul0heDc1:EKb7BrVXE5SpVdU0GLHW1FgalNDTt1FGbNgD_uKdayibG56X4jxxYbgxgKSjv6FWNGGpZ7EADuQzqw-km-AISaLYlaA1'
                },
                success: function (data) {                    
                    if (data.success) {
                        $('#tip_btn').html('登录成功，正在重定向...');
                        location.href = return_url;
                    } else {
                        $('#tip_btn').html(data.message + "<br/><br/>联系 contact@cnblogs.com");
                        is_in_progress = false;
                        if(enable_captcha)
                        {
                            captchaObj.ReloadImage();
                        }
                    }
                },
                error: function (xhr) {
                    is_in_progress = false;
                    $('#tip_btn').html('抱歉！出错！联系 contact@cnblogs.com');
                }
            });
        }

        $(function () {
            $('#signin').bind('click', function () {
                signin_go();
            }).val('登 录');

        });
    </script>

</head>
    <body class="loginbg">
    <!--    <div class="container-fluid">

        </div>-->

    <div class="loginBox">
        <div id="logo">
            <img src="Image/logo.png" width="400" height="80" alt="" />

        </div>
        <form class="form-horizontal loginFrom" id="loginForm" name="loginForm" mothod="post" action="Login.aspx" >
            <div class="form-group">
                <label for="inputEmail3" class="col-sm-3 control-label">用户名:</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" id="txtUsername" placeholder="您的用户名">
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword3" class="col-sm-3 control-label">密码:</label>
                <div class="col-sm-9">
                    <input type="password" class="form-control" id="txtPassword" placeholder="您的密码">
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-3 col-sm-9">
                    <input type="submit" class="btn btn-primary" id="submit" value=">登   入">
                    <%--<button type="submit" class="btn btn-primary">登   入</button>--%>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
<body>



<%--<form name="aspnetForm" method="post" action="signin.aspx?ReturnUrl=%2f%2fwww.asp.net%2f" onkeypress="javascript:return WebForm_FireDefaultButton(event, 'ctl00_MainContent_loginForm_btnLogin')" id="aspnetForm">
<div>
    

<script type="text/javascript">
    //<![CDATA[
    WebForm_AutoFocus('ctl00_MainContent_loginForm_txtUsername'); Sys.Application.initialize();
    //]]>
</script>
</form>--%>