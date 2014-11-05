<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCReportQTVT.ascx.cs" Inherits="Chiet_Tinh_Control_WUCReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<div>    
    <CR:CrystalReportSource ID="CRQTVT" runat="server">
        <Report FileName="~/Chiet_Tinh/Control/CRQuyetToanVT.rpt">
        </Report>        
    </CR:CrystalReportSource>
</div>