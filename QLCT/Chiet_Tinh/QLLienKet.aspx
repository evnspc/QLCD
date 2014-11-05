<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLLienKet.aspx.cs" Inherits="Chiet_Tinh_CNDonGia" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLLienKet.ascx" TagName="WUCQLLienKet" TagPrefix="WUCQLLienKet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLLienKet:WUCQLLienKet ID="WUCQLLienKet01" runat="server" />
</asp:Content>

