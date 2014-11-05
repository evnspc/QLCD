<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="KhachHang.aspx.cs" Inherits="Chiet_Tinh_KhachHang" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCKhachHang.ascx" TagName="WUCKhachHang" TagPrefix="WUCKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCKhachHang:WUCKhachHang ID="WUCKhachHang01" runat="server" />
</asp:Content>

