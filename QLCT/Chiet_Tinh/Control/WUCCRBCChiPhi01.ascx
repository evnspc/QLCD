<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCCRBCChiPhi01.ascx.cs" Inherits="Chiet_Tinh_Control_WUCReport" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<div>
    <div style="padding:7px; padding-top: 18px;">
        <asp:DropDownList ID="DDLLoaiFile" runat="server" Width="100px">
            <asp:ListItem Text="PDF" Value="PDF" Selected="True" />
            <asp:ListItem Text="Word" Value="DOC" />
            <asp:ListItem Text="Excel" Value="XLS" />
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BLuuBC" runat="server" onclick="BLuuBC_Click" Text="Lưu và In báo cáo" />
    </div>
    <div>
        <CR:CrystalReportViewer ID="CRV1" runat="server" AutoDataBind="True" 
        Height="50px" Width="350px" DisplayGroupTree="False" DisplayToolbar="False" />
        <CR:CrystalReportSource ID="CRSND" runat="server">
            <Report FileName="~/Chiet_Tinh/Control/CRBaoCaoCP.rpt">
            </Report>        
        </CR:CrystalReportSource>
    </div>
</div>