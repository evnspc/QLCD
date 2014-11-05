<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUCQLThongBao.ascx.cs" Inherits="Chiet_Tinh_Control_WUCDMDonVi" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div style="text-align:left; width:100%">
    <div>
        <div class="DQ_Box_Top_Left"></div>
        <div class="DQ_Box_Top_Right"></div>
        <div class="DQ_Box_Top_Center" style="padding-left:8px;">            
            <asp:Label ID="LTieuDe" runat="server" Text="Quản lý thông báo" />
        </div>
    </div>
    <div class="DQ_Box_Middle" style="padding: 5px 5px 20px 5px">
        <div>
            <CKEditor:CKEditorControl ID="CKThongTin" runat="server" Height="400px"
            BasePath="~/ckeditor" Width="98%"></CKEditor:CKEditorControl>    
        </div>
        <div style="padding-left:7px; padding-top: 10px; padding-bottom: 10px">
            <asp:Label ID="LThongBao" runat="server" ForeColor="Red" />
        </div>
        <div>
            <asp:Button ID="BCapNhat" runat="server" Text="Cập nhật" Width="90px" 
                onclick="BCapNhat_Click" />
        </div>
    </div>    
    <div>
        <div class="DQ_Box_Bottom_Left"></div>
        <div class="DQ_Box_Bottom_Right"></div>
        <div class="DQ_Box_Bottom_Center"></div>
    </div>    
</div>