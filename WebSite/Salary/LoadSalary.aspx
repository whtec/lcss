<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadSalary.aspx.cs" Inherits="LoadSalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>信息导入</title>
    <link href="../Styles/libV1.2.3/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/ligerui-icons.css" rel="stylesheet" />
    <link href="../Styles/libV1.2.3/ligerUI/skins/Gray2014/css/all.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrapg/css/bootstrap.css" />
    <link href="../Styles/bootstrapg/css/todc-bootstrap.css" rel="stylesheet" />
    <link href="../Styles/styles.css" rel="stylesheet" />
    <link href="../Styles/bootstrapg/bootstrap-datetimepicker.min.css" rel="stylesheet" />

    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Styles/bootstrapg/js/bootstrap.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/core/base.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerGrid.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerResizable.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerDrag.js"></script>
    <script src="../Styles/libV1.2.3/ligerUI/js/plugins/ligerToolBar.js"></script>
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.min.js"></script>
    <script src="../Styles/bootstrapg/bootstrap-datetimepicker.zh-CN.js"></script>
    <script>
        var onlyshow = true;
        var desdefault = '工资单';
        $(function () {
            var today = new Date();
            var date = today.getFullYear() + '-' + (today.getMonth()+1);
            var des = date + desdefault;

            $("#dateup").val(date);
            $("#dtp_input1").val(date);
            $("#txtDescription").val(des);
        });

        function ondatechange()
        {
            $("#txtDescription").val($("#dtp_input1").val()+desdefault);
        }
       
        //上传选择的excel到服务器并读取内容
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
        //检查文件格式是否有效
        function check() {
            //获得要上传的文件的扩展名
            var file = document.getElementById("file1");
            var value = file.value;
            var ext = value.substr(value.lastIndexOf(".") + 1);

            //先在客户端进行第一次判断
            if (ext == "xls" || ext == "xlsx") {
                return true;
            } else {
                $("div#alert1").slideDown("slow");
                t = setTimeout("$('div#alert1').slideUp('slow')", 4000);
                return false;
            }
        }
        //文件上传结束时触发
        function uploadFile(flag, text) {
            var form = document.getElementById("uploadForm");
            if (form != undefined) {
                form.method = "";
                form.target = "";
                //form.enctype = "";
                form.action = "";
            }
            if (!flag) {
                $("div#alert2").append(unescape(text));
                $("div#alert2").slideDown("slow");
                //t = setTimeout("$('div#alert2').slideUp('slow')", 4000);
                $("#btnImport").addClass("disabled");
            }   
            else {
                $("#btnImport").removeClass("disabled");
                createGrid(text);
            }
        }

        function createGrid(json) {
            onlyshow = false;
            showGrid(json);
        }
        //导入数据并显示
        function onclickimport() {
            $("#btnImport").addClass("disabled");
            var date = $("#dtp_input1").val();
            var des = $("#txtDescription").val();
            createGrid2("divGrid", "../Handler/SalaryHandler.ashx?opt=Import&date=" + date + "&des=" + escape(des));
        }
        function createGrid2(divname, url) {
            //onlyshow = true;
            $.getJSON(url, { Rnd: Math.random() }, showGrid);
        }
        function showGrid(json) {
            $("#divGrid").remove();
            var div = "<div id='divGrid' style='margin:0; padding:0'></div>";
            $(document.getElementById('uploadForm')).append(div);

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
                    "widht:'auto'," +
                    "rownumbers:true," +
                    "page: 1,pageSize:20,pageSizeOptions: [20,50,100,200,500]";
            //if (!onlyshow)
            //    ligergrid += ",toolbar: { items: [{ text: '导入系统', type: 'queryCond',click: onclickimport }]}";
            ligergrid += "});"
            eval(ligergrid);
        }


        //$(document).ready(function () {
        //    $("#btnRead").click(function () {
        //        $("#btnImport").removeClass("disabled");
        //        //   $('div.alert').remove();
        //    })
        //})

    </script>
</head>
<body>
    <iframe name="upfileIFrame" style="display: none"></iframe>
    <form id="uploadForm" name="uploadForm" runat="server" class="chaxun-info">
        <div class="row">
            <div class="form-group col-sm-6">
                <label for="dtp_input1" class="control-label chaxun-info-label">所属年月度：</label>
                <div class="input-group date form_date chaxun-info-input" data-date="" data-date-format="yyyy-mm" data-link-field="dtp_input1" data-link-format="yyyy-mm">
                    <input id="dateup" class="form-control" size="16" type="text" readonly datatype="*" errormsg="不能为空" />
                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                    <input type="hidden" id="dtp_input1" value="" onchange="ondatechange()" />
                </div>
            </div>
            <div class="form-group col-sm-6">
                <label for="txtDescription" class="control-label chaxun-info-label">标题：</label>
                <div class="chaxun-info-input">
                    <input id="txtDescription" type="text" class="form-control inputxt" placeholder="这里输入标题" value="" />
                </div>
            </div>
        </div>
        <div class='alert alert-danger' role='alert' id='alert1' style='display: none'>请先选择上传文件后，在读取。</div>
        <div class='alert alert-danger' role='alert' id='alert2' style='display: none'>错误提示：</div>
        <div class="row daoru">
            <input id="formSubmit" type="submit" value="submit" name="formSubmit" style="display: none" onclick="this.form.submit()" />
            <div class="form-group col-sm-5 import-file1">
                <label for="file1">1.文件上传：</label>
                <input id="file1" name="file1" type="file" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" />
                
            </div>
            <div class="form-group col-sm-5 import-btn">
                <label for="btnRead">2.</label>
                <input id="btnRead" name="btnRead" class="btn btn-primary" type="button" value="读取Excel" onclick="return onclickread();" />

            
                <label for="btnRead">3.</label>
                <input id="btnImport" name="btnImport" class="btn btn-primary disabled" type="button" value="导入Excel" onclick="onclickimport()" />

            </div>
             
        </div>
        <div id="divGrid" runat="server"></div>
    </form>
    <%--    <script src="Scripts/miao.js"></script>--%>
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
</body>
</html>
