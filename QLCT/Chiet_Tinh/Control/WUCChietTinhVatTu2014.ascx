<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCChietTinhVatTu2014.ascx.cs" Inherits="Chiet_Tinh_Control_WUCChietTinh" %>
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
                            <ig:WebTextEditor ID="WSoVanBan" runat="server" Width="150px" Height="18px"
                            Enabled="false" ReadOnly="true" />
                        </td>
                        <td style="display:none">
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Mã khách hàng:" Width="90px" />                
                        </td>
                        <td style="display:none">
                            <ig:WebTextEditor ID="WMaKhachHang" runat="server" Width="150px" Height="18px"
                            Enabled="false" ReadOnly="true" />
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            Công tác:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLCongTac" runat="server" Width="170px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" AutoPostBack="true" 
                                onselectedindexchanged="DDLCongTac_SelectedIndexChanged" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Tên khách hàng:
                        </td>
                        <td>
                            <ig:WebTextEditor ID="WTenKhachHang" runat="server" Width="180px" Height="18px" 
                            Enabled="false" ReadOnly="true" />    
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Mã vùng:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLMaVung" runat="server" Width="50px">                                
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:DropDownList ID="DDLCongTacCon" runat="server" Width="170px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                        </td>
                        <td>
                           &nbsp;&nbsp;&nbsp;
                           Chiết tính:
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLChietTinh" runat="server" Width="180px">
                                <asp:ListItem Text="Ngành điện đầu tư" Value="0" />
                                <asp:ListItem Text="Khách hàng đầu tư" Value="1" />
                            </asp:DropDownList>                        
                        </td>                        
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            Ngày lập:
                        </td>
                        <td>
                            <ig:WebDatePicker ID="WNgayLap" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="100px" />
                        </td>
                    </tr>                    
                </table>
                <div style="padding-left: 9px; padding-top: 1px; padding-bottom: 1px; font-weight:bold">
                    Chọn vật tư và thiết bị cho bảng chiết tính                    
                </div>
                <div>
                    <div style="padding:3px;">
                        <div>
                            &nbsp;&nbsp;
                            <asp:Button ID="BThemVT" runat="server" Text="Thêm vật tư" onclick="BThemVT_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BThemVTTheoMau" runat="server" Text="Thêm vật tư theo mẫu" onclick="BThemVTTheoMau_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BXoaVT" runat="server" Text="Xóa vật tư" onclick="BXoaVT_Click" />
                        </div>
                        <div>
                            <asp:Panel ID="Panel2" runat="server" Height="350px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                            ScrollBars="Auto" style="padding-right: 2px;">
                                <asp:GridView ID="MyGrid02" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" Width="100%">
                                    <RowStyle BackColor="#EFF3FB" />                                    
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LIDVT" runat="server" 
                                                Text='<%# Eval("Ma_Chi_Phi") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chọn">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CBXoa" runat="server" Width="20px" />    
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
                                                Text='<%# Eval("So_Luong").ToString() %>' onclick="this.select();" onfocus="this.select();" />
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VT KH">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TBVTKH" runat="server" Width="30px"
                                                Text='<%# Eval("So_Luong_KH").ToString() %>' onclick="this.select();" onfocus="this.select();" />
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Giá">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TBVTGIA" runat="server" Width="60px" style="text-align:right" ReadOnly="true"
                                                Text='<%# Eval("Don_Gia").ToString() %>' onclick="this.select();" onfocus="this.select();" />
                                            </ItemTemplate>
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NC Lắp">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CBNCL" runat="server" Width="20px"
                                                Checked='<%# ChuyenCheck(Eval("NC_Lap").ToString()) %>' />    
                                            </ItemTemplate>                                                    
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NC Tháo">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CBNCT" runat="server" Width="20px"
                                                Checked='<%# ChuyenCheck(Eval("NC_Thao").ToString()) %>' />    
                                            </ItemTemplate>                                                    
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NC Khác">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CBNCK" runat="server" Width="20px"
                                                Checked='<%# ChuyenCheck(Eval("NC_Khac").ToString()) %>' />
                                                <asp:LinkButton ID="LBKTNhanCong" runat="server" Text='...' CommandName='<%# Container.DataItemIndex %>'
                                                onclick="LBKTNhanCong_Click" />
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
            onclick="BLuuBCT_Click" Width="140px" />
            &nbsp;&nbsp;
            <asp:Button ID="BInChietTinh" runat="server" Text="Lưu và In chiết tính" 
                onclick="BInChietTinh_Click" Width="130px" />
            &nbsp;&nbsp;
            <asp:Button ID="BInLaiCT" runat="server" Text="In lại chiết tính" 
                onclick="BInLaiCT_Click" Width="110px" />
            &nbsp;&nbsp;
            <asp:Button ID="BXuatExcel" runat="server" Text="Xuất Word" 
                onclick="BXuatExcel_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="BInBBNT" runat="server" Text="In BB Nghiệm Thu" 
                onclick="BInNghiemThu_Click" Width="120px" />
            &nbsp;&nbsp;
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
<ig:WebDialogWindow ID="WebDialogWindow1" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Chọn Vật Tư" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <div>
                    <asp:DropDownList ID="DDLLoaiVT" runat="server" Width="300px" 
                    DataValueField="Ma_Loai" DataTextField="Ten_Loai" AutoPostBack="true" 
                        onselectedindexchanged="DDLLoaiVT_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div style="padding-top: 10px">
                    <asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                    ScrollBars="Auto" style="padding-right: 2px;">
                        <asp:CheckBoxList ID="LBVatTu" runat="server" DataValueField="Ma_Chi_Phi" 
                        DataTextField="Ten_Chi_Phi" SelectionMode="Multiple">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </div>
                <div style="padding-top: 10px">
                    <asp:Button ID="BThem" runat="server" Text="Hoàn tất" onclick="BThem_Click" />
                    <asp:Button ID="BThoatVT" runat="server" Text="Hủy" onclick="BThoatVT_Click" />
                </div>
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>
<ig:WebDialogWindow ID="WebDialogWindow2" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Nhân công" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <asp:ListBox ID="LBDSNCVT" runat="server" Width="550px" />
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>
<ig:WebDialogWindow ID="WebDialogWindow3" runat="server" Width="400px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Thêm vật tư theo mẫu" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <div>
                    <asp:DropDownList ID="DDLLoaiCTMau" runat="server" Width="320px"
                    DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                </div>
                <div style="padding-top: 10px">
                    <asp:Button ID="BThemTheoMau" runat="server" Text="Hoàn tất" onclick="BThemTheoMau_Click" />
                    <asp:Button ID="BThoatTheoMau" runat="server" Text="Hủy" onclick="BThoatTheoMau_Click" />
                </div>
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>