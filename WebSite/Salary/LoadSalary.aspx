<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadSalary.aspx.cs" Inherits="LoadSalary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>信息导入</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:FileUpload ID="FileUpload1" runat="server"  />--%>
            <label id="lbl1" runat="server" style="width: 200px"></label>
            <input id="File1" type="file" runat="server" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" />
            <input id="btnRead" type="button" value="读取Excel" runat="server" onserverclick="btnRead_ServerClick" />
            <input id="btnImport" type="button" value="导入系统" runat="server" onserverclick="btnImport_ServerClick" />
        </div>
        <asp:GridView ID="gvExcel" runat="server">
            <Columns>
                <%-- <asp:ImageField DataImageUrlField="是否匹配" DataImageUrlFormatString="image/img1.jpg" HeaderText="是否匹配">
                </asp:ImageField>--%>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
