<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QuyetDinh.aspx.cs" Inherits="Chiet_Tinh_QuyetDinh" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQuyetDinh.ascx" TagName="WUCQuyetDinh" TagPrefix="WUCQuyetDinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQuyetDinh:WUCQuyetDinh ID="WUCQuyetDinh01" runat="server" />
</asp:Content>

