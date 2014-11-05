<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="LoaiChiPhi.aspx.cs" Inherits="Chiet_Tinh_LoaiChiPhi" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCLoaiChiPhi.ascx" TagName="WUCLoaiChiPhi" TagPrefix="WUCLoaiChiPhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCLoaiChiPhi:WUCLoaiChiPhi ID="WUCLoaiChiPhi01" runat="server" />
</asp:Content>

