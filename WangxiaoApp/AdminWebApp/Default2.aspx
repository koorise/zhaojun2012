<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <ext:XScript runat="server">
        <script type="text/javascript">
            var addTab = function (tabPanel, id, url, menuItem) {
                var tab = tabPanel.getComponent(id);

                if (!tab) {
                    tab = tabPanel.add({ 
                        id       : id, 
                        title    : url, 
                        closable : true,
                        menuItem : menuItem,
                        loader   : {
                            url      : url,
                            renderer : "frame",
                            loadMask : {
                                showMask : true,
                                msg      : "Loading " + url + "..."
                            }
                        }
                    });

                    tab.on("activate", function (tab) {
                        #{MenuPanel1}.setSelection(tab.menuItem);
                    });
                }
            
                tabPanel.setActiveTab(tab);
            }
        </script>
    </ext:XScript>
</head>
<body>
    <form id="form1" runat="server">
   <ext:ResourceManager runat="server" />
        
        <ext:Window 
            runat="server" 
            Title="Adding tab"
            Width="700" 
            Height="500" 
            Icon="Link" 
            Layout="BorderLayout">
            <Items>
                <ext:MenuPanel 
                    ID="MenuPanel1" 
                    runat="server" 
                    Width="200" 
                    Region="West">
                    <Menu id="Menu1" runat="server">
                        <Items>
                            <ext:MenuItem runat="server" Text="Ext.NET">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, 'idClt', 'http://www.ext.net', this);" />
                                </Listeners>
                            </ext:MenuItem>
                            
                            <ext:MenuSeparator />
                            
                            <ext:MenuItem runat="server" Text="Ext.NET forums">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, 'idGgl', 'http://forums.ext.net', this);" />
                                </Listeners>
                            </ext:MenuItem>
                            
                            <ext:MenuSeparator />
                            
                            <ext:MenuItem runat="server" Text="Sencha">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, 'idExt', 'http://www.sencha.com', this);" />
                                </Listeners>
                            </ext:MenuItem>
                        </Items>
                    </Menu>
                </ext:MenuPanel>
                <ext:TabPanel ID="TabPanel1" runat="server" Region="Center" />
            </Items>
        </ext:Window>
    </form>
</body>
</html>
