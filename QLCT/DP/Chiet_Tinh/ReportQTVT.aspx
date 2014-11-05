<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportQTVT.aspx.cs" Inherits="Chiet_Tinh_Report" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCReportQTVT.ascx" TagName="WUCReportQTVT" TagPrefix="WUCReportQTVT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <WUCReportQTVT:WUCReportQTVT ID="WUCReportQTVT01" runat="server" />         
        </div>
    </form>
</body>
</html>
