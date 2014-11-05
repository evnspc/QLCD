<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="TraCuuBangCT.aspx.cs" Inherits="Chiet_Tinh_BangChietTinh" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLBangChietTinh.ascx" TagName="WUCQLBangChietTinh" TagPrefix="WUCQLBangChietTinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLBangChietTinh:WUCQLBangChietTinh ID="WUCQLBangChietTinh01" runat="server" />
</asp:Content>

