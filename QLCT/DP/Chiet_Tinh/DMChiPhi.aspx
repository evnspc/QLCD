<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="DMChiPhi.aspx.cs" Inherits="Chiet_Tinh_DMChiPhi" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCDMChiPhi.ascx" TagName="WUCDMChiPhi" TagPrefix="WUCDMChiPhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCDMChiPhi:WUCDMChiPhi ID="WUCDMChiPhi01" runat="server" />
</asp:Content>

