<%@ Page Title="" Language="C#" MasterPageFile="~/Chiet_Tinh/MasterPage.master" AutoEventWireup="true" CodeFile="BaoCaoThongKe.aspx.cs" Inherits="Chiet_Tinh_QLKhachHang" %>

<%@ Register Src="~/Chiet_Tinh/Control/WUCBaoCaoCT.ascx" TagName="WUCBaoCaoCT" TagPrefix="WUCBaoCaoCT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <WUCBaoCaoCT:WUCBaoCaoCT ID="WUCBaoCaoCT01" runat="server" />
</asp:Content>

