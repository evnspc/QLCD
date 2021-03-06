﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCNhomLoaiCP.ascx.cs" Inherits="Chiet_Tinh_Control_WUCLoaiChiPhi" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý nhóm loại chi phí" />
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
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right:2px;">
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="false"
                EnableDataViewState="true" EnableAjax="false" 
                    oncellselectionchanged="MyGrid01_CellSelectionChanged" 
                    ondatafiltered="MyGrid01_DataFiltered" 
                    onrowselectionchanged="MyGrid01_RowSelectionChanged">
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
                        <ig:BoundDataField DataFieldName="Ma_Loai" Key="K1">
                            <Header Text="Mã loại" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ten_Loai" Key="K2">
                            <Header Text="Tên loại" />
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
                            <asp:Label ID="Label1" runat="server" Text="Mã loại:" Width="100px" />                
                        </td>
                        <td>                            
                            <ig:WebTextEditor ID="WMaLoai" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RFV0" runat="server" ErrorMessage="*"
                            ControlToValidate="WMaLoai" ValidationGroup="CNLoaiCongTac" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Tên loại:" Width="90px" />                
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WTenLoai" runat="server" Width="200px" Height="18px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="WTenLoai" ValidationGroup="CNLoaiCongTac" />
                        </td>
                    </tr>                                                                       
                </table>                
                <div style="padding-left:9px; padding-top: 18px;">
                    <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
                </div>
                <br />
                <div style="padding-left:18px;">                    
                    <asp:Button ID="WIBThemMoi" runat="server" Text="Thêm mới" 
                    Width="100px" ValidationGroup="CNLoaiCongTac" onclick="WIBThemMoi_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi" 
                    Width="100px" ValidationGroup="CNLoaiCongTac" 
                    onclick="WIBCapNhat_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="WIBXoa" runat="server" Text="Xóa" 
                    Width="100px" ValidationGroup="CNLoaiCongTac" onclick="WIBXoa_Click" />
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