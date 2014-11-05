<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCTaiKhoan.ascx.cs" Inherits="CSKH_Control_WUCTaiKhoan" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.WebUI.WebDataInput.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý tài khoản" />
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
        <div style="padding-top:7px; text-align:left; padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
                <ig:WebDataGrid ID="MyGRV01" runat="server" Width="100%" DataKeyFields="Tai_Khoan" 
                AutoGenerateColumns="False" EnableDataViewState="True"  
                    oncellselectionchanged="MyGRV01_CellSelectionChanged" 
                    onrowselectionchanged="MyGRV01_RowSelectionChanged" 
                    ondatafiltered="MyGRV01_DataFiltered" >
                    <Behaviors>                    
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Multiple" Enabled="true" >
                            <SelectionClientEvents CellSelectionChanged="MyGRV01_CellSelectionChanged"
                            RowSelectionChanged="MyGRV01_RowSelectionChanged" />
                        </ig:Selection>
                        <ig:RowSelectors RowNumbering="true" Enabled="true" />
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="Tai_Khoan" DataType="System.String" 
                        Key="Tai_Khoan">
                            <Header Text="Tài khoản" />
                        </ig:BoundDataField>
                         <ig:BoundDataField DataFieldName="Ho_Ten" DataType="System.String" 
                        Key="Ho_Ten">
                            <Header Text="Họ tên" />
                        </ig:BoundDataField>                                   
                        <ig:BoundDataField DataFieldName="Dien_Thoai" DataType="System.String" 
                        Key="Dien_Thoai">
                            <Header Text="Điện thoại" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ten_Don_Vi" DataType="System.String" 
                        Key="Ten_Don_Vi">
                            <Header Text="Tên đơn vị" />
                        </ig:BoundDataField>                    
                        <ig:TemplateDataField Key="T06">
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# ChuyenLoaiTaiKhoan(Eval("Loai_Tai_Khoan").ToString()) %>' />
                            </ItemTemplate>                
                            <Header Text="Loại tài khoản" />
                        </ig:TemplateDataField>                    
                    </Columns>                
                </ig:WebDataGrid>
            </asp:Panel>
        </div>
        <div style="padding: 20px 3px 0px 30px">        
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Tài khoản:" Width="80px" />                
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTaiKhoan" runat="server" Width="200px" Height="18px" />
                        <asp:RequiredFieldValidator ID="RFV0" runat="server" ErrorMessage="*"
                        ControlToValidate="WTaiKhoan" ValidationGroup="CNThongTin" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Họ tên:" Width="90px" />                
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WHoTen" runat="server" Width="200px" Height="18px" />
                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ErrorMessage="*"
                        ControlToValidate="WHoTen" ValidationGroup="CNThongTin" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Mật khẩu:
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WMatKhau" runat="server" Width="200px" Height="18px" TextMode="Password" />
                        <asp:CompareValidator ID="CV1" runat="server" ErrorMessage="*" ControlToValidate="WMatKhau"
                        ControlToCompare="WLapLaiMatKhau" ValidationGroup="CNThongTin" />
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
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        Đơn vị:
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLDonVi" runat="server" Width="200px" />   
                    </td>
                </tr>
                <tr>
                    <td>            
                        Ghi chú:
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WGhiChu" runat="server" Width="200px" Height="18px" />    
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;
                        Quyền:
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLQuyen" runat="server" Width="200px">
                            <asp:ListItem Text="Nhân viên chiết tính" Value="0" />
                            <asp:ListItem Text="Nhân viên quản lý" Value="1" />
                            <asp:ListItem Text="Nhân viên vật tư" Value="4" />
                            <asp:ListItem Text="Lãnh đạo ký" Value="2" />
                            <asp:ListItem Text="Quản trị viên" Value="3" />                            
                        </asp:DropDownList>                       
                    </td>
                </tr>        
            </table>
            <div style="padding-left:9px;">
                <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
            </div>
            <br />
            <div style="padding-left:18px;">
                <asp:Button ID="WIBThemMoi" runat="server" Text="Thêm mới" 
                Width="100px" ValidationGroup="CNThongTin" onclick="WIBThemMoi_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi" 
                Width="100px" ValidationGroup="CNThongTin" 
                onclick="WIBCapNhat_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="WIBXoa" runat="server" Text="Xóa" 
                Width="100px" ValidationGroup="CNThongTin" onclick="WIBXoa_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
                onclick="BThoat_Click" />
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
<script type="text/javascript">
    function MyGRV01_CellSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
    function MyGRV01_RowSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
</script>

