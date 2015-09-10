<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaxContrastList.aspx.cs" Inherits="TaxContrastList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>收入和个税台帐</title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrapg/css/bootstrap.css" />
    <link href="../Styles/bootstrapg/css/todc-bootstrap.css" rel="stylesheet" />
    <link href="../Styles/styles.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerGrid.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerResizable.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDrag.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerToolBar.js"></script>
    <script src="../Scripts/pc.js"></script>
    <link href="../Styles/bootstrapg/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.min.js"></script>
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.zh-CN.js"></script>
    <%--    <link rel="stylesheet" type="text/css" href="Styles/styles.css" />--%>

    <style>
        /*#divGridgrid  td[id$="|c108"] {
            background:#7bbff2!important;
        }*/
        .gridcolor1 {
            background: #D5E9F8 !important;
            border-right: 1px solid #A3C0E8;
            border-bottom: 1px solid #A3C0E8;
        }
    </style>

    <script type="text/javascript">
        var grid = null;//主表
        var call = "<%=call%>";//request.QueryString("call");
        var winheight = parent.document.documentElement.clientHeight;
        var girdbodyheight = (winheight - 260) ;
        console.log(girdbodyheight);

        
        $(function () {
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth() + 1);

            $("#dateup1").val(date);
            $("#dtp_input1").val(date);

            //add at 2015.09.01
            var url = "../Handler/SalaryHandler.ashx?opt=Query&call=5&said=-1&date=" + $("#dateup1").val();
            createGrid1("divGridZoom", url);
        });
        function ondate1change() {
            var date = $("#dateup1").val();
            console.log(date);
            var url = "../Handler/SalaryHandler.ashx?opt=Query&call=5&said=-1&date=" + $("#dateup1").val();
            createGrid1("divGridZoom", url);
        }
        function createGrid1(divname, url) {
            $.getJSON(url, { Rnd: Math.random() },
           function (json) {
               $("#" + divname + "").ligerGrid({
                   columns: [
                        { display: '工号', name: '工号', width: 80, frozen: true },
                        { display: '姓名', name: '姓名', width: 60, frozen: true, totalSummary: { render: function () { return '<div>当页合计</div>'; }, align: 'left' } },
                        { display: '年度', name: '年度', width: 50 },
                        { display: '月度', name: '月度', width: 50 },
                        { display: '工资合计', name: '工资合计', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                        { display: '月度绩效合计', name: '月度绩效合计', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                        { display: '收入合计', name: '收入合计',type:'Fixed2', width: 80,totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                        { display: '税前扣除部分', columns:
                           [

                               { display: '失业保险', name: '失业保险', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '基本养老保险', name: '基本养老保险', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '公司公积金', name: '公司公积金', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '年金', name: '年金', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                           ]
                       },
                       { display: '应纳税', columns:
                           [
                               { display: '收入', name: '收入', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '公积金企业部分', name: '公积金企业部分', type:'Fixed2', width: 100, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '年金', name: '年金1', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                               { display: '小计', name: '小计', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                           ]
                        },
                        { display: '应纳税金', name: '应纳税金', type:'Fixed2', width: 80, totalSummary: { render: function (suminf, column, cell) { return '<div>' + suminf.sum.toFixed(2) + '</div>'; }, align: 'right' } },
                   ], pageSize: 50, pageSizeOptions: [20, 30, 50, 100], checkbox: false, allowHideColumn: false,
                   data: json,
                   height: girdbodyheight,
                   type:'Fixed2', width:'100%'
               });
           });
        }



    </script>
</head>
<body>
    <br />
    <form id="formsll" runat="server">
        <span class="glyphicon glyphicon-menu-down" aria-hidden="true" id="open1"></span>
        <%--<div class="chaxun-info" style="display: none;">--%>
        <div class="chaxun-info">
            <div class="row">
                <div class="form-group col-sm-1">
                </div>
                <div class="form-group col-sm-5">
                    <label for="dtp_input1" class="control-label chaxun-info-label">开始日期：</label>
                    <div class="input-group date form_date chaxun-info-input" data-date="" data-date-format="yyyy-m" data-link-field="dtp_input1" data-link-format="yyyy-m">
                        <input id="dateup1" class="form-control" size="16" type="text" readonly datatype="*" errormsg="不能为空" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                        <input type="hidden" id="dtp_input1" value="" onchange="ondate1change()" />
                    </div>
                </div>
                <%--<div class="form-group col-sm-4">
                    <label for="dtp_input2" class="control-label chaxun-info-label">结束日期：</label>
                    <div class="input-group date form_date chaxun-info-input" data-date="" data-date-format="yyyy-m" data-link-field="dtp_input2" data-link-format="yyyy-m">
                        <input id="dateup2" class="form-control" size="16" type="text" readonly datatype="*" errormsg="不能为空" />
                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                        <input type="hidden" id="dtp_input2" value="" onchange="ondate2change()" />
                    </div>
                </div>--%>
                <div class="form-group col-sm-5">
                    <%--<label for="" class="control-label chaxun-info-label">发放项目:</label>
                    <div class="chaxun-info-input">
                        <select class="form-control" id="selDes" onchange="ddlchange()">
                            <option value="-99">请选择...</option>
                        </select>
                    </div>--%>
                </div>
                <div class="form-group col-sm-1">
                </div>
                <%--<div class="form-group col-sm-2">
                    <button type="button" class="btn btn-primary">查 询</button>
                </div>--%>
                <br />
            </div>
        </div>
        <div id="divGridZoom">
        </div>
    </form>
    <script type="text/javascript">
        $('.form_date').datetimepicker({
            language: 'zh-CN',
            weekStart: 1,
            // todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 4,
            minView: 3,
            forceParse: 0
        });
    </script>

    <script>
        $(document).ready(function () {
            $("#dateup").change(function () {
                //console.log("abb");
                $('#datedown').val($('#dateup').val());
                $("#datedown").removeAttr("disabled");
            });

            $("#open1").on("click", function () {
                if ($(this).hasClass("activeopen1")) {
                    $("div.chaxun-info").slideUp("normal");
                    $("#open1").addClass("glyphicon-menu-down");
                    $("#open1").removeClass("glyphicon-menu-up");
                    $(this).removeClass("activeopen1");
                } else {
                    $("div.chaxun-info").slideDown("normal");
                    $("#open1").addClass("glyphicon-menu-up");
                    $("#open1").removeClass("glyphicon-menu-down");
                    $(this).addClass("activeopen1");
                }
            });
        });

    </script>
</body>
</html>
