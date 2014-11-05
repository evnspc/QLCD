<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQLBangChietTinh.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
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
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true"  
        AssociatedUpdatePanelID="SUpdatePanel" DisplayAfter="200">
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
                        <asp:Label ID="Label5" runat="server" Text="Số chiết tính:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraSoVB" runat="server" Width="150px" Height="18px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Khách hàng:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTraKH" runat="server" Width="150px" Height="18px" />
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
                        <ig:WebDatePicker ID="WDTuNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                        EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                    </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Đến ngày:" Width="80px" />
                    </td>
                    <td>
                        <ig:WebDatePicker ID="WDDenNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                        EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="padding-right:3px;">
            <ig:WebDataGrid ID="MyGrid01" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableDataViewState="True" Height="350px" 
                    ondatafiltered="MyGrid01_DataFiltered" >
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection Enabled="true" RowSelectType="Multiple" />
                        <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                        <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
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
                        <ig:TemplateDataField Key="K6" Width="90px">
                            <ItemTemplate>                               
                                <asp:Label ID="Label3" runat="server" Text='<%# HienThiNgay(Eval("Ngay_Thu_Tien")) %>' />
                            </ItemTemplate>                            
                            <Header Text="N.Thực xuất" />                            
                        </ig:TemplateDataField>
                    </Columns>
            </ig:WebDataGrid>            
        </div>
        <div id="Div_SqlBCT" runat="server" style="display:none"></div>        
        <div style="margin-top: 0px">
            <div>
                <table>
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                            Ngày thực xuất: 
                            &nbsp;&nbsp;        
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WNgayThuTien" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />        
                        </td>
                    </tr>
                </table>
            </div>
            <div style="padding: 9px">
                <asp:Button ID="BCapNhat" runat="server" Text="Đã thực xuất" 
                onclick="BCapNhat_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BChuaTT" runat="server" Text="Chưa thực xuất" 
                onclick="BChuaTT_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
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