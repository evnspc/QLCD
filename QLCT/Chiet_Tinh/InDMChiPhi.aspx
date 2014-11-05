<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InDMChiPhi.aspx.cs" Inherits="Chiet_Tinh_InDMChiPhi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="~/Chiet_Tinh/Control/WUCRPDMCP.ascx" TagName="WUCRPDMCP" TagPrefix="WUCRPDMCP" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <WUCRPDMCP:WUCRPDMCP ID="WUCRPDMCP01" runat="server" />
        </div>
    </form>
</body>
</html>
