﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SALES_MANAGEMENT.Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 538px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1"  runat="server" AsyncRendering="false" BorderStyle="None" Font-Size="Large" Height="462px" PrimaryButtonBackgroundColor="" style="margin-right: 0px; margin-bottom: 0px" Width="2335px" ZoomMode="PageWidth"></rsweb:ReportViewer>
    </form>
</body>
</html>
