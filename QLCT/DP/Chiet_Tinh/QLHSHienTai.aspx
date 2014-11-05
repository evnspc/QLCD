<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLHSHienTai.aspx.cs" Inherits="Chiet_Tinh_QLHSHienTai" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQDApDung.ascx" TagName="WUCQDApDung" TagPrefix="WUCQDApDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQDApDung:WUCQDApDung ID="WUCQDApDung01" runat="server" />
</asp:Content>

