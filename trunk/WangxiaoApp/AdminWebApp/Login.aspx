<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
 
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Gray" />
    <ext:Window ID="Window1" runat="server" Height="150" 
        Icon="Application" Title="管理后台登陆" Width="350" Draggable="false" 
        Closable="False" Padding="5"
            Layout="Form" Collapsed="false" Resizable="false" Modal="true">
        <items>
            <ext:TextField ID="txtUsername" AnchorHorizontal="98%"  FieldLabel="用户名" AllowBlank="false" runat="server">
            </ext:TextField>
            <ext:TextField ID="txtPasswd" AnchorHorizontal="98%"  FieldLabel="密码" InputType="Password" AllowBlank="false" runat="server">
            </ext:TextField>
        </items>
        <Buttons>
            <ext:Button ID="btnLogin"  runat="server" Text="登陆">
            <Listeners>
                <Click Handler="if (!#{txtUsername}.validate() || !#{txtPasswd}.validate()) {
                                Ext.Msg.alert('Error','必须输入用户名和密码');
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false; 
                            }"></Click>
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnLogin_Click">
                    <EventMask ShowMask="true" Msg="登录中..." MinDelay="500" />
                </Click>
            </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
 
    </form>
</body>
</html>
