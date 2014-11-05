<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="LoaiCongTac.aspx.cs" Inherits="Chiet_Tinh_LoaiCongTac" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCLoaiCongTacCon.ascx" TagName="WUCLoaiCongTac" TagPrefix="WUCLoaiCongTac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCLoaiCongTac:WUCLoaiCongTac ID="WUCLoaiCongTac01" runat="server" />
</asp:Content>

