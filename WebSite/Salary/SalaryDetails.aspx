<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryDetails.aspx.cs" Inherits="Salary_SalaryDetails" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js">
<head runat="server">
    <title>个人工资单</title>

    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="renderer" content="webkit" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />


    <link href="../Styles/VerticalTimeline/css/default.css" rel="stylesheet" />
    <link href="../Styles/VerticalTimeline/css/component.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Styles/VerticalTimeline/js/modernizr.custom.js"></script>
    <%--  <script type="text/javascript">
        $(function () {
            mysalary("../Handler/SalaryHandler.ashx?opt=MyGzt&count=1");
        });
        function mysalary(url) {
            $.getJSON(url, { Rnd: Math.random() },
            function (json) {

                var shuzu = new Array();
                var show11 = '';
                for (var i = 0; i++; i < json.length) {
                    show11 += "," + json[i];//+= obj.CT_NAME;

                    //shuzu[obj.CT_NAME]
                }
                $("#t1111").val(json);
            });
        }

    </script>--%>

    <style>

        body {
        overflow-x:scroll;}
    </style>
</head>
<body>
    <div class="row">
        <%--<header class="clearfix">
            <div class="page-header">
                <h3>王老湿<small>软件公司</small></h3>
            </div>
        </header>--%>
        <div class="main">
            <ul class="cbp_tmtimeline">
                <%--<li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>4月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h4>王松<small>第一次</small></h4>
                        <div class="pay-content">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>

                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                        <div class="pay-total">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>4月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h4>王松<small>第一次</small></h4>
                        <div class="pay-content">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                        <div class="pay-total">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <time class="cbp_tmtime" datetime=""><span>2015年</span> <span>4月</span></time>
                    <div class="cbp_tmicon"></div>
                    <div class="cbp_tmlabel">
                        <h4>王松<small>第一次</small></h4>
                        <div class="pay-content">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                    <li>基本工资 <span class="red">3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                        <div class="pay-total">
                            <div class="pay-base">
                                <h5>应发项目</h5>
                                <ul>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                    <li>基本工资 <span>3000.00</span></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </li>--%>

                <li id="li_last"></li>
            </ul>
        </div>
    </div>
    <script>
        var icount = 0;
        var hahaha = "";
        function SalaryDetailsajax() {

            icount++;
            console.log(icount);
            //$.get("Handler/SalaryHandler.ashx", { opt: "MyGzt", count: icount }, function (result) {
            //    //    console.log(result);
            //    if (result == hahaha) {
            //        $("#li_last").removeAttr("id");
            //    } else {
            //        //console.log(result);
            //        $("#li_last").before(result);
            //    }
            //});

            $.ajaxSetup({
                url: "../Handler/SalaryHandler.ashx",
                global: false,
                type: "get",
                async: false,
                cache: false,
                success: function (result) {

                    if (result == hahaha) {
                        $("#li_last").removeAttr("id");
                    } else {

                        $("#li_last").before(result);
                    }
                },

            });
            $.ajax({ data: { opt: "MyGzt", count: icount } }
                )
        }
        $(document).ready(function () {

            SalaryDetailsajax();
            if ($(window).scrollTop() == 0) {
                //    console.log(icount)

                SalaryDetailsajax()
            }
            $(window).scroll(function () {
                var li_lasth = $("#li_last").offset().top;
                var navH2 = $(window).scrollTop() + $(window).height();
                var li_lastchazhi = navH2 - li_lasth;
              //  console.log(li_lastchazhi);
                // if (li_lastchazhi >= 71) {
                if (li_lastchazhi >= 45) {
                    //  console.log(icount);
                    SalaryDetailsajax()
                    //$.get("Salary/1.html", function (result) {
                    //    //   console.log(result);
                    //    $("#li_last").before(result);
                    //});
                }
            })
        })
    </script>
</body>
</html>
