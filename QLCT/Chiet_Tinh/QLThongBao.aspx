<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLThongBao.aspx.cs" Inherits="Chiet_Tinh_QLKhachHang" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLThongBao.ascx" TagName="WUCQLThongBao" TagPrefix="WUCQLThongBao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLThongBao:WUCQLThongBao ID="WUCQLThongBao01" runat="server" />
</asp:Content>

