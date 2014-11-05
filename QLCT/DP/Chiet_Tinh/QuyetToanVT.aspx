<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QuyetToanVT.aspx.cs" Inherits="Chiet_Tinh_BangChietTinh" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQuyetToanVT.ascx" TagName="WUCQuyetToanVT" TagPrefix="WUCQuyetToanVT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQuyetToanVT:WUCQuyetToanVT ID="WUCQuyetToanVT01" runat="server" />
</asp:Content>

