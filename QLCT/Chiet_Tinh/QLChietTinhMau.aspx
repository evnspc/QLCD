<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLChietTinhMau.aspx.cs" Inherits="Chiet_Tinh_CNDonGia" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLChietTinhMau.ascx" TagName="WUCQLChietTinhMau" TagPrefix="WUCQLChietTinhMau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLChietTinhMau:WUCQLChietTinhMau ID="WUCQLChietTinhMau01" runat="server" />
</asp:Content>

