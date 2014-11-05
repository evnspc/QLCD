<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="CRBaoCaoCP.aspx.cs" Inherits="NhanVien_Default" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCCRBCChiPhi.ascx" TagName="WUCCRBCChiPhi" TagPrefix="WUCCRBCChiPhi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <WUCCRBCChiPhi:WUCCRBCChiPhi ID="WUCCRBCChiPhi01" runat="server" />
</asp:Content>

