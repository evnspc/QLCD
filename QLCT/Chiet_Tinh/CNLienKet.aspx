<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="CNLienKet.aspx.cs" Inherits="Chiet_Tinh_CNDonGia" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCCNLienKet.ascx"TagName="WUCCNLienKet" TagPrefix="WUCCNLienKet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCCNLienKet:WUCCNLienKet ID="WUCCNLienKet01" runat="server" />
</asp:Content>

