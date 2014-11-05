<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLKhachHang.aspx.cs" Inherits="Chiet_Tinh_QLKhachHang" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCKhachHang.ascx" TagName="WUCKhachHang" TagPrefix="WUCKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCKhachHang:WUCKhachHang id="WUCKhachHang01" runat="server" />
</asp:Content>

