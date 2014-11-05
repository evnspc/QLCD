<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics35.Web.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.Web.UI" TagPrefix="ig" %>

<%@ Register assembly="Infragistics35.WebUI.WebDataInput.v10.3, Version=10.3.20103.1013, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebDataInput" tagprefix="igtxt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chương trình chiết tính</title>
</head>
<body style="margin:0">
    <form id="form1" runat="server">    
        <ig:WebScriptManager ID="WebScriptManager1" runat="server" />
        <div style="background-image:url('bg.jpg'); height: 130px; padding-top: 120px; padding-left: 100px;"> 
            <asp:Image ID="Image1" runat="server" ImageUrl="logo.png" />               
        </div>
        <div style="background-image:url('bg.jpg'); height: 250px; padding-top:50px;
        padding-left:25px; background-repeat:repeat-x; text-align:center">
            <table cellpadding="5" cellspacing="2" style="margin:auto">
                <tr>
                    <td>
                        Tài khoản:
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WTaiKhoan" runat="server" 
                        Height="18px" Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Mật khẩu:
                    </td>
                    <td>
                        <ig:WebTextEditor ID="WMatKhau" runat="server" 
                        TextMode="Password" Height="18px" Width="200px" />
                    </td>
                </tr>                          
            </table>
            <div style="padding-left:9px;">
                <asp:Label ID="LMsg" runat="server" ForeColor="red" />                
            </div>
            <br />
            <div style="padding-left:18px; margin:auto; text-align:center">
                <asp:Button ID="WIBDangNhap" runat="server" Text="Đăng nhập" 
                onclick="WIBDangNhap_Click" />
            </div>
        </div>
    </form>
</body>
</html>
