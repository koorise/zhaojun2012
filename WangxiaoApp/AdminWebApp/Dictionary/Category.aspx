  <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Dictionary_Category" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <script type="text/javascript">
        var refreshTree = function (tree) {
            Ext.net.DirectMethods.RefreshMenu({
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        tree.initChildren(nodes);
                    }
                    else {
                        tree.getRootNode().removeChildren();
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ext:ResourceManagerProxy ID="ResourceManagerProxy1" runat="server">
    </ext:ResourceManagerProxy>
<ext:Viewport ID="Viewport1" runat="server">
        <Items>
    <ext:ColumnLayout ID="ColumnLayout1"  runat="server">
    <Columns>
        <ext:LayoutColumn ColumnWidth="0.7"> 
            <ext:TreePanel ID="TreePanel1" runat="server"  AutoScroll="True"    Title="分类目录"  >
            
            <Root></Root>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button ID="Button4" runat="server" Text="全部展开">
                            <Listeners>
                                <Click Handler="#{TreePanel1}.expandAll();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button5" runat="server" Text="全部折叠">
                            <Listeners>
                                <Click Handler="#{TreePanel1}.collapseAll();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Listeners>
                <Click Handler="#{txtParent}.setValue(node.text,false);#{txtParentID}.setValue(node.id,false);"></Click>
            </Listeners>
            </ext:TreePanel> 
        </ext:LayoutColumn>
        <ext:LayoutColumn ColumnWidth="0.3"> 
           <ext:FormPanel ID="FormPanel1" runat="server" Frame="True" ButtonAlign="Center"   Padding="5"
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
                    <ext:Button ID="Button1" runat="server" Icon="Disk"  Text="子目录">
                        <DirectEvents>
                            <Click OnEvent="btn_Click1"></Click>
                        </DirectEvents>
                        <Listeners>
                            <Click Handler="#{txtSelf}.reset();" Delay="500" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Icon="BookEdit"  Text="编辑">
                        <DirectEvents>
                            <Click OnEvent="btn_Click2"></Click>    
                        </DirectEvents>
                        <Listeners>
                            <Click Handler="#{txtSelf}.reset();refreshTree(#{TreePanel1});" Delay="500">
                            </Click>
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button3" runat="server" Icon="Delete"  Text="删除">
                        <DirectEvents>
                            <Click OnEvent="btn_Click3"></Click>
                        </DirectEvents>
                        <Listeners>
                            <Click Handler="refreshTree(#{TreePanel1});" Delay="500">
                            </Click>
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </ext:LayoutColumn> 
        </Columns>
    </ext:ColumnLayout>
    </Items>
    </ext:Viewport>
     
    
</asp:Content>

