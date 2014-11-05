<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCBaoCaoCT.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Báo cáo thống kê bảng chiết tính" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">        
        <div>
            <table width="100%">
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Đơn vị:" Width="80px" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLDonVi" runat="server" Width="160px"
                        DataTextField="Ten_Don_Vi" DataValueField="Ma_Don_Vi" />                        
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Loại công tác:" Width="80px" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLLoaiCongTac" runat="server" Width="160px"
                        DataValueField="Ma_Cong_Tac" DataTextField="Ten_Cong_Tac" />

                    </td>
                    <td rowspan="2">
                        &nbsp;&nbsp;
                        <asp:Button ID="BTra" runat="server" Text="Tra cứu" onclick="BTra_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Từ ngày:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebDatePicker ID="WTuNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="160px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Đến ngày:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebDatePicker ID="WDenNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="160px" />
                    </td>                    
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableDataViewState="True" 
                    ondatafiltered="MyGrid01_DataFiltered" >
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Single" />
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="So_Van_Ban" Key="K1">
                            <Header Text="Số chiết tính" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ho_Ten" Key="K2">
                            <Header Text="Khách hàng" />
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Ten_Cong_Tac" Key="K3">
                            <Header Text="Công tác" />
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="K4">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# HienThiLCT(Eval("Loai_Chiet_Tinh").ToString()) %>' />
                            </ItemTemplate>
                            <Header Text="Loại chiết tính" />
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="K5">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# HienThiNgay(Eval("Ngay_Lap")) %>' />
                            </ItemTemplate>
                            <Header Text="Ngày lập" />
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="Ten_Don_Vi" Key="K6">
                            <Header Text="Đơn vị" />
                        </ig:BoundDataField>                    
                    </Columns>
                </ig:WebDataGrid>
            </asp:Panel>
        </div>
        <div id="Div_SqlBCT" runat="server" style="display:none"></div>        
        <div style="margin-top: 0px">
            <div style="padding: 9px">
                <asp:Button ID="BInChietTinh" runat="server" Text="In chiết tính" Visible="false"
                    onclick="BInChietTinh_Click" />
                
                <asp:Button ID="BCapNhat" runat="server" Text="Sửa bảng chiết tính" Visible="false"
                    onclick="BCapNhat_Click" />                
                
                <asp:Button ID="BXoa" runat="server" Text="Xóa bảng chiết tính" Visible="false"
                    onclick="BXoa_Click" />
                
                <asp:Button ID="BQuyetToan" runat="server" Text="Quyết toán vật tư" Visible="false"
                    onclick="BQuyetToan_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BBBQuyetToan" runat="server" Text="Biên bản nghiệm thu" Visible="false"
                onclick="BBBQuyetToan_Click" />

                <asp:Button ID="BExport" runat="server" Text="Xuất Excel" Width="90px" 
                    onclick="BExport_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
                    onclick="BThoat_Click" />
                <asp:Button ID="BCapNhatGia" runat="server" Text="Cập nhật lại giá mới" Visible="false"
                    onclick="BCapNhatGia_Click" />      
            </div>    
        </div>        
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>
<ig:WebExcelExporter ID="WebExcelExporter1" runat="server"
 DataExportMode="DataInGridOnly" ExportMode="Download" WorkbookFormat="Excel97To2003">
</ig:WebExcelExporter>
