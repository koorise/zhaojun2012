<%@ Page Title="在线考试系统 管理员后台面板" Language="C#" MasterPageFile="~/MasterPage.master"   AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var addTab = function (tabPanel, id, url,titles) {
        var tab = tabPanel.getComponent(id);

        if (!tab) {
            tab = tabPanel.add({
                id: id,
                title: titles,
                closable: true,
                autoLoad: {
                    showMask: true,
                    url: url,
                    mode: "iframe",
                    maskMsg: "Loading " + url + "..."
                }
            });

            tab.on("activate", function () {
                var item = MenuPanel1.menu.items.get(id + "_item");

                if (item) {
                    MenuPanel1.setSelection(item);
                }
            }, this);
            tab.on("activate", function () {
                var item = MenuPanel2.menu.items.get(id + "_item");

                if (item) {
                    MenuPanel2.setSelection(item);
                }
            }, this);
        }

        tabPanel.setActiveTab(tab);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items> 
             
            <ext:Panel ID="Panel6" runat="server" Collapsible="true" Layout="accordion" Collapsed="false" Region="West"
                Split="true" Title="功能面板" Width="200">
                <Items>
                      <ext:MenuPanel ID="MenuPanel1" runat="server" Height="300" Icon="MonitorGo" Title="试卷管理" Width="185">
                        <Menu runat="server">
                            <Items> 
                                <ext:MenuItem ID="MenuItem4" runat="server" Icon="BookAdd" Text="试卷添加">
                                <Listeners>
                                   <Click Handler="addTab(#{TabPanel1}, 'MenuItem4', 'ExamManage/add.aspx','试卷添加');" />
                                </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem5" runat="server" Icon="BrickAdd" Text="试题添加">
                                <Listeners>
                                   <Click Handler="addTab(#{TabPanel1}, 'MenuItem5', 'ExamManage/AddItems.aspx','试题添加');" />
                                </Listeners>
                                </ext:MenuItem> 
                            </Items>
                        </Menu>
                    </ext:MenuPanel>
                    <ext:MenuPanel ID="MenuPanel2" runat="server" Height="300" Icon="Monitor" Title="管理" Width="185">
                        <Menu>
                            <Items>
                                <ext:MenuItem ID="MenuItem3" runat="server" Icon="UserStar" Text="后台用户">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, 'MenuItem3', '/Admin/Add.aspx','后台用户');" />
                                </Listeners>
                                </ext:MenuItem> 
                                <ext:MenuItem ID="MenuItem1" runat="server" Icon="DateLink" Text="试卷年份">
                                <Listeners>
                                    <Click Handler="addTab(#{TabPanel1}, 'MenuItem1', '/Dictionary/year.aspx','试卷年份');" />
                                </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem2" runat="server" Icon="TableSort" Text="试卷分类">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel1}, 'MenuItem2', '/Dictionary/category.aspx','试卷分类');"></Click>
                                    </Listeners>
                                </ext:MenuItem> 
                            </Items>
                        </Menu>
                    </ext:MenuPanel>
                </Items>
            </ext:Panel>
            <ext:TabPanel ID="TabPanel1" runat="server" ActiveTabIndex="0" Border="false" Title="Center" Region="Center">
                        <Items> 
                            <ext:Panel ID="Panel11" runat="server" Title="Tab 2">
                                <Items>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:TabPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

