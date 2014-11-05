<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQLLienKet.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMDonVi" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý liên kết" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style="padding: 5px 5px 20px 5px">
        <table style="width: 100%">
            <tr>
                <td style="vertical-align: top">
                    <div>
                        <asp:DropDownList ID="DDLLoaiCT" runat="server" Width="280px"
                        DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                    </div>
                    <div>
                        <asp:ListBox ID="LBDSVatTu" runat="server" Height="350px" Width="280px" 
                            DataTextField="Ten_Chi_Phi" DataValueField="Ma_Chi_Phi" 
                        onselectedindexchanged="LBDSVatTu_SelectedIndexChanged" AutoPostBack="True" />
                    </div>
                </td>
                <td style="vertical-align: top; width: 100%">
                    <div style="width: 100%">
                        <asp:Panel ID="Panel2" runat="server" Height="330px" Width="100%" BorderStyle="Solid" BorderColor="Silver" BorderWidth="1px"
                            ScrollBars="Auto" style="padding-right: 2px;">
                                <asp:GridView ID="MyGrid02" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" Width="100%">
                                    <RowStyle BackColor="#EFF3FB" />                                    
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="LIDVT" runat="server" 
                                                Text='<%# Eval("Ma_Nhan_Cong") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chọn">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CBXoa" runat="server" Width="30px" />    
                                            </ItemTemplate>                                                    
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tên và Qui cách nhân công">
                                            <ItemTemplate>
                                                <asp:Label ID="LTenVT" runat="server" 
                                                Text='<%# LayTenCP(Eval("Ma_Nhan_Cong").ToString()) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tỉ lệ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TBTiLe" runat="server" Width="30px"
                                                Text='<%# Eval("Ti_Le").ToString() %>' onclick="this.select();" onfocus="this.select();" />
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" />
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
                    <div style="padding-top: 10px">
                        <asp:Button ID="BThem" runat="server" Text="Thêm mới" Width="90px" 
                            onclick="BThem_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BCapNhat" runat="server" Text="Cập nhật" Width="90px" 
                            onclick="BCapNhat_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="BXoa" runat="server" Text="Xóa" Width="90px" 
                            onclick="BXoa_Click" />   
                    </div>       
                </td>
            </tr>
        </table>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>

<ig:WebDialogWindow ID="WebDialogWindow2" runat="server" Width="600px"
WindowState="Hidden" InitialLocation="Centered" >
    <Header CaptionText="Nhân công" />
    <ContentPane>
        <Template>
            <div style="padding: 10px; text-align: left">
                <asp:ListBox ID="LBDSNCVT" runat="server" Width="550px" Height="300px"
                DataTextField="Ten_Chi_Phi" DataValueField="Ma_Chi_Phi" SelectionMode="Multiple" />
            </div>
            <div>
                <asp:Button ID="BThemNC" runat="server" Text="Thêm mới" Width="90px" 
                onclick="BThemNC_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="BThoatNC" runat="server" Text="Thoát" Width="90px" 
                onclick="BThoatNC_Click" />    
            </div>    
        </Template>
    </ContentPane>
</ig:WebDialogWindow>