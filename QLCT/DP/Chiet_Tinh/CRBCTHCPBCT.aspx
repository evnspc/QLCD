<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRBCTHCPBCT.aspx.cs" Inherits="Chiet_Tinh_Report" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI" TagPrefix="ig" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCCRBTHCPBCT.ascx" TagName="WUCCRBCChiPhi" TagPrefix="WUCCRBCChiPhi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ig:WebScriptManager ID="WebScriptManager1" runat="server" />
        <div>
            <WUCCRBCChiPhi:WUCCRBCChiPhi ID="WUCCRBCChiPhi01" runat="server" />
        </div>
    </form>
</body>
</html>
