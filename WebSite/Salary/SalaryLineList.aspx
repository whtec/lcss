<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryLineList.aspx.cs" Inherits="SalaryLineList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人工成本查询</title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerGrid.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerResizable.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDrag.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerToolBar.js"></script>
    <script src="../Scripts/pc.js"></script>
    <link href="../Styles/bootstrapg/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.min.js"></script>
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.zh-CN.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/styles.css" />

    <script type="text/javascript">
        var grid = null;//主表
        var call = request.QueryString("call");
        //var j;
        function createGrid(divname, url) {
            $("#" + divname).remove();
            var div = "<div id='" + divname + "' style='margin:0; padding:0'></div>";
            
            $(document.getElementById('formsll')).append(div);

            $.getJSON(url, { page: 1, pagesize: 12, sortname: '工号', sortorder: 'asc', Rnd: Math.random() },
            function (json) {
                var colnames = ",{ display: '行号', name:'Row', minWidth: 140 ,width: 140,frozen:true}";
                colnames += ",{ display: '工号', name:'工号', minWidth: 140 ,width: 140,frozen:true}";
                colnames += ",{ display: '姓名', name:'姓名', minWidth: 140 ,width: 140,frozen:true}";
                for (var i in json.Rows[0]) //在这里读json的列名，当作表格的列名
                {
                    if (i.indexOf("时间") > 0) {
                        colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 140 ,width: 140 ,type:'date' }";
                        continue;
                    }
                    if (!(i == 'RECORDCOUNT' || i == 'PASSWORD' || i == 'Row' || i == 'Emp_Code' || i == 'Emp_Name'))
                        colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 140 ,width: 140}";
                }
                colnames = colnames.substr(1, colnames.length);
                console.log(colnames);
                //j = json;
                eval(
                        "grid=$('#" + divname + "').ligerGrid({" +
                        "checkbox: false," +
                        "columns:[" + colnames + "]," + 
                        "toolbar: { items: [{ text: '导出Execl', type: 'queryCond', click: operate }]}," +
                        //"data:j,"+    //这么写适合不分页的grid,还少读一次数据库
                        "url:'" + url + "'," +
                        "dataAction:'server'," +
                        "height:'auto'," +
                        "sortname:'工号'," +
                        "sortorder:'asc'," +
                        "page: 1,pageSize:12,pageSizeOptions: [12, 20, 30, 50, 100]" +
                        "});"
                    );
                console.log("grid=$('#" + divname + "').ligerGrid({" +
                        "checkbox: false," +
                        "columns:[" + colnames + "]," +
                        "toolbar: { items: [{ text: '导出Execl', type: 'queryCond', click: operate }]}," +
                        //"data:j,"+    //这么写适合不分页的grid,还少读一次数据库
                        "url:'" + url + "'," +
                        "dataAction:'server'," +
                        "height:'auto'," +
                        "sortname:'工号'," +
                        "sortorder:'asc'," +
                        "page: 1,pageSize:12,pageSizeOptions: [12, 20, 30, 50, 100]" +
                        "});");
            });
        }
        function operate()
        { }

        
        $(function () {
            createGrid("divGrid", "../Handler/SalaryHandler.ashx?opt=Query&call=" + call);
        });
    </script>
</head>
<body>
    <form id="formsll" runat="server">
        <div class="chaxun-info">
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
                <button type="button" class="btn btn-default col-md-2 col-md-offset-9">提 交</button>
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
    <script src="Scripts/miao.js"></script>
</body>
</html>
