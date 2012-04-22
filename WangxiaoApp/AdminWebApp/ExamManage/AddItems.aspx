<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItems.aspx.cs" Inherits="ExamManage_AddItems" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [vw_ExamPaper_ExamCategory] ORDER BY [ID] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXExamDetail] WHERE ([ExamGID] = @ExamGID) ORDER BY [qOrderNum]">
        <SelectParameters>
            <asp:QueryStringParameter Name="ExamGID" QueryStringField="ExamID" 
                Type="Object" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXSysExamQstType]"></asp:SqlDataSource>
   <ext:Viewport ID="Viewport1" runat="server">
        <Items>
            <ext:RowLayout ID="RowLayout1" runat="server" Split="true">
                <Rows>
                    <ext:LayoutRow RowHeight="0.35">
                        <ext:GridPanel ID="GridPanel1" runat="server" Title="试卷列表">
                                <Store>
                                    <ext:Store ID="Store1"
                                      DataSourceID="SqlDataSource1"
                                     runat="server">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ExamGID">
                                                <Fields>
                                                    <ext:RecordField Name="ExamGID"></ext:RecordField>
                                                    <ext:RecordField Name="className"></ext:RecordField>
                                                    <ext:RecordField Name="eTitle"></ext:RecordField>
                                                    <ext:RecordField Name="eYear"></ext:RecordField>
                                                    <ext:RecordField Name="eStars"></ext:RecordField>
                                                    <ext:RecordField Name="eTotalScore"></ext:RecordField>
                                                    <ext:RecordField Name="ePassingScore"></ext:RecordField>
                                                    <ext:RecordField Name="eFrom"></ext:RecordField>
                                                    <ext:RecordField Name="eHot"></ext:RecordField>
                                                    <ext:RecordField Name="ePoints"></ext:RecordField>
                                                    <ext:RecordField Name="pName"></ext:RecordField>
                                                    <ext:RecordField Name="path"></ext:RecordField>
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader> 
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns> 
                                    <ext:Column   DataIndex="eTitle" Header="标题" />
                                    <ext:Column   DataIndex="className" Header="分类" />
                                    <ext:Column   DataIndex="eYear" Header="年份" />
                                    <ext:Column   DataIndex="pName" Header="省份" />
                                    <ext:Column   DataIndex="eStars" Header="星级" />
                                    <ext:Column   DataIndex="eTotalScore" Header="总分" />
                                    <ext:Column   DataIndex="ePassingScore" Header="及格分" />
                                    <ext:Column   DataIndex="eFrom" Header="来源" />
                                    <ext:Column   DataIndex="eHot" Header="热度" />
                                    <ext:Column   DataIndex="ePoints" Header="金币" /> 
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                       
                                      <DirectEvents>
                                        <RowSelect OnEvent="GridPanel1_Selected"></RowSelect>
                                      </DirectEvents>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10" />
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel> 
                    </ext:LayoutRow>
                    
                    <ext:LayoutRow RowHeight="0.35">
                        <ext:GridPanel ID="GridPanel2" AutoExpandColumn="qContent" runat="server" Height="300" Title="试题列表">
                        <Store>
                            <ext:Store ID="Store2"   runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="QGID">
                                        <Fields>
                                            <ext:RecordField Name="ID"></ext:RecordField>
                                            <ext:RecordField Name="QGID"></ext:RecordField>
                                            <ext:RecordField Name="ExamID"></ext:RecordField>
                                            <ext:RecordField Name="qContent"></ext:RecordField>
                                            <ext:RecordField Name="qType"></ext:RecordField>
                                            <ext:RecordField Name="qSelectNum"></ext:RecordField>
                                            <ext:RecordField Name="qOrderNum"></ext:RecordField>
                                            <ext:RecordField Name="qAnswer"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                                <BaseParams>
                                    <ext:Parameter 
                                                    Name="ExamID" 
                                                    Value="Ext.getCmp('#{GridPanel1}') && #{GridPanel1}.getSelectionModel().hasSelection() ? #{GridPanel1}.getSelectionModel().getSelected().id : -1"
                                                    Mode="Raw" 
                                                    />
                                </BaseParams>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column   DataIndex="ID" Header="编号" />
                                <ext:Column   DataIndex="QGID" Width="250" Header="唯一" />
                                <ext:Column   DataIndex="qContent" Header="题目内容" />
                                <ext:Column   DataIndex="qType" Header="类型" />
                                <ext:Column   DataIndex="qSelectNum" Header="选项数" />
                                <ext:Column   DataIndex="qOrderNum" Header="序号" />
                                <ext:Column   DataIndex="qAnswer" Header="答案" />
                            </Columns>
                        </ColumnModel>
                        </ext:GridPanel>
                    </ext:LayoutRow>
                    
                    <ext:LayoutRow RowHeight="0.3" >

         <ext:Panel 
            ID="Panel3"
            runat="server" 
            Title="试题内容" 
            Frame="true"
            PaddingSummary="5px 5px 0" 
            ButtonAlign="Center">
            <Items>
                <ext:Container ID="Container4" runat="server" Layout="Column" Height="300" >
                    <Items>
                        <ext:Container ID="Container5" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".2">
                            <Items>
                            
                                <ext:TextField ID="txtExamGID" FieldLabel="试卷编号" Disabled="True" AnchorHorizontal="98%" runat="server">
                                </ext:TextField>
                                <ext:ComboBox ID="txtqType" Editable="false" FieldLabel="试题类型" AnchorHorizontal="98%" DisplayField="TypeName" ValueField="ID" runat="server">
                                    <Store>
                                        <ext:Store ID="Store3" DataSourceID="SqlDataSource3" runat="server">
                                            <Reader>
                                                <ext:JsonReader>
                                                    <Fields>
                                                        <ext:RecordField Name="ID"></ext:RecordField>
                                                        <ext:RecordField Name="TypeName"></ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                </ext:ComboBox>
                                <ext:ComboBox ID="txtqSelectNum" Editable="false" AnchorHorizontal="98%" FieldLabel="选项个数" runat="server">
                                    <Items>
                                        <ext:ListItem Text="1（仅供：简述题类型）" Value="1" />
                                        <ext:ListItem Text="2（仅供：判断题类型）" Value="2" />
                                        <ext:ListItem Text="3" Value="3" />
                                        <ext:ListItem Text="4" Value="4" />
                                        <ext:ListItem Text="5" Value="5" />
                                        <ext:ListItem Text="6" Value="6" />
                                        <ext:ListItem Text="7" Value="7" />
                                        <ext:ListItem Text="8" Value="8" />
                                        <ext:ListItem Text="9" Value="9" />
                                        <ext:ListItem Text="10" Value="10" />
                                    </Items>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container6" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".2">
                            <Items>
                                <ext:MultiCombo ID="txtqAnswer1" runat="server" AnchorHorizontal="98%" FieldLabel="正确项" SelectionMode="All" >
                                    <Items>
                                        <ext:ListItem Text="1" Value="1" />
                                        <ext:ListItem Text="2" Value="2" />
                                        <ext:ListItem Text="3" Value="3" />
                                        <ext:ListItem Text="4" Value="4" />
                                        <ext:ListItem Text="5" Value="5" />
                                        <ext:ListItem Text="6" Value="6" />
                                        <ext:ListItem Text="7" Value="7" />
                                        <ext:ListItem Text="8" Value="8" />
                                        <ext:ListItem Text="9" Value="9" />
                                        <ext:ListItem Text="10" Value="10" />
                                    </Items>
            
                                    <SelectedItems>
                                        <ext:SelectedListItem Value="1" />
                                    </SelectedItems>
                                </ext:MultiCombo>
                                <ext:TextField ID="txtqOrderNum" FieldLabel="试题序号" AnchorHorizontal="98%" runat="server">
                                </ext:TextField>
                                <ext:TextArea ID="txtqAnswer2" FieldLabel="简述题答案" AnchorHorizontal="98%" EmptyText="此项仅供简述题书写答案..." runat="server">
                                </ext:TextArea>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container7" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".6">
                    <Items>
                        <ext:HtmlEditor ID="txtqContent" runat="server" Height="150" FieldLabel="试题内容" AnchorHorizontal="98%" />
                    </Items>
                </ext:Container>
                    </Items>
                </ext:Container>
                
            </Items>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="添加" Icon="Add" >
                    <DirectEvents>
                        <Click OnEvent="BtnAdd_Click"></Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="清除" Icon="Erase" />
            </Buttons>
        </ext:Panel>


                          
                    </ext:LayoutRow>
                </Rows>
            </ext:RowLayout>
        </Items>
    </ext:Viewport> 
</asp:Content>

