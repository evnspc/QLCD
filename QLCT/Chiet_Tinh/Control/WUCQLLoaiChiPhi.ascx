<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQLLoaiChiPhi.ascx.cs" Inherits="Chiet_Tinh_Control_WUCQLLoaiChiPhi" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý loại chi phí" />
        </div>
    </div>    
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">
                <div style="padding-right:3px;">
                    <table cellpadding="5" cellspacing="0" width="100%">
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <div>
                                    <asp:DropDownList ID="DDLLoaiChiPhi" runat="server" Width="320px"
                                    DataTextField="Ten_Loai" DataValueField="Ma_Loai" AutoPostBack="true" 
                                    onselectedindexchanged="DDLLoaiChiPhi_SelectedIndexChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <asp:ListBox ID="LBVatTu" runat="server" DataValueField="Ma_Chi_Phi" 
                                DataTextField="Ten_Chi_Phi" Width="320px" Height="350px" 
                                SelectionMode="Multiple" />        
                            </td>
                            <td style="width: 40px; vertical-align: top; padding-top: 80px">
                                <asp:Button ID="BThem" runat="server" Text=">>" onclick="BThem_Click" />
                                <br /><br />
                                <asp:Button ID="BXoa" runat="server" Text="<<" onclick="BXoa_Click" />
                            </td>
                            <td style="vertical-align: top">                                
                                <div>
                                    <asp:ListBox ID="LBVTCP" runat="server" DataValueField="Ma_Chi_Phi" 
                                    DataTextField="Ten_Chi_Phi" Width="320px" Height="350px" 
                                    SelectionMode="Multiple" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>