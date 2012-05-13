<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PowerPage.aspx.cs" Inherits="Admin_PowerPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register TagPrefix="ext" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.3.0.1840, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        var getTasks = function () {
            var msg = "",
                selNodes = TreePanel1.getChecked();

            Ext.each(selNodes, function (node) {
                if (msg.length > 0) {
                    msg += ", ";
                }

                msg += node.text;
            });
            
            Ext.Msg.show({
                title: "Completed Tasks",
                msg: msg.length > 0 ? msg : "None",
                icon: Ext.Msg.INFO,
                minWidth: 200,
                buttons: Ext.Msg.OK
            });
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <ext:TreePanel ID= "TreePanel1" Layout="fit" runat="server"  Height="350" AutoScroll="True" ButtonAlign="Right" >
    <Listeners>
        <Render Handler="this.getRootNode().expand(true);" Delay="50" />
    </Listeners>

        <Buttons>
            <ext:Button runat="server" Text="分配权限">
                
                <DirectEvents>
                    <Click OnEvent="BtnAdd" Delay="500"></Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:TreePanel> 
        
</asp:Content>

