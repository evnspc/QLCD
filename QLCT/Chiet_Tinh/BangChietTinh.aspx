<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="BangChietTinh.aspx.cs" Inherits="Chiet_Tinh_BangChietTinh" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCChietTinhVatTu2014.ascx" TagName="WUCChietTinh" TagPrefix="WUCChietTinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCChietTinh:WUCChietTinh ID="WUCChietTinh01" runat="server" />
</asp:Content>

