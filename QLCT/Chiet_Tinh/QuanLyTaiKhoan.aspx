<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QuanLyTaiKhoan.aspx.cs" Inherits="Chiet_Tinh_QuanLyTaiKhoan" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCTaiKhoan.ascx" TagName="WUCTaiKhoan" TagPrefix="WUCTaiKhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCTaiKhoan:WUCTaiKhoan ID="WUCTaiKhoan01" runat="server" />
</asp:Content>

