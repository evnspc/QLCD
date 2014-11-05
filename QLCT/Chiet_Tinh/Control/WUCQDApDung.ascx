<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQDApDung.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMDonVi" %>
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
            <asp:Label ID="LTieuDe" runat="server" Text="Quyết định áp dụng" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style=" padding: 5px 5px 20px 5px">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true"  
        AssociatedUpdatePanelID="SUpdatePanel" DisplayAfter="500">
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
            <div style="padding: 20px 3px 0px 30px">        
                <table cellpadding="3" cellspacing="3">
                    <tr>
                        <td colspan="4" style="font-weight:bold; padding: 7px;">
                           Quyết định vật tư:
                        </td>                        
                    </tr>
                    <tr>                        
                        <td>
                            QĐ:
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="DDLQDVT" runat="server" Width="200px"
                            DataTextField="Ten_Quyet_Dinh" DataValueField="Ma_Quyet_Dinh"/>    
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="4" style="font-weight:bold; padding: 7px;">
                           Quyết định nhân công:
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            QD:
                        </td>
                        <td colspan="3">                            
                            <asp:DropDownList ID="DDLQDNC" runat="server" Width="200px"
                            DataTextField="Ten_Quyet_Dinh" DataValueField="Ma_Quyet_Dinh"/>
                        </td>                        
                    </tr>
                    <tr>
                        <td colspan="4" style="font-weight:bold; padding: 7px;">
                           Quyết định hệ số bảng tổng hợp:
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            QD:
                        </td>
                        <td colspan="3">                            
                            <asp:DropDownList ID="DDLQDHS" runat="server" Width="200px"
                            DataTextField="Ten_Quyet_Dinh" DataValueField="Ma_Quyet_Dinh"/>
                        </td>                        
                    </tr>                    
                </table>                
                <div style="padding-left:9px; padding-top: 18px;">
                    <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
                </div>
                <br />
                <div style="padding-left:18px;">                    
                    <asp:Button ID="WIBCapNhat" runat="server" Text="Ghi"  
                    Height="24px" Width="100px" ValidationGroup="CNDMHeSo" onclick="WIBCapNhat_Click" />
                </div>
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
<script type="text/javascript">
    function MyGrid01_CellSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
    function MyGrid01_RowSelectionChanged(webDataGrid, evntArgs) {
        __doPostBack('<%= SUpdatePanel.ClientID %>', '');
    }
</script>