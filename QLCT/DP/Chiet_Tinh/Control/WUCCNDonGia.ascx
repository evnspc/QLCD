<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCCNDonGia.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMChiPhi" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Hỗ trợ cập nhật đơn giá" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">        
        <div>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Chọn file Excel:" Width="100px" />
                    </td>
                    <td>
                        <asp:FileUpload ID="FUL1" runat="server" Width="200px" />    
                    </td>                    
                    <td>
                        &nbsp;&nbsp;
                        <asp:Button ID="BLoadFile" runat="server" Text="Lấy dữ liệu" 
                        onclick="BLoadFile_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="Div_FN" runat="server" style="display:none"></div>
        <br />
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="false"
                EnableAjax="true" EnableDataViewState="true" 
                ondatafiltered="MyGrid01_DataFiltered">
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Single" />
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                                    
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="Ma_Chi_Phi" Key="K0">
                            <Header Text="Mã chi phí" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ma_Danh_Phap" Key="K1">
                            <Header Text="Danh pháp" />
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
                        <ig:BoundDataField DataFieldName="Loai_NC" Key="K5">
                            <Header Text="Loại NC" />
                        </ig:BoundDataField>
                    </Columns>                
                </ig:WebDataGrid>
            </asp:Panel>
        </div>
        <div style="padding: 9px;">            
            <asp:DropDownList ID="DDLLoaiCP01" runat="server" Width="150px" 
            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BDBDonGia" runat="server" Text="Đồng bộ đơn giá" 
            onclick="BDBDonGia_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BDBDuLieu" runat="server" Text="Đồng bộ dữ liệu" 
            onclick="BDBDuLieu_Click" />
        </div>
        <div style="text-align:right; padding: 7px">
            <asp:DropDownList ID="DDLLoaiCP" runat="server" Width="200px" 
            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BTraDMCP" runat="server" Text="Tra" Width="70px" 
            onclick="BTraDMCP_Click" />
        </div>
        <div>
            <div style="padding-right:3px;">
                <asp:Panel ID="PNMG02" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                ScrollBars="Auto" style="padding-right: 2px;">                
                    <ig:WebDataGrid ID="MyGrid02" runat="server" Width="100%" AutoGenerateColumns="false"
                    EnableDataViewState="true"
                    ondatafiltered="MyGrid02_DataFiltered">
                        <Behaviors>
                            <ig:Activation Enabled="true" />
                            <ig:Selection Enabled="true" RowSelectType="Single" />
                            <ig:RowSelectors Enabled="true" RowNumbering="true" /> 
                            <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                        </Behaviors>
                        <Columns>
                            <ig:BoundDataField DataFieldName="Ma_Chi_Phi" Key="K1">
                                <Header Text="Mã chi phí" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Ma_Danh_Phap" Key="K11">
                                <Header Text="Danh pháp" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Ten_Chi_Phi" Key="K2">
                                <Header Text="Tên chi phí" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Don_Gia" Key="K3">
                                <Header Text="Đơn giá" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="DVT" Key="K4" Width="50px">
                                <Header Text="ĐVT" />
                            </ig:BoundDataField>
                            <ig:BoundDataField DataFieldName="Loai_NC" Key="K5">
                                <Header Text="Loại NC" />
                            </ig:BoundDataField>
                        </Columns>
                    </ig:WebDataGrid>
                </asp:Panel>
            </div>
        </div>        
    </div>      
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>
<ig:WebDialogWindow ID="WDWThongBao" runat="server" WindowState="Hidden" 
Width="350px" Height="200px" InitialLocation="Centered" MaintainLocationOnScroll="True" 
Modal="True" UseBodyAsParent="True">
    <ContentPane>
        <Template>
            <div style="text-align:center; padding-top:50px;">
                <div>
                    <asp:Label ID="LThongBao" runat="server" />
                </div>
            </div>            
        </Template>
    </ContentPane>
    <Header CaptionText="Thông báo" />
</ig:WebDialogWindow>
