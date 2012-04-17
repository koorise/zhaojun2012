  <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Dictionary_Category" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var getTasks = function (tree) {
        var msg = [],
                selNodes = tree.getChecked();
        msg.push("[");

        Ext.each(selNodes, function (node) {
            if (msg.length > 1) {
                msg.push(","); 
            } 
            msg.push(node.id);
        });

        msg.push("]");

        return msg.join("");
    };
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
     
    <ext:FormPanel ID="FormPanel1" runat="server" ButtonAlign="Right" Region="Center"   Padding="5"
        Title="分类字典管理" >
        <Items> 
            <ext:TextField ID="txtParentID"  FieldLabel="目录ID" AnchorHorizontal="100%"  Disabled="true"  runat="server">
            </ext:TextField>
            <ext:TextField ID="txtParent"  FieldLabel="选择目录" AnchorHorizontal="100%"  Disabled="true"  runat="server">
            </ext:TextField>
            <ext:TextField ID="txtSelf" FieldLabel="名称" AnchorHorizontal="100%" runat="server">
            </ext:TextField>

        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Icon="Disk"  Text="同级目录">
                <DirectEvents>
                    <Click OnEvent="btn_Click1"></Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button2" runat="server" Icon="DiskBlack"  Text="子目录">
                <DirectEvents>
                    <Click OnEvent="btn_Click2"></Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button3" runat="server" Icon="Delete"  Text="删除">
                <DirectEvents>
                    <Click OnEvent="btn_Click3"></Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</asp:Content>

