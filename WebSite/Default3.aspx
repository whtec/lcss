<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="renderer" content="webkit" />
    <title>无标题文档</title>
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Styles/bootstrapg/css/todc-bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="Styles/styles.css" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="Scripts/Validform_v5.3.2.js"></script>

    <link href="Styles/bootstrapg/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="Styles/bootstrapg/bootstrap-datetimepicker.min.js"></script>
    <script src="Styles/bootstrapg/bootstrap-datetimepicker.zh-CN.js"></script>

    <script src="Scripts/miao.js"></script>

 

</head>
<body class="adminbg">
    <div class="container-fluid header">
        <div class="container-fluid">
            <img src="Image/logo.png" width="400" height="80" alt="" />
            <ul class="nav navbar-nav navbar-right">
                <!--<form class="navbar-form navbar-left" role="search">
                        <div class="form-group">
                          <input type="text" class="form-control" placeholder="Search">
                        </div>
                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                </button>
                      </form>
                      -->
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"> <label id="lblUserName" runat="server"></label> <span class="caret"></span></a>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="#">业务中心</a></li>
                        <li><a href="#">修改密码</a></li>

                        <li class="divider"></li>
                        <li><a href="#">退出</a></li>
                    </ul>
                </li>

                <img class="userimg" src="Image/user.jpg" alt="" />
            </ul>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2 col-md-3 col-xs-3">
                <div class="adminleft">
                     <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true" runat="server">
     <%--                   <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion1" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        信息导入
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">
                                    <ul>

                                        <li><a href="#" id="gzdr">工资导入</a></li>
                                        <li><a href="#" id="jxdr">绩效导入</a></li>
                                        <li><a href="#" id="fldr">福利导入</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion1" href="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                                        历史查询
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">
                                    <ul>
                                        <li><a href="#" id="rgcb">人工成本查询</a></li>
                                        <li><a href="#" id="grsr">个人收入明细</a></li>
                                        <li><a href="#" id="srgs">收入个税查询</a></li>
                                        <li><a href="#" id="srmx">收入明细查询</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingThree">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree" aria-expanded="true" aria-controls="collapseThree">
                                        统计分析
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingThree">
                                <div class="panel-body">
                                    <ul>
                                        <li><a href="#">人工成本情况表</a></li>
                                        <li><a href="#">人工成本分析表</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>--%>

                        <%--<div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingFive">
                                <h4 class="panel-title">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion1" href="#collapseFive" aria-expanded="true" aria-controls="collapseThree">
                                        系统管理
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseFive" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingFive">
                                <div class="panel-body">
                                    <ul>
                                        <li><a href="#">部门设置</a></li>
                                        <li><a href="#">员工设置</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
            <div class="col-lg-10 col-md-9 col-xs-9">
                <div class="adminright">
                    <div id="loadTittle"></div>
                    <div id="loadContent">
                        <!--<iframe id="iFrame1" name="iFrame1" width="100%" onload="this.height=iFrame1.document.body.scrollHeight" frameborder="0" src="Salary/SalaryDetails.aspx"></iframe>-->
                        <iframe id="loadContent_f" name="iFrame1" frameborder="0" width="100%"  src="Salary/SalaryDetails.aspx" onload="this.height=500"> </iframe>

                        <!--<iframe id="iFrame1" name="iFrame1" width="100%" onload="this.height = $(window).height() - 150" frameborder="0" src="Salary/LoadSalary.aspx"></iframe>-->

                        <script type="text/javascript">
                            function reinitIframe() {
                                var iframe = document.getElementById("loadContent_f");
                                try {
                                    var bHeight = iframe.contentWindow.document.body.scrollHeight;
                                    var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                    var height = Math.max(bHeight, dHeight);
                                    iframe.height = height;
                                    //  console.log(height);
                                } catch (ex) { }
                            }
                            window.setInterval("reinitIframe()", 300);
                        </script>
                    </div>
                </div>
            </div>
        </div>

    </div>
<script>


   
</script>
</body>
</html>
