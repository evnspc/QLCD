<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCKhachHang.ascx.cs" Inherits="Chiet_Tinh_Control_WUCKhachHang" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics35.WebUI.WebDataInput.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig1" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý khách hàng" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">        
        <div>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Mã yêu cầu:" Width="100px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraMaKH" runat="server" Width="150px" Height="18px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Tên khách hàng:" Width="100px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraTenKH" runat="server" Width="150px" Height="18px" />
                    </td>
                    <td rowspan="2">
                        &nbsp;&nbsp;
                        <asp:Button ID="BTra" runat="server" Text="Tra cứu" onclick="BTra_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Từ ngày:" Width="100px" />
                    </td>
                    <td>
                        <ig:WebDatePicker ID="WTuNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text="Đến ngày:" Width="100px" />
                    </td>
                    <td>
                        <ig:WebDatePicker ID="WDenNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                    </td>                    
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="200px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
            <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="false" EnableAjax="false"
                DataKeyFields="Ma_KH" EnableDataViewState="true" >
                    <Behaviors>                       
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                    </Behaviors>
                    <Columns>
                        <ig:TemplateDataField Key="K0" Width="65px">
                            <ItemTemplate>
                                <asp:Button ID="BChonDongKH" runat="server" Text="Chọn KH" Width="65px"
                                onclick="BChonDongKH_Click" ToolTip='<%# Eval("Ma_KH") %>' />    
                            </ItemTemplate>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="Ma_KH" Key="K1">
                            <Header Text="Mã yêu cầu" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ho_Ten" Key="K2">
                            <Header Text="Họ tên" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Dia_Chi" Key="K3">
                            <Header Text="Địa chỉ" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ghi_Chu" Key="K4">
                            <Header Text="Mã đơn vị" />
                        </ig:BoundDataField>                    
                    </Columns>
            </ig:WebDataGrid>
            </asp:Panel>
        </div>
        <div>
            <div style="padding: 20px 3px 0px 30px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Mã trạm:" Width="50px" />                
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WMaKH" runat="server" Width="200px" Height="18px" Visible="false" ReadOnly="true" />
                            <ig:WebTextEditor ID="WMaTram" runat="server" Width="100px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="WMaTram" ValidationGroup="KiemTraKhachHang" />
                            <asp:Button ID="BMaTram" runat="server" Text="..." onclick="BMaTram_Click" />
                        </td>
                        
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Họ tên:" Width="50px" />                
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WHoTen" runat="server" Width="300px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="WHoTen" ValidationGroup="KiemTraKhachHang" />
                            <asp:Button ID="BHoTen" runat="server" Text="..." onclick="BHoTen_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Danh số KH:" Width="80px" />                
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WDoanhSo" runat="server" Width="100px" Height="18px" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BDanhSo" runat="server" Text="..." onclick="BDanhSo_Click" />                            
                        </td>
                        <td>
                           &nbsp;&nbsp;&nbsp;
                           Địa chỉ:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WDiaChi" runat="server" Width="300px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="WDiaChi" ValidationGroup="KiemTraKhachHang" />
                        </td>
                    </tr>                                      
                </table>                
                <div style="padding-left:9px; padding-top: 18px;">
                    <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
                </div>
                <br />
                <div style="padding-left:18px;">                    
                    <asp:Button ID="WIBThemMoi" runat="server" Text="Thêm mới" 
                    Width="100px" ValidationGroup="KiemTraKhachHang" onclick="WIBThemMoi_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Lưu" 
                    Width="100px" ValidationGroup="KiemTraKhachHang" onclick="WIBCapNhat_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBXoa" runat="server" Text="Xóa" 
                    Width="100px" ValidationGroup="KiemTraKhachHang" onclick="WIBXoa_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBLapMoi" runat="server" Text="Lập mới bảng chiết tính" 
                    Width="180px" onclick="WIBLapMoi_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
                    onclick="BThoat_Click" />
                </div>
                <div id="Div_Sql" runat="server" style="display:none"></div>
            </div>
        </div>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>

<ig:WebDialogWindow ID="WebDialogWindow2" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Danh sách mã trạm" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <asp:ListBox ID="LBDSTram" runat="server" Width="550px" Height="200px" 
                DataTextField="TTen_Tram" DataValueField="Ma_Tram" />                
                <asp:Button ID="BChonTram" runat="server" Text="Chọn trạm" onclick="BChonTram_Click" />
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>

<ig:WebDialogWindow ID="WebDialogWindow3" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Danh sách khách hàng chờ khảo sát" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Từ ngày:" Width="60px" />
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WebDatePicker1" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                                EditModeFormat="dd/MM/yyyy" Nullable="False" Width="100px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="Đến ngày:" Width="60px" />
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WebDatePicker2" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                                EditModeFormat="dd/MM/yyyy" Nullable="False" Width="100px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:Button ID="BTraCuuKH" runat="server" Text="Tra cứu" onclick="BTraCuuKH_Click" />
                        </td>
                    </tr>
                </table>
                <asp:ListBox ID="LBDSKhachHang" runat="server" Width="550px" Height="200px"
                DataTextField="ho_ten" DataValueField="ma_ycau_knai" />                
                <asp:Button ID="BChonKH" runat="server" Text="Chọn khách hàng" onclick="BChonKH_Click" />
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>

<ig:WebDialogWindow ID="WebDialogWindow4" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Danh số liền kề" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Label ID="Label10" runat="server" Text="Mã sổ:" Width="100px" />
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WSoSeri01" runat="server" Width="150px" Height="18px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:Button ID="BTraCuuDanhSo" runat="server" Text="Tra cứu danh số" onclick="BTraCuuDanhSo_Click" />
                        </td>
                    </tr>
                </table>
                <div style="padding: 10px">
                    <asp:ListBox ID="LBDSDanhSo" runat="server" Width="550px" Height="200px"
                    DataTextField="Ten_DS" DataValueField="DANHSO" />
                </div>
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>