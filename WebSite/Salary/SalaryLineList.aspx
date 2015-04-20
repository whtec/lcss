<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryLineList.aspx.cs" Inherits="SalaryLineList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js"></script>
    <%--<script src="../Styles/libV1.2.3/jquery/jquery-1.7.2.min.js"></script>--%>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <%--<script src="../Styles/libV1.2.3/ligerUI/js/ligerui.all.js"></script>--%>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerGrid.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerResizable.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDrag.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerToolBar.js"></script>

    <script type="text/javascript">
        var grid = null;//主表
        //var j;
        function createGrid(divname, url) {
            $("#" + divname).remove();
            var div = "<div id='" + divname + "' style='margin:0; padding:0'></div>";
            $(document.body).append(div);

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
                //console.log(colnames);
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
            });
        }
        function operate()
        { }

        //工程类别弹出框,
        $(function () {
            createGrid("divGrid", "../Handler/SalaryHandler.ashx");
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divGrid">
        </div>
    </form>
</body>
</html>
