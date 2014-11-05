<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLLoaiCTMau.aspx.cs" Inherits="Chiet_Tinh_CNDonGia" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCLoaiCTMau.ascx" TagName="WUCLoaiCTMau" TagPrefix="WUCLoaiCTMau" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCLoaiCTMau:WUCLoaiCTMau ID="WUCLoaiCTMau01" runat="server" />
</asp:Content>

