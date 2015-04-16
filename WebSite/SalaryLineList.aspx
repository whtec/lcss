<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalaryLineList.aspx.cs" Inherits="SalaryLineList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <script src="Scripts/jquery.min.js"></script>
    <script src="Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="Styles/libV1.2.3/ligerUI/js/ligerui.all.js"></script>

    <script type="text/javascript">
        var initstate = 0; //加载状态        
        var Grid; //主表

        var grid = null;
        var j;
        function creategrid(divname, url) {
            $("#" + divname).remove();
            var div = "<div id='" + divname + "' style='margin:0; padding:0'></div>";
            $(document.body).append(div);

            $.getJSON(url, { page: 1, pagesize: 10, Rnd: Math.random() },
            function (json) {
                var colnames = ",{ display: '行号', name:'Row', minWidth: 100 ,frozen:true}";
                colnames += ",{ display: '工号', name:'Emp_Code', minWidth: 100 ,frozen:true}";
                colnames += ",{ display: '姓名', name:'Emp_Name', minWidth: 100 ,frozen:true}";
                for (var i in json.Rows[0]) //在这里读json的列名，当作表格的列名
                {
                    if (!(i == 'RECORDCOUNT' || i == 'PASSWORD' || i == 'Row' || i == 'Emp_Code' || i == 'Emp_Name'))
                        colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 100}";
                }
                colnames = colnames.substr(1, colnames.length);
                j = json;
                eval(
                        "grid=$('#" + divname + "').ligerGrid({" +
                        "checkbox: true," +
                        "columns:[" + colnames + "]," +  //然后么拼字符串   
                        "toolbar: { items: [{ text: '导出Execl', type: 'queryCond', click: operate }]}," +
                        //"data:j,"+    //这么写适合不分页的grid,还少读一次数据库
                        "url:'" + url + "'," +
                        "dataAction:'server'," +
                        "height:'auto'," +
                        "pageSize:10,pageSizeOptions: [10, 15, 20, 30, 50, 100]" +
                        "});"
                    );
            });
        }
        function operate()
        { }

        //工程类别弹出框,
        $(function () {
            //CreateGrid();
            creategrid("divGrid", "Handler/SalaryHandler.ashx");
        });
        function CreateGrid() {
            grid = $("#divGrid").ligerGrid({
                async: false,
                height: "auto",
                columns: [
                { display: "行号", name: "Row", minWidth: 100, frozen: true },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60, frozen: true },
                { display: "姓名", name: "Emp_Name", minWidth: 60, frozen: true },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "工号", name: "Emp_Code", minWidth: 40, width: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 },
                { display: "姓名", name: "Emp_Name", minWidth: 60 }
                ],
                toolbar: {
                    items: [
                    { text: "综合查询", icon: "search2", type: "queryCond", click: operate },
                    { line: true },
                    { text: "全部查询", icon: "search2", type: "queryAll", click: operate },
                    { line: true },
                    { text: '清空', icon: 'back', type: "clearText", click: operate },
                    { line: true },
                    { text: "导出Execl", icon: "outexecl", type: "outExecl", click: operate }
                    ]
                },
                url: "Handler/SalaryHandler.ashx",
                dataAction: "server",
                usePager: true,
                page: 1,
                pageSizeOptions: [10, 20, 50, 100],
                pageSize: 20,
                frozen: false,
                rownumbers: true
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divGrid">
        </div>
    </form>
</body>
</html>
