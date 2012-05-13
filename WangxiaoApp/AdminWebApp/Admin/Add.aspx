<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Add" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXAdminUsers] ORDER BY [AdminLevelID] DESC"></asp:SqlDataSource>
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
             
            <ext:Panel ID="Panel2" runat="server" Collapsible="False"  Layout="Fit"   Region="East"
                Split="true"  Width="300">
                <Items>
                    <ext:FormPanel ID="FormPanel1" Icon="UserAdd" runat="server" ButtonAlign="Right"   Padding="5"
                        Title="管理员添加" Height="200" Width="300">
                        <Items>
                            <ext:TextField ID="txtUsername" runat="server" AnchorHorizontal="98%" FieldLabel="用户名">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWD1" runat="server" InputType="Password" AnchorHorizontal="98%" FieldLabel="密码">
                            </ext:TextField>
                            <ext:TextField ID="txtPassWD2" runat="server" InputType="Password" AnchorHorizontal="98%" FieldLabel="密码校验">
                            </ext:TextField>
                             
                        </Items>
                        <Buttons>
                            <ext:Button ID="Button1" runat="server" Icon="Disk" Text="提交">
                                <DirectEvents>
                                    <Click OnEvent="BtnAdd_Click"></Click> 
                                </DirectEvents>
                                <Listeners>
                                    <Click Delay="500" Handler="#{txtUsername}.reset();#{txtPassWD1}.reset();#{txtPassWD2}.reset();"></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:FormPanel>
                </Items>
            </ext:Panel>
             
            <ext:Panel ID="Panel9" runat="server" Layout="Fit" Region="Center"  >
                <Items>
                    <ext:GridPanel ID="GridPanel1" runat="server" Height="300" Title="管理员列表" Icon="UserEarth">
                        <Store>
                            <ext:Store ID="Store1" DataSourceID="SqlDataSource1" runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="ID">
                                         <Fields>
                                             <ext:RecordField Name="ID"></ext:RecordField>
                                             <ext:RecordField Name="GID"></ext:RecordField>
                                             <ext:RecordField Name="AdminUserName"></ext:RecordField>
                                             <ext:RecordField Name="AdminPassWord"></ext:RecordField>
                                             <ext:RecordField Name="AdminLevelID"></ext:RecordField> 
                                         </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel runat="server">
                            <Columns>
                                <ext:Column DataIndex="ID" Header="序号"></ext:Column>
                                <ext:Column DataIndex="GID" Header="全局唯一"></ext:Column>
                                <ext:Column DataIndex="AdminUserName" Header="管理员"></ext:Column>     
                                <ext:Column DataIndex="AdminPassWord" Header="密码"></ext:Column>
                                <ext:Column DataIndex="AdminLevel" Header="级别"></ext:Column>
                                <ext:CommandColumn>
                                    <Commands>
                                        <ext:GridCommand Icon="ControlPower" CommandName="EditRow" Text="权限"></ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <DirectEvents>
                            <Command OnEvent="BtnCMD_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="AdminID" Mode="Raw" Value="record.data.ID"></ext:Parameter>
                                </ExtraParams>
                            </Command>
                        </DirectEvents>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    
 
</asp:Content>

