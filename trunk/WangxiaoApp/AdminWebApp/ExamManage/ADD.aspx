<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ADD.aspx.cs" Inherits="ExamManage_ADD" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXSysYears]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXSysProvince]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXSysExamType]"></asp:SqlDataSource>

    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:GridPanel ID="GridPanel1"  runat="server"   Margins="0 0 5 5" Region="Center" Frame="true" Title="试卷列表" Icon="TextListBullets">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" LabelAlign="Right" runat="server">
                    <Items>
                    <ext:DropDownField ID="DropDownField2" Editable="false" Width="400" Icon="Find"  FieldLabel="试卷分类筛选" runat="server">
                    <Component>
                        <ext:TreePanel ID="TreePanel2" runat="server" Height="300" Title="分类">
                        <DirectEvents>
                             <Click OnEvent="SearchClick">
                                <ExtraParams>
                                    <ext:Parameter Name="SelectedID" Value="node.id" Mode="Raw"></ext:Parameter>
                                </ExtraParams>
                             </Click>
                        </DirectEvents>
                        <Listeners>
                            <Click Handler="#{GridPanel1}.store.reload();this.dropDownField.setValue(node.text,node.id,false);" Delay="500"></Click>
                        </Listeners> 
                        <Buttons>
                            <ext:Button ID="Button4" runat="server" Text="关闭">
                                <Listeners>
                                    <Click Handler="#{DropDownField2}.collapse();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                        </ext:TreePanel>
                    </Component>
                    </ext:DropDownField>
                     
                    </Items>
                </ext:Toolbar>
            </TopBar>
             
            <Store>
                <ext:Store ID="Store1"
                 OnRefreshData="Store1_Refresh"
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
                                <ext:RecordField Name="ExamType"></ext:RecordField>
                                <ext:RecordField Name="ExamTypeID"></ext:RecordField>
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <BaseParams>
                        <ext:Parameter 
                                        Name="path" 
                                        Value="Ext.getCmp('#{DropDownField2}') && #{DropDownField2}.getValue()"
                                        />
                    </BaseParams> 
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns> 
                    <ext:Column   DataIndex="eTitle" Header="标题" Width="200" />
                    <ext:Column   DataIndex="className" Header="分类"   />
                    <ext:Column   DataIndex="ExamType" Header="类型" />
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
                        <RowSelect OnEvent="RowSelect" Buffer="100">
                            <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{FormPanel1}" />
                            <ExtraParams>
                                <%-- or can use params[2].id as value --%>
                                <ext:Parameter Name="ExamGID" Value="this.getSelected().id" Mode="Raw" />
                            </ExtraParams>
                        </RowSelect>
                    </DirectEvents>
                </ext:RowSelectionModel>
            </SelectionModel>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
            <LoadMask ShowMask="true" />
            </ext:GridPanel>
            <ext:FormPanel ID="FormPanel1" runat="server"  Margins="0 5 5 5" ButtonAlign="Right"  Region="East" Padding="5"
                Title="试卷添加" Icon="Attach" Width="350" >
                <Items>
                    <ext:TextField ID="txtExamGID" runat="server" AnchorHorizontal="98%"  FieldLabel="试卷编号" DataIndex="ExamGID"  Disabled="True" />
                    
                    <ext:DropDownField ID="DropDownField1" Editable="false" AnchorHorizontal="98%" FieldLabel="试卷分类" DataIndex="className" runat="server">
                    <Component>
                        <ext:TreePanel ID="TreePanel1" runat="server" Height="300" Title="分类">
                        <Buttons>
                            <ext:Button ID="Button3" runat="server" Text="关闭">
                                <Listeners>
                                    <Click Handler="#{DropDownField1}.collapse();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                        </ext:TreePanel>
                    </Component>
                    </ext:DropDownField>
                    <ext:TextField ID="txtClassGID" runat="server" Disabled="True" AnchorHorizontal="98%" FieldLabel="分类编号" DataIndex="ClassGID"></ext:TextField>
                    <ext:TextField ID="txteTitle" runat="server" AnchorHorizontal="98%" FieldLabel="试卷名称" DataIndex="eTitle" />
                    <ext:ComboBox ID="ComboBox2" FieldLabel="省份" AnchorHorizontal="98%" Editable="false" DisplayField="pName" ValueField="pID" DataIndex="pName" runat="server">
                       <Store>
                            <ext:Store ID="Store3" DataSourceID="SqlDataSource1" runat="server">
                                <Reader>
                                    <ext:JsonReader>
                                        <Fields>
                                            <ext:RecordField Name="pID"></ext:RecordField>
                                            <ext:RecordField Name="pName"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                    <ext:ComboBox ID="txtExamTypeID" FieldLabel="试卷类型" AnchorHorizontal="98%" Editable="false" DisplayField="ExamType" ValueField="ID" runat="server">
                    <Store>
                        <ext:Store ID="Store4" DataSourceID="SqlDataSource3" runat="server">
                        <Reader>
                            <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="ExamType"></ext:RecordField>
                                <ext:RecordField Name="ID"></ext:RecordField>
                            </Fields>
                            </ext:JsonReader>
                        </Reader>
                        </ext:Store>
                    </Store>
                    </ext:ComboBox>
                    <ext:ComboBox ID="ComboBox1" FieldLabel="年份" AnchorHorizontal="98%" Editable="false" DisplayField="Years" ValueField="Years" DataIndex="eYear"  runat="server">
                    <Store>
                        <ext:Store ID="Store2" DataSourceID="SqlDataSource2" runat="server">
                        <Reader>
                            <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="Years"></ext:RecordField>
                            </Fields>
                            </ext:JsonReader>
                        </Reader>
                        </ext:Store>
                    </Store>
                    </ext:ComboBox>
                      
                     <ext:SpinnerField ID="txteStars" 
                                        MinValue="1" 
                                        MaxValue="10" 
                                        DecimalPrecision="1"  
                                        DataIndex="eStars" 
                                        IncrementValue="1" 
                                        FieldLabel="试卷星级" 
                                        AnchorHorizontal="98%" 
                                        runat="server" />
                    <ext:SpinnerField ID="txteTotalScore" 
                                        MinValue="50" 
                                        MaxValue="200" 
                                        DefaultValue="100"
                                        DecimalPrecision="1"  
                                        DataIndex="eTotalScore" 
                                        IncrementValue="10" 
                                        FieldLabel="试卷总分" 
                                        AnchorHorizontal="98%" 
                                        runat="server" />
                    <ext:SpinnerField ID="txtePassingScore" 
                                        MinValue="1" 
                                        MaxValue="200" 
                                        DecimalPrecision="1" 
                                        DefaultValue="60" 
                                        DataIndex="ePassingScore" 
                                        IncrementValue="1" 
                                        FieldLabel="及格分数" 
                                        AnchorHorizontal="98%" 
                                        runat="server" />
                      
                    <ext:TextField ID="txteFrom" AnchorHorizontal="98%" runat="server" FieldLabel="来源" DataIndex="eFrom" /> 
                     <ext:SpinnerField ID="txteHot" 
                                        MinValue="1" 
                                        MaxValue="1000" 
                                        DecimalPrecision="1"  
                                        DataIndex="eHot" 
                                        IncrementValue="1"
                                        DefaultValue="100" 
                                        FieldLabel="试卷热度" 
                                        AnchorHorizontal="98%" 
                                        runat="server" />
                    <ext:SpinnerField ID="txtePoints" 
                                        MinValue="0" 
                                        MaxValue="1000" 
                                        DecimalPrecision="1"  
                                        DataIndex="ePoints" 
                                        IncrementValue="1" 
                                        FieldLabel="试卷金币" 
                                        AnchorHorizontal="98%" 
                                        runat="server" />
                </Items>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Icon="Disk" Text="添加">
                    <DirectEvents>
                        <Click OnEvent="BtnAdd"></Click>
                    </DirectEvents> 
                    <Listeners>
                            <Click Delay="500" Handler="#{FormPanel1}.getForm().reset();#{GridPanel1}.store.reload();" />
                    </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Icon="BookEdit" Text="修改">
                    <DirectEvents>
                        <Click OnEvent="BtnEdit"></Click>
                    </DirectEvents>
                     <Listeners>
                            <Click Delay="500" Handler="#{FormPanel1}.getForm().reset();#{GridPanel1}.store.reload();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button ID="Button5" Icon="Erase" runat="server" Text="清除">
                        <Listeners>
                            <Click Handler="#{FormPanel1}.getForm().reset();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="ClearGrid"></Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
</asp:Content>

