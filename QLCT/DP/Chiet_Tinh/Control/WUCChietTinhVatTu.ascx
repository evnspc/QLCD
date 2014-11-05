<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCChietTinhVatTu.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
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
                        <td style="display:none" colspan="3">
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
                        <td colspan="3">
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
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="130px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Mã vùng:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLMaVung" runat="server" Width="70px">                                
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                            </asp:DropDownList>
                        </td>
                    </tr>                    
                </table>
                <div style="padding-left: 9px; padding-top: 1px; padding-bottom: 1px; font-weight:bold">
                    Nhập vật tư và nhân công cho bảng chiết tính                    
                </div>
                <div>
                    <div>
                    </div>
                    <div style="padding-right:3px;">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td style="vertical-align: top; width: 250px">
                                    <asp:ListBox ID="LBVatTu" runat="server" DataValueField="Ma_Chi_Phi" 
                                    DataTextField="Ten_Chi_Phi" Width="250px" Height="350px" 
                                    SelectionMode="Multiple" />        
                                </td>
                                <td style="width: 40px; vertical-align: top; padding-top: 80px">
                                    <asp:Button ID="BThem" runat="server" Text=">>" onclick="BThem_Click" />
                                    <br /><br />
                                    <asp:Button ID="BXoa" runat="server" Text="<<" onclick="BXoa_Click" />
                                </td>
                                <td style="vertical-align: top">
                                    <asp:Panel ID="Panel2" runat="server" Height="350px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                                    ScrollBars="Auto" style="padding-right: 2px;">
                                        <asp:GridView ID="MyGrid02" runat="server" AutoGenerateColumns="False" 
                                            CellPadding="4" ForeColor="#333333" 
                                            Width="100%">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LIDVT" runat="server" 
                                                        Text='<%# Eval("Ma_Chi_Phi") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tên và Qui cách vật tư">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LTenVT" runat="server" 
                                                        Text='<%# LayTenCP(Eval("Ma_Chi_Phi").ToString()) %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VT NĐ">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TBVTND" runat="server" Width="30px"
                                                        Text='<%# Eval("So_Luong").ToString() %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VT KH">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TBVTKH" runat="server" Width="30px"
                                                        Text='<%# Eval("So_Luong_KH").ToString() %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Giá">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TBVTGIA" runat="server" Width="60px" style="text-align:right"
                                                        Text='<%# Eval("Don_Gia").ToString() %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CBXoa" runat="server" Width="20px" />    
                                                    </ItemTemplate>                                                    
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#0b9fd3" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>                            
                                    </asp:Panel>        
                                </td>
                            </tr>
                        </table>                        
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
            <asp:Button ID="BInChietTinh" runat="server" Text="In chiết tính" 
                onclick="BInChietTinh_Click" />
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