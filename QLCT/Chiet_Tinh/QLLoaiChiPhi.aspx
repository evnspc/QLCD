<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLLoaiChiPhi.aspx.cs" Inherits="Chiet_Tinh_CNDonGia" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLLoaiChiPhi.ascx" TagName="WUCQLLoaiChiPhi" TagPrefix="WUCQLLoaiChiPhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLLoaiChiPhi:WUCQLLoaiChiPhi ID="WUCQLLoaiChiPhi01" runat="server" />
</asp:Content>

