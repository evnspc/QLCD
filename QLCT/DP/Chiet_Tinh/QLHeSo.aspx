<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLHeSo.aspx.cs" Inherits="Chiet_Tinh_QLHeSo" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCDMHeSo.ascx" TagName="WUCDMHeSo" TagPrefix="WUCDMHeSo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCDMHeSo:WUCDMHeSo ID="WUCDMHeSo01" runat="server" />
</asp:Content>

