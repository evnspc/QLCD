<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="QLBangChietTinh.aspx.cs" Inherits="Chiet_Tinh_QLBangChietTinh" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCQLBCT.ascx" TagName="WUCQLBCT" TagPrefix="WUCQLBCT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCQLBCT:WUCQLBCT ID="WUCQLBCT01" runat="server" />
</asp:Content>

