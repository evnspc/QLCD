<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQLBCT.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>

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
            <asp:Label ID="LTieuDe" runat="server" Text="Bảng chiết tính" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">        
        <div>
            <table>
                <tr>
                    <td>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="Số chiết tính:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraSoVB" runat="server" Width="450px" Height="18px" />
                    </td>                    
                    <td>
                        &nbsp;&nbsp;
                        <asp:Button ID="BTra" runat="server" Text="Chọn" onclick="BTra_Click" />
                    </td>
                </tr>                
            </table>
        </div>
        <br />
        <div style="padding-right:3px;">
            <asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
            ScrollBars="Auto" style="padding-right: 2px;">
                <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableDataViewState="True">
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Multiple" />
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                    </Behaviors>
                    <Columns>
                        <ig:BoundDataField DataFieldName="So_Van_Ban" Key="K1" Width="90px">
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
                        <ig:TemplateDataField Key="K5" Width="60px">
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# HienThiNgay(Eval("Ngay_Lap")) %>' />
                            </ItemTemplate>
                            <Header Text="Ngày lập" />
                        </ig:TemplateDataField>                        
                    </Columns>
                </ig:WebDataGrid>
            </asp:Panel>
        </div>
        <div id="Div_SqlBCT" runat="server" style="display:none"></div>        
        <div style="margin-top: 0px">
            <div>
                <table width="100%" style="text-align:left">
                    <tr>
                        <td style="width: 100px;">
                            &nbsp;&nbsp;Ngày thực xuất:&nbsp;&nbsp;
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WNgayThuTien" runat="server" 
                            DisplayModeFormat="dd/MM/yyyy" EditModeFormat="dd/MM/yyyy" Nullable="False" 
                            Width="150px" />
                        </td>
                        <td style="text-align:right; padding-right: 9px">
                            <asp:Button ID="BXoaChon" runat="server" Text="Xóa chọn" 
                            onclick="BXoaChon_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding: 9px">
                <asp:Button ID="BCapNhat" runat="server" Text="Lưu và lập báo cáo" 
                onclick="BCapNhat_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BThoat" runat="server" Text="Thoát" Width="70px" 
                onclick="BThoat_Click" />
            </div>    
        </div>
        <ig:WebDialogWindow ID="WebDialogWindow2" runat="server"   
                Modal="True" Moveable="False" Width="500px" Height="200px"  
                InitialLocation="Centered" MaintainLocationOnScroll="True" 
                WindowState="Hidden">
                    <ContentPane>
                        <Template>
                            <div style=" text-align:center; vertical-align:middle;">
                                <div id="WMSG" style="padding:10px;" runat="server">
                                    Bảng chiết tính này đã có ngày thực xuất rồi không thể chọn nữa, vui lòng kiểm tra lại.
                                </div>
                            </div>                                
                        </Template>
                    </ContentPane>
                    <Header CaptionText="Thông báo" />
        </ig:WebDialogWindow>        
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>