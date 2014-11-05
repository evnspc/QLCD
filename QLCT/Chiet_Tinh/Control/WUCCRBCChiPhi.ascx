<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCCRBCChiPhi.ascx.cs" Inherits="Chiet_Tinh_Control_WUCReport" %>
<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<div style="text-align:left; width:100%">
    <div>        
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Báo cáo vật tư" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style="padding: 0px 5px 5px 5px">               
        <div>
            <div style="padding: 2px 3px 0px 3px">
                <table style="vertical-align:top">
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                            Từ ngày xuất:
                            &nbsp;&nbsp;
                        </td>
                        <td>                
                            <ig:WebDatePicker ID="WDTuNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            Đến ngày xuất:  
                            &nbsp;&nbsp;              
                        </td>
                        <td>                
                            <ig:WebDatePicker ID="WDDenNgay" runat="server" DisplayModeFormat="dd/MM/yyyy" 
                            EditModeFormat="dd/MM/yyyy" Nullable="False" Width="150px" />
                        </td>
                        
                        <td>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="BTraCuu" runat="server" Text="Báo cáo" 
                            onclick="BTraCuu_Click" />                            
                        </td>            
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;
                            Loại công tác:  
                            &nbsp;&nbsp;              
                        </td>
                        <td>                
                            <asp:DropDownList ID="DDLCongtac" runat="server" Width="200px"
                            DataTextField="Ten_Loai" DataValueField="Ma_Loai" />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            Loại chiết tính:  
                            &nbsp;&nbsp;              
                        </td>
                        <td>                
                            <asp:DropDownList ID="DDLLChietTinh" runat="server" Width="200px">
                                <asp:ListItem Text="Tất cả" Value="2" />
                                <asp:ListItem Text="Ngành điện đầu tư" Value="0" />
                                <asp:ListItem Text="Khách hàng đầu tư" Value="1" />
                            </asp:DropDownList>
                        </td>
                    </tr>        
                </table>
            </div>            
            <div style="display:none">
                <CR:CrystalReportViewer ID="CRV1" runat="server" AutoDataBind="True" 
                Height="50px" Width="350px" DisplayGroupTree="False" DisplayToolbar="False" />
                <CR:CrystalReportSource ID="CRSND" runat="server">
                    <Report FileName="~/Chiet_Tinh/Control/CRBaoCaoCP.rpt">
                    </Report>        
                </CR:CrystalReportSource>
            </div>
        </div>        
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>