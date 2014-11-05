<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCKHExpress.ascx.cs" Inherits="Chiet_Tinh_Control_WUCKHExpress" %>

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
    <div style=" padding: 5px 5px 20px 5px">        
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
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Mã khách hàng:" Width="100px" />
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
                    <td>
                        &nbsp;&nbsp;
                        <asp:Button ID="BTra" runat="server" Text="Tra cứu" onclick="BTra_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="false"
                DataKeyFields="Ma_KH" EnableDataViewState="true"
                    oncellselectionchanged="MyGrid01_CellSelectionChanged" 
                    onrowselectionchanged="MyGrid01_RowSelectionChanged" 
                    ondatafiltered="MyGrid01_DataFiltered">
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Single" >
                            <SelectionClientEvents CellSelectionChanged="MyGrid01_CellSelectionChanged" 
                            RowSelectionChanged="MyGrid01_RowSelectionChanged" />
                        </ig:Selection>
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="Ma_KH" Key="K1">
                            <Header Text="Mã khách hàng" />
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
            <div style="padding: 10px;">
                <asp:Button ID="BChon" runat="server" Text="Chọn Khách Hàng Này" 
                    onclick="BChon_Click" />    
            </div>
        </div>
        <div>
            <div style="padding: 20px 3px 0px 30px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Mã khách hàng:" Width="100px" />                
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WMaKH" runat="server" Width="200px" Height="18px" Enabled="false" ReadOnly="true" />                            
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Họ tên:" Width="90px" />                
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WHoTen" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="WHoTen" ValidationGroup="KiemTraKhachHang" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                           Địa chỉ:
                        </td>
                        <td colspan="3">
                            <ig:WebTextEditor ID="WDiaChi" runat="server" Width="530px" Height="18px" />
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
                    <asp:Button ID="WIBThemMoi" runat="server" Text="Thêm mới" Width="100px" 
                    ValidationGroup="KiemTraKhachHang" onclick="WIBThemMoi_Click" />                
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Cập nhật" Width="100px"
                    ValidationGroup="KiemTraKhachHang" onclick="WIBCapNhat_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBXoa" runat="server" Text="Xóa" Width="100px"
                    ValidationGroup="KiemTraKhachHang" onclick="WIBXoa_Click" />                    
                </div>
                <div id="Div_Sql" runat="server" style="display:none"></div>
            </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>        
    </div>    
</div>
<script type="text/javascript">
    function MyGrid01_CellSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
    function MyGrid01_RowSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
</script>