<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCThongTin.ascx.cs" Inherits="ChamSocVien_Control_WUCThongTin" %>

<%@ Register Assembly="Infragistics35.WebUI.WebDataInput.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Thông tin tài khoản" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 20px 3px 30px 70px">
        <table cellpadding="3" cellspacing="3">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Mã nhân viên:" Width="80px" />                
                </td>
                <td>
                    <ig:WebTextEditor ID="WMaNhanVien" runat="server" Width="200px" Height="18px" ReadOnly="true" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Mật khẩu:" Width="90px" />                
                </td>
                <td>
                    <ig:WebTextEditor ID="WMatKhau" runat="server" Width="200px" Height="18px" TextMode="Password" />
                    <asp:CompareValidator ID="CV1" runat="server" ErrorMessage="*" ControlToValidate="WMatKhau"
                    ControlToCompare="WLapLaiMatKhau" ValidationGroup="CNThongTin" />
                </td>
            </tr>
            <tr>
                <td>
                    Họ tên:
                </td>
                <td>
                    <ig:WebTextEditor ID="WHoTen" runat="server" Width="200px" Height="18px" />
                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="*"
                    ControlToValidate="WHoTen" ValidationGroup="CNThongTin" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    Lập lại mật khẩu:
                </td>
                <td>
                    <ig:WebTextEditor ID="WLapLaiMatKhau" runat="server" Width="200px" Height="18px" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                   Địa chỉ: 
                </td>
                <td>
                   <ig:WebTextEditor ID="WDiaChi" runat="server" Width="200px" Height="18px" />
                   <asp:RequiredFieldValidator ID="RFV2" runat="server" ErrorMessage="*"
                   ControlToValidate="WDiaChi" ValidationGroup="CNThongTin" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    Điện thoại:
                </td>
                <td>
                    <ig:WebMaskEditor ID="WDienThoai" runat="server" Width="200px" Height="18px" InputMask="0000000000" />
                    <asp:CustomValidator ID="CVV1" runat="server" ErrorMessage="*"
                    ControlToValidate="WDienThoai" ValidationGroup="CNThongTin" 
                    onservervalidate="CVV1_ServerValidate" />                
                </td>
            </tr>
            <tr>
                <td>
                    Chức vụ:
                </td>
                <td>
                    <ig:WebTextEditor ID="WChucVu" runat="server" Width="200px" Height="18px" />                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                     ControlToValidate="WChucVu" ValidationGroup="CNThongTin" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;
                    Đơn vị:
                </td>
                <td>
                    <asp:DropDownList ID="DDLDonVi" runat="server" Width="200px" Enabled="false" />   
                </td>
            </tr>
            <tr>
                <td>            
                    Ghi chú:
                </td>
                <td colspan="3">
                    <ig:WebTextEditor ID="WGhiChu" runat="server" Width="500px" Height="18px" />    
                </td>
            </tr>        
        </table>
        <div style="padding-left:9px;">
            <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
        </div>
        <br />
        <div style="padding-left:18px;">
            <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi" Width="70px" 
            ValidationGroup="CNThongTin" onclick="WIBCapNhat_Click" />        
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
            onclick="BThoat_Click" />
        </div>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>