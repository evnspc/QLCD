<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="DMDonVi.aspx.cs" Inherits="Chiet_Tinh_DMDonVi" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCDMDonVi.ascx" TagName="WUCDMDonVi" TagPrefix="WUCDMDonVi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCDMDonVi:WUCDMDonVi ID="WUCDMDonVi01" runat="server" />
</asp:Content>

