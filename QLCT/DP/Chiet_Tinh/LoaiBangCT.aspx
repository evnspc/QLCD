<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="LoaiBangCT.aspx.cs" Inherits="Chiet_Tinh_LoaiBangCT" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCLoaiBangCT.ascx" TagName="WUCLoaiBangCT" TagPrefix="WUCLoaiBangCT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCLoaiBangCT:WUCLoaiBangCT id="WUCLoaiBangCT01" runat="server" />
</asp:Content>

