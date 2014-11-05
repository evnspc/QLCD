<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCReportEx.ascx.cs" Inherits="Chiet_Tinh_Control_WUCReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<div style="padding:7px;">
    <asp:DropDownList ID="DDLLoaiFile" runat="server" Width="100px">
        <asp:ListItem Text="PDF" Value="PDF" Selected="True" />
        <asp:ListItem Text="Word" Value="DOC" />
        <asp:ListItem Text="Excel" Value="XLS" />
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BLuuBC" runat="server" onclick="BLuuBC_Click" Text="Lưu và In báo cáo" />
    <div id="Div_File" style="display:none" runat="server"></div>
</div>
<div>    
    <CR:CrystalReportViewer ID="CRV1" runat="server" AutoDataBind="True" 
    Height="50px" Width="350px" DisplayGroupTree="False" DisplayToolbar="False" />
    <CR:CrystalReportSource ID="CRSND" runat="server">
        <Report FileName="~/Chiet_Tinh/Control/CrystalReportND.rpt">
        </Report>        
    </CR:CrystalReportSource>
    <CR:CrystalReportSource ID="CRSKH" runat="server">
        <Report FileName="~/Chiet_Tinh/Control/CrystalReportKH.rpt">
        </Report>
    </CR:CrystalReportSource>         
</div>