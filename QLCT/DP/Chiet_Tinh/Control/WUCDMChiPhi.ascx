<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCDMChiPhi.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMChiPhi" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Danh mục chi phí" />
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
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Mã chi phí:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraMaCP" runat="server" Width="100px" Height="18px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Tên chi phí:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraTenCP" runat="server" Width="150px" Height="18px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Loại:" Width="50px" />
                    </td>
                    <td>
                        <asp:DropDownList ID="WTraLoaiCP" runat="server" Width="100px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BTra" runat="server" Text="Tra cứu" onclick="BTra_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-right: 3px;">
            <asp:Panel ID="Panel1" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right:2px;">            
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="false"
                EnableAjax="false" oncellselectionchanged="MyGrid01_CellSelectionChanged" 
                    onrowselectionchanged="MyGrid01_RowSelectionChanged" EnableDataViewState="true"
                    ondatafiltered="MyGrid01_DataFiltered">
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Single">
                            <SelectionClientEvents CellSelectionChanged="MyGrid01_CellSelectionChanged" 
                            RowSelectionChanged="MyGrid01_RowSelectionChanged" />
                        </ig:Selection>
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="Ma_Chi_Phi" Key="K0">
                            <Header Text="Mã chi phí" />
                        </ig:BoundDataField>                        
                        <ig:BoundDataField DataFieldName="Ten_Chi_Phi" Key="K2">
                            <Header Text="Tên chi phí" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Don_Gia" Key="K3">
                            <Header Text="Đơn giá" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DVT" Key="K4">
                            <Header Text="ĐVT" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ten_Loai" Key="K5">
                            <Header Text="Loại" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Khong_Su_Dung" Key="K6">
                            <Header Text="Không dùng" />
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
                            <asp:Label ID="Label1" runat="server" Text="Mã chi phí:" Width="100px" />                
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WMaCP" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RFV0" runat="server" ErrorMessage="*"
                            ControlToValidate="WMaCP" ValidationGroup="CNChiPhi" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Tên chi phí:" Width="90px" />                
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WTenCP" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="WTenCP" ValidationGroup="CNChiPhi" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Đơn giá:
                        </td>
                        <td>                            
                            <ig:WebNumericEditor ID="WDonGia" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="WDonGia" ValidationGroup="CNChiPhi" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            ĐVT:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WDVT" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="WDVT" ValidationGroup="CNChiPhi" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Loại:
                        </td>
                        <td>                            
                            <asp:DropDownList ID="DDLLoai" runat="server" Width="200px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Không dùng:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WThuongDung" runat="server" Width="200px" Height="18px" />                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mã định mức:
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WMaDinhMuc" runat="server" Width="200px" Height="18px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Loại NC:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WLoaiNC" runat="server" Width="200px" Height="18px" />                            
                        </td>
                    </tr>                                     
                </table>
                <div id="StrSql" runat="server" style="display:none"></div>                
                <div style="padding-left:9px; padding-top: 18px;">
                    <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
                </div>
                <br />
                <div style="padding-left:18px;">
                    <asp:Button ID="WIBThemMoi" runat="server" Text="Thêm mới"
                    Width="100px" ValidationGroup="CNChiPhi" 
                    onclick="WIBThemMoi_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi"
                    Width="100px" ValidationGroup="CNChiPhi" 
                    onclick="WIBCapNhat_Click" />                    
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBXoa" runat="server" Text="Xóa"
                    Width="100px" ValidationGroup="CNChiPhi" 
                    onclick="WIBXoa_Click" />
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
<script type="text/javascript">
    function MyGrid01_CellSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
    function MyGrid01_RowSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
</script>