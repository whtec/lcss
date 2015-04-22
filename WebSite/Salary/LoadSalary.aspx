<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadSalary.aspx.cs" Inherits="LoadSalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>信息导入</title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/ligerui.all.js"></script>
    <script>
        var onlyshow = true;
        function onclickimport() {
            createGrid2("divGrid", "../Handler/SalaryHandler.ashx?opt=Import")
        };
        function onclickread() {
            if (check()) {
                var form = document.getElementById("uploadForm")
                form.method = "post";
                form.target = "upfileIFrame";
                form.enctype = "multipart/form-data";
                form.action = "../Handler/UpLoadFile.ashx?opt=readExcel";
                uploadForm.formSubmit.click();
            }
        }
        function uploadFile(flag, text) {
            var form = document.getElementById("uploadForm");
            if (form != undefined) {
                form.method = "";
                form.target = "";
                //form.enctype = "";
                form.action = "";
            }
            if (!flag)
                alert(unescape(text));
            else {
                createGrid(text);
            }
        }

        function createGrid(json) {
            onlyshow = false;
            showGrid(json);
        }

        function createGrid2(divname, url) {
            onlyshow = true;
            $.getJSON(url, { Rnd: Math.random() }, showGrid);
        }
        function showGrid(json) {
            $("#divGrid").remove();
            var div = "<div id='divGrid' style='margin:0; padding:0'></div>";
            $(document.body).append(div);

            var colnames = ",{ display: '是否匹配', name:'是否匹配', minWidth: 50 ,width: 80,frozen:true}";
            colnames += ",{ display: '工号', name:'工号', minWidth: 50 ,width: 80,frozen:true}";
            colnames += ",{ display: '姓名', name:'姓名', minWidth: 50 ,width: 80,frozen:true}";
            for (var i in json.Rows[0]) //在这里读json的列名，当作表格的列名
            {
                if (i.indexOf("时间") > 0) {
                    colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 80 ,width: 80 ,type:'date' }";
                    continue;
                }
                if (!(i == '是否匹配' || i == '工号' || i == '姓名' || i == '序号'))
                    colnames += ",{name:'" + i + "',display:'" + i + "', minWidth: 50 ,width: 80}";
            }
            colnames = colnames.substr(1, colnames.length);
            //console.log(colnames);
            var ligergrid = "grid=$('#divGrid').ligerGrid({" +
                    "checkbox: false," +
                    "columns:[" + colnames + "]," +
                    "data:json," +
                    "dataAction:'local'," +
                    "height:'auto'," +
                    "rownumbers:true," +
                    "page: 1,pageSize:100,pageSizeOptions: [100,200,500]";
            if (!onlyshow)
                ligergrid += ",toolbar: { items: [{ text: '导入系统', type: 'queryCond',click: onclickimport }]}";
            ligergrid += "});"
            eval(ligergrid);
        }

        function check() {
            //获得要上传的文件的扩展名
            var file = document.getElementById("file1");
            var value = file.value;
            var ext = value.substr(value.lastIndexOf(".") + 1);

            //先在客户端进行第一次判断
            if (ext == "xls" || ext == "xlsx") {
                return true;
            } else {
                alert("禁止");
                return false;
            }
        }


    </script>
</head>
<body>
    <iframe name="upfileIFrame" style="display: none"></iframe>
    <form id="uploadForm" name="uploadForm" runat="server">
        <input id="formSubmit" type="submit" value="submit" name="formSubmit" style="display: none" onclick="this.form.submit()" />
        <input id="file1" name="file1" type="file" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" />
        <input id="btnRead" name="btnRead" type="button" value="读取Excel" onclick="return onclickread();" />
        <div id="divGrid" runat="server"></div>
    </form>
</body>
</html>
