<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCChietTinhNew.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
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
    <div class="DQ_Box_Middle" style="padding: 0px 5px 5px 5px">               
        <div>
            <div style="padding: 2px 3px 0px 3px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td style="display:none">
                            <asp:Label ID="Label1" runat="server" Text="Số chiết tính:" Width="80px" />                
                        </td>
                        <td style="display:none">                            
                            <ig:WebTextEditor ID="WSoVanBan" runat="server" Width="200px" Height="18px"
                            Enabled="false" ReadOnly="true" />
                        </td>
                        <td style="display:none">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Mã khách hàng:" Width="90px" />                
                        </td>
                        <td style="display:none">
                            <ig:WebTextEditor ID="WMaKhachHang" runat="server" Width="200px" Height="18px"
                            Enabled="false" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Công tác:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLCongTac" runat="server" Width="200px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Tên khách hàng:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WTenKhachHang" runat="server" Width="270px" Height="18px" 
                            Enabled="false" ReadOnly="true" />    
                        </td>
                    </tr>
                    <tr>
                        <td>
                           Chiết tính:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLChietTinh" runat="server" Width="200px">
                                <asp:ListItem Text="Ngành điện chịu chi phí" Value="0" />
                                <asp:ListItem Text="Khách hàng chịu chi phí" Value="1" />
                            </asp:DropDownList>                        
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Ngày lập:
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WNgayLap" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="200px" />
                        </td>
                    </tr>                    
                </table>
                <div style="padding-left: 9px; padding-top: 1px; padding-bottom: 1px; font-weight:bold">
                    Nhập vật tư và nhân công cho bảng chiết tính                    
                </div>
                <div>
                    <div>
                        <table cellpadding="3" cellspacing="3">
                            <tr>
                                <td>
                                    Vật tư:
                                </td>
                                <td>
                                    <asp:ComboBox ID="DDVatTu" runat="server" AutoCompleteMode="SuggestAppend" 
                                        DataTextField="Ten_Chi_Phi" DataValueField="Ma_Chi_Phi" 
                                        DropDownStyle="DropDown" Width="200px">
                                    </asp:ComboBox>
                                </td>
                                <td>
                                    &nbsp;
                                    Nhân công:
                                </td>
                                <td> 
                                    <asp:ComboBox ID="DDNhanCong" runat="server" AutoCompleteMode="SuggestAppend" 
                                        DataTextField="Ten_Chi_Phi" DataValueField="Ma_Chi_Phi"
                                        DropDownStyle="DropDown" Width="220px" >
                                    </asp:ComboBox>
                                </td>                               
                                <td>
                                    &nbsp;
                                    Số lượng:
                                </td>
                                <td>
                                    <asp:TextBox ID="WSoLuong" runat="server" Width="20px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="WSoLuong" ValidationGroup="CNCP" Width="10px" />                                    
                                </td>                                
                            </tr>
                        </table>                                                
                    </div>
                    <div style="padding-right:3px;">
                        <asp:Panel ID="Panel2" runat="server" Height="270px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                        ScrollBars="Auto" style="padding-right: 2px;">
                            <ig:WebDataGrid ID="MyGrid02" runat="server" Width="100%" AutoGenerateColumns="false"
                                EnableDataViewState="True" EnableAjax="false" 
                                ondatafiltered="MyGrid02_DataFiltered"
                                oncellselectionchanged="MyGrid02_CellSelectionChanged" 
                                onrowselectionchanged="MyGrid02_RowSelectionChanged">
                                <Behaviors>
                                    <ig:Activation Enabled="true" />
                                    <ig:Selection Enabled="true" RowSelectType="Multiple">
                                        <AutoPostBackFlags CellSelectionChanged="true"
                                        RowSelectionChanged="true" />
                                    </ig:Selection>
                                    <ig:RowSelectors Enabled="true" RowNumbering="true" />                                
                                    <ig:Filtering Alignment="Top" Visibility="Visible" Enabled="true" AnimationEnabled="true" />
                                </Behaviors>
                                <Columns>
                                    <ig:BoundDataField DataFieldName="ID" Hidden="true" Key="K0">
                                        <Header Text="ID" />
                                    </ig:BoundDataField>                                
                                    <ig:TemplateDataField Key="K3">
                                        <Header Text="Nhân công" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelNC7" runat="server" 
                                            Text='<%# LayTenCP(Eval("ID_Nhan_Cong").ToString()) %>' />
                                        </ItemTemplate>
                                    </ig:TemplateDataField>
                                    <ig:TemplateDataField Key="K4">
                                        <Header Text="Vật tư" />
                                        <ItemTemplate>
                                            <asp:Label ID="LabelVT8" runat="server" 
                                            Text='<%# LayTenCP(Eval("ID_Vat_Tu").ToString()) %>' />
                                        </ItemTemplate>
                                    </ig:TemplateDataField>
                                    <ig:BoundDataField DataFieldName="So_Luong" Key="K5">
                                        <Header Text="Số lượng" />
                                    </ig:BoundDataField>                                
                                </Columns>
                            </ig:WebDataGrid>
                        </asp:Panel>
                        <div style="padding:7px; padding-left: 18px">
                            &nbsp;&nbsp;
                            <asp:Button ID="WIBThemCP" runat="server" Text="Thêm VT - NC"
                            ValidationGroup="CNCP" onclick="WIBThemCP_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="WIBSuaCP" runat="server" Text="Sửa VT - NC"
                            ValidationGroup="CNCP" onclick="WIBSuaCP_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="WIBXoaCP" runat="server" Text="Xóa VT - NC"
                            onclick="WIBXoaCP_Click" />
                        </div>
                    </div>                    
                </div>                
                <div id="Div_SqlCT" runat="server" style="display:none"></div>
                <div id="Div_ID" runat="server" style="display:none"></div>
                <asp:Label ID="LVatTu" runat="server" />
                <asp:Label ID="LNhanCong" runat="server" />
            </div>    
        </div>
        <div style="padding:3px;">
            <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
        </div>
        <div style="padding:5px;">
            <asp:Button ID="BLuuBCT" runat="server" Text="Lưu bảng chiết tính" 
            onclick="BLuuBCT_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <a id="Link_InCT" runat="server" target="_blank">Xem và in chiết tính</a>
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
<script type="text/javascript">
    function FocusHere(e, ct) {
        var evt = e ? e : window.event;
        var bt = document.getElementById(ct);
        if (bt) {
            if (evt.keyCode == 13) {
                bt.focus();
                return false;
            }
        }
    }    
</script>