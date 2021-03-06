﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadSalaryList.aspx.cs" Inherits="LoadSalaryList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>导入历史列表</title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrapg/css/bootstrap.css">

    <link href="../Styles/bootstrapg/css/todc-bootstrap.css" rel="stylesheet" />
    <link href="../Styles/styles.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerGrid.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerResizable.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDrag.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerToolBar.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDialog.js"></script>
    <script src="../Scripts/pc.js"></script>
    <link href="../Styles/bootstrapg/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.min.js"></script>
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.zh-CN.js"></script>
    <%--    <link rel="stylesheet" type="text/css" href="Styles/styles.css" />--%>

    <script type="text/javascript">
        var grid = null;//主表
        var winheight = parent.document.documentElement.clientHeight;
        var girdbodyheight = (winheight - 116);
        //var girdbodyheight2 = (winheight - 250);
        console.log(winheight);
        //var call = "<%=call%>";//request.QueryString("call");
        //var j;
        $(function () {
            createGrid();//createGrid("divGrid", "../Handler/SalaryHandler.ashx?opt=Query&call=");// + call);
        });
        function createGrid() {
            var divname = 'divGrid';
            var url = '../Handler/SalaryHandler.ashx?opt=Query&call=4&sortname=流水号&sortorder=desc';
            $("#" + divname).remove();
            var div = "<div id='" + divname + "' style='margin:0; padding:0'>123</div>";
            console.log(url);
            $(document.getElementById('formsll')).append(div);

            $.getJSON(url, { page: 1, pagesize: 20, Rnd: Math.random() },
            function (json) {
                var colnames = "";//",{ display: '行号', name:'Row', minWidth: 40 ,width: 50,frozen:true}";
                //colnames += ",{ display: '工号', name:'工号', minWidth: 80 ,width: 80,frozen:true}";
                //colnames += ",{ display: '姓名', name:'姓名', minWidth: 80 ,width: 80,frozen:true}";
                //colnames += ",{ display: '操作', minWidth: 80 ,width: 80,render: function (){return '<div on click=\"operate()\">删除</div>';}}";
                for (var i in json.Rows[0]) //在这里读json的列名，当作表格的列名
                {
                    if (i.indexOf("时间") > 0) {
                        colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: '20%' ,type:'date' }";
                        continue;
                    }
                    if (!(i == 'RECORDCOUNT' || i == 'PASSWORD' || i == 'Row' || i == 'Emp_Code' || i == 'Emp_Name' || i == '组织代码' || i == '基数' || i == '系数'))
                        colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: '10%'}";
                }
                colnames = colnames.substr(1, colnames.length);
                //console.log(colnames);
                //j = json;
                eval(
                        "grid=$('#" + divname + "').ligerGrid({" +
                        "checkbox: false," +
                        "columns:[" + colnames + "]," +                        
                         "toolbar: { items: [{ text: '删除', type: 'deleteCond', click: operate, icon: 'delete'}]}," +
                        //"data:j,"+    //这么写适合不分页的grid,还少读一次数据库
                        "url:'" + url + "'," +
                        "dataAction:'server'," +
                        "height:'" + girdbodyheight + "'," +
                        "width:'97%'," +
                        "sortname:'流水号'," +
                        "sortorder:'desc'," +
                        "detail: { onShowDetail: f_showDetails ,height:'auto'}," +
                        "page: 1,pageSize:20,pageSizeOptions: [20, 30, 50, 100]" +
                        "});"
                    );
            });
        }
       
        //显示导入详细
        function f_showDetails(row, detailPanel, callback) {
            var url = "../Handler/SalaryHandler.ashx?opt=Query&call=7&said=" + row.流水号;
            var grid = document.createElement('div');
            $(detailPanel).append(grid);
            //var colnames = ",{ display: '行号', name:'Row', minWidth: 40 ,width: 50,frozen:true}";
            var colnames = ",{ display: '工号', name:'工号', minWidth: 80 ,width: 80,frozen:true}";
            colnames += ",{ display: '姓名', name:'姓名', minWidth: 80 ,width: 80,frozen:true,totalSummary:{render: function (){return '<div>当页合计</div>';},align: 'left'}}";
            $.getJSON(url, { page: 1, pagesize: 15, sortname: '工号', sortorder: 'asc', Rnd: Math.random() },
           function (json) {
               for (var i in json.Rows[0]) //在这里读json的列名，当作表格的列名
               {
                   if (i.indexOf("时间") > 0) {
                       colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: 80 ,type:'date' }";
                       continue;
                   }
                   if (!(i == 'RECORDCOUNT' || i == 'PASSWORD' || i == 'Row' || i == 'Emp_Code' || i == 'Emp_Name' || i == '工号' || i == '姓名' || i == '组织代码' || i == '基数' || i == '系数')) {
                       if (i == '导入编次' || i == '录入人' || i == '年度' || i == '月度') {
                           colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: 80}";
                       }
                       else {
                           colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: 80,type: 'F2',totalSummary:{render: function (suminf, column, cell){return '<div>' + suminf.sum.toFixed(2) + '</div>';},align: 'right'}}";
                       }
                   }
               }
               colnames = colnames.substr(1, colnames.length);
               //console.log(colnames);
               eval(
                       "$(grid).css('divGrid', 10).ligerGrid({" +
                       "checkbox: false," +
                       "columns:[" + colnames + "]," +
                       //"toolbar: { items: [{ text: '导出Execl', type: 'queryCond', click: operate }]}," +
                       "url:'" + url + "'," +
                       "dataAction:'server'," +
                       "height:'98%'," +//"height:'" + girdbodyheight2 + "'," +
                       "width:'98%'," +
                       "sortname:'年度 desc,月度 desc,工号 '," +
                       "sortorder:'asc'," +
                       "isScroll: false," +
                       "showToggleColBtn: false," +
                       "showTitle: false," +
                       "columnWidth: 100," +
                       "page: 1,pageSize:50,pageSizeOptions: [20, 30, 50, 100]" +
                       "});"
                   );
           });
        }

        function operate()
        {
            var selRow = grid.getSelectedRow();
            if (selRow.length == 0) {
                $.ligerDialog.warn("请先选择要删除的行！");
                return;
            }
            $.ligerDialog.confirm("是否要执行删除操作", function (yes) {
                if (yes) {
                    $.ajax({
                        url: "../Handler/SalaryHandler.ashx?opt=Delete&id=" + selRow.流水号, async: false, success: function () {
                           //alert(selRow.流水号);
                        }
                    });
                    grid.deleteSelectedRow();
                }
            });
        }

    </script>
</head>
<body>
    <form id="formsll" runat="server">
        <span class="glyphicon glyphicon-menu-down" aria-hidden="true" id="open1"></span>
        <div class="chaxun-info" style="display: none;">
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">内容：</label>
                    <div class="chaxun-info-input">
                        <input type="text" class="form-control inputxt" placeholder="内容1" value="" />
                    </div>
                </div>
                <div class="form-group col-sm-6">
                    <label for="" class="control-label chaxun-info-label">类型:</label>
                    <div class="chaxun-info-input">
                        <select class="form-control">
                            <option></option>
                            <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-sm-6">
                    <label for="dtp_input2" class="control-label chaxun-info-label">起始日期：</label>
                    <div class="input-group date form_date chaxun-info-input" data-date="" data-date-format="yyyy-mm-dd" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd hh:ii:ss">
                        <input id="dateup" class="form-control" size="16" type="text" value="2015-1-1" readonly datatype="*" errormsg="不能为空">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                        <input type="hidden" id="dtp_input2" value="">
                    </div>
                </div>
                <div class="form-group col-sm-6">
                    <label for="dtp_input2" class="control-label chaxun-info-label">结束日期：</label>
                    <div class="input-group date form_date chaxun-info-input" disabled="disabled" data-date="" data-date-format="yyyy-mm-dd" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd hh:ii:ss">
                        <input id="datedown" class="form-control" disabled="disabled" size="16" type="text" value="2015-1-1" readonly datatype="*" errormsg="不能为空">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                        <input type="hidden" id="dtp_input3" value="">
                    </div>
                </div>
            </div>
            <div class="row">
                <button type="button" class="btn btn-primary col-md-1 col-md-offset-9">提 交</button>
                <br />
            </div>
        </div>
        <div id="divGrid">
        </div>
    </form>
    <script type="text/javascript">
        $('.form_date').datetimepicker({
            language: 'zh-CN',
            weekStart: 1,
            // todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            startView: 3,
            minView: 2,
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
        })
    </script>
</body>
</html>
