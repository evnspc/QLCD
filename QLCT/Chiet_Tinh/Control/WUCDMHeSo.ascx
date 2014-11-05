<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCDMHeSo.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMDonVi" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.WebUI.WebDataInput.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý hệ số" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true"  
        AssociatedUpdatePanelID="SUpdatePanel" DisplayAfter="500">
            <ProgressTemplate>
                <ig:WebDialogWindow ID="WebDialogWindow1" runat="server"  
                Height="150px" Width="200px" Modal="True" Moveable="False" 
                    InitialLocation="Centered" MaintainLocationOnScroll="True">
                    <ContentPane>
                        <Template>
                            <div style=" text-align:center; vertical-align:middle; padding-top: 20px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Chiet_Tinh/Style/Img/loading.gif" />    
                                <div style="padding-top:5px;">Vui lòng chờ...</div>
                            </div>                                
                        </Template>
                    </ContentPane>
                </ig:WebDialogWindow>                    
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="SUpdatePanel" runat="server">
        <ContentTemplate>
        <div>
            <div style="padding: 20px 3px 0px 30px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Mã vùng:" Width="100px"
                            Font-Bold="true" />                
                        </td>
                        <td>                            
                            <asp:DropDownList ID="DDLMaVung" runat="server" Width="200px"
                            DataTextField="Ma_Vung" DataValueField="Ma_Vung" AutoPostBack="True" 
                                onselectedindexchanged="DDLMaVung_SelectedIndexChanged" />    
                        </td>                        
                    </tr>                    
                    <tr>
                        <td colspan="2" style="font-weight:bold; padding: 7px;">
                           Công thức chiết tính:
                        </td>                        
                    </tr>
                    <tr>                        
                        <td>
                            H.Số Nhân công:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WHSNhanCong" runat="server" Width="200px" Height="18px" 
                                HorizontalAlign="Right" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="WHSNhanCong" ValidationGroup="CNDMHeSo" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ErrorMessage="*" ControlToValidate="WHSNhanCong" ValidationGroup="CNDMHeSo" 
                                onservervalidate="CustomValidator1_ServerValidate" />
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="2" style="font-weight:bold; padding: 7px;">
                           Ngành điện chịu chi phí:
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Chi phí chung 1:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WCPChung1" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            ControlToValidate="WCPChung1" ValidationGroup="CNDMHeSo" />
                            &nbsp; x NC (Tổng chi phí nhân công)
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Chi phí chung 2:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WCPChung2" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="WCPChung2" ValidationGroup="CNDMHeSo" />
                            &nbsp; x NC (Tổng chi phí nhân công)
                        </td>                        
                    </tr>
                    <tr>
                        <td colspan="2" style="font-weight:bold; padding: 7px;">
                           Khách hàng chịu chi phí:
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Phí trực tiếp khác:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WPhiTrucTiepKhac" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                            ControlToValidate="WPhiTrucTiepKhac" ValidationGroup="CNDMHeSo" />
                            &nbsp; x (VL + NC + M) (Tổng CP vật liệu + Nhân công + Máy thi công)
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Chi phí chung:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WCPChung" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                            ControlToValidate="WCPChung" ValidationGroup="CNDMHeSo" />
                            &nbsp; x NC (Tổng chi phí nhân công)
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Thu nhập chịu thuế:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WTNChiuThue" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                            ControlToValidate="WTNChiuThue" ValidationGroup="CNDMHeSo" />
                            &nbsp; x (T + C) (Tổng CP Trực tiếp + Chi phí chung)
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Khảo sát chiết tính:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WKSChietTinh" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                            ControlToValidate="WKSChietTinh" ValidationGroup="CNDMHeSo" />
                            &nbsp; x (T + C + TL) (Tổng CP Trực tiếp + CP Chung + TN Chịu thuế)
                        </td>                        
                    </tr>                   
                </table>                
                <div style="padding-left:9px; padding-top: 18px;">
                    <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
                </div>
                <br />
                <div style="padding-left:18px;">                    
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi" 
                    Width="100px" ValidationGroup="CNDMHeSo" 
                    onclick="WIBCapNhat_Click" />
                    &nbsp;&nbsp;                    
                    <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
                    onclick="BThoat_Click" />
                </div>
            </div>    
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>