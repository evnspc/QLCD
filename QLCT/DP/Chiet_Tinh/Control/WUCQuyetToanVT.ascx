<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQuyetToanVT.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Quyết toán vật tư bảng chiết tính" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style="padding: 0px 5px 5px 5px">               
        <div>
            <div style="padding: 2px 3px 0px 3px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Số chiết tính:" Width="80px" />                
                        </td>
                        <td>                            
                            <asp:Label ID="WSoVanBan" runat="server" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Tên khách hàng:" Width="120px" />                
                        </td>
                        <td>
                            <asp:Label ID="WTenKhachHang" runat="server" />
                        </td>
                    </tr>                    
                </table>                
                <div>
                    <div>
                    </div>
                    <div style="padding-right:3px;">
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
                                                <asp:TemplateField HeaderText="VT Ngành điện">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TBVTND" runat="server" style="text-align:right" 
                                                        Text='<%# Eval("So_Luong").ToString() %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VT Khách hàng">
                                                    <ItemTemplate>
                                                        <asp:Label ID="TBVTKH" runat="server" style="text-align:right"
                                                        Text='<%# Eval("So_Luong_KH").ToString() %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="VT Quyết toán">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="QTVT" runat="server" style="text-align:right"
                                                        Text='<%# Eval("Quyet_Toan").ToString() %>' />
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
                    </div>                    
                </div>                
                <div id="Div_SqlCT" runat="server" style="display:none"></div>
            </div>    
        </div>
        <div style="padding:3px;">
            <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
        </div>
        <div style="padding:5px;">
            <asp:Button ID="BLuuBCT" runat="server" Text="Lưu bảng quyết toán" 
            onclick="BLuuBCT_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BInChietTinh" runat="server" Text="In bảng quyết toán" 
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