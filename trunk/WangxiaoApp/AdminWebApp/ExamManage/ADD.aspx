<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ADD.aspx.cs" Inherits="ExamManage_ADD" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">
                         
            var applyFilter = function (field) {                
                var store = #{GridPanel1}.getStore();
                store.suspendEvents();
                store.filterBy(getRecordFilter());                                
                store.resumeEvents();
                #{GridPanel1}.getView().refresh(false);
            };
             
            var clearFilter = function () {
                #{ComboBox6}.reset();
                #{DropDownField2}.reset();
                #{ComboBox3}.reset();
                #{ComboBox4}.reset();
                #{ComboBox5}.reset();
                 
                #{Store1}.clearFilter();
            }
 
            var filterString = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
                
                if (typeof val != "string") {
                    return value.length == 0;
                }
                
                return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
            };
 
            var filterDate = function (value, dataIndex, record) {
                var val = record.get(dataIndex).clearTime(true).getTime();
 
                if (!Ext.isEmpty(value, false) && val != value.clearTime(true).getTime()) {
                    return false;
                }
                return true;
            };
 
            var filterNumber = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
 
                if (!Ext.isEmpty(value, false) && val != value) {
                    return false;
                }
                
                return true;
            };
 
            var getRecordFilter = function () {
                var f = [];
 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox6}.getValue(), "eTitle", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{DropDownField2}.getValue(), "path", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{ComboBox3}.getValue(), "ExamTypeID", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{ComboBox4}.getValue(), "eYear", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{ComboBox5}.getValue(), "PvcID", record);
                    }
                });
 
                var len = f.length;
                 
                return function (record) {
                    for (var i = 0; i < len; i++) {
                        if (!f[i].filter(record)) {
                            return false;
                        }
                    }
                    return true;
                };
            };
        </script>
    </ext:XScript>
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
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [vw_ExamPaper_ExamCategory] ORDER BY [ID] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server"
        ConnectionString="<%$ ConnectionStrings:WxConn %>" 
        SelectCommand="SELECT * FROM [WXSysExamQstType] ORDER BY [ID] DESC"></asp:SqlDataSource>
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:RowLayout ID="ColumnLayout1" runat="server" Split="true" FitHeight="true">
                <Rows>
                    <ext:LayoutRow  RowHeight="0.25" runat="server">
                        <ext:GridPanel ID="GridPanel1"  runat="server"  Margins="0 0 5 5"  Title="试卷列表" Icon="TextListBullets">
                                <Store>
                                    <ext:Store ID="Store1"
                                      DataSourceID="SqlDataSource4"
                                     runat="server">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ExamGID">
                                                <Fields>
                                                    <ext:RecordField Name="eTitle"></ext:RecordField>
                                                    <ext:RecordField Name="path"></ext:RecordField>
                                                    <ext:RecordField Name="ExamTypeID"></ext:RecordField>
                                                    <ext:RecordField Name="eYear"></ext:RecordField>
                                                    <ext:RecordField Name="PvcID"></ext:RecordField>
                                                    <ext:RecordField Name="ExamGID"></ext:RecordField>
                                                    <ext:RecordField Name="className"></ext:RecordField>
                                                    <ext:RecordField Name="eStars"></ext:RecordField>
                                                    <ext:RecordField Name="eTotalScore"></ext:RecordField>
                                                    <ext:RecordField Name="ePassingScore"></ext:RecordField>
                                                    <ext:RecordField Name="eFrom"></ext:RecordField>
                                                    <ext:RecordField Name="eHot"></ext:RecordField>
                                                    <ext:RecordField Name="ePoints"></ext:RecordField>
                                                    <ext:RecordField Name="pName"></ext:RecordField>
                                                    <ext:RecordField Name="ExamType"></ext:RecordField>
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store> 
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                         <ext:Button ID="Button6" runat="server" Icon="Add" Text="添加试卷">
                                        <DirectEvents>
                                            <Click OnEvent="OpenWindows_add"></Click>
                                        </DirectEvents>
                                        <Listeners>
                                            <Click Handler="#{FormPanel1}.getForm().reset();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button ID="Button9" runat="server" Text="编辑试卷" Icon="CdrEdit">
                                        <DirectEvents>
                                            <Click OnEvent="OpenWindows_edit"></Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button ID="Button7" runat="server" Icon="Delete" Text="删除试卷">
                                    </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns> 
                                        <ext:Column   DataIndex="eTitle" Header="标题" Width="300" />
                                        <ext:Column   DataIndex="className" Header="分类" Width="300"   />
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
                                                <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{GridPanel2}" />
                                                <ExtraParams>
                                                    <%-- or can use params[2].id as value --%>
                                                    <ext:Parameter Name="ExamGID" Value="this.getSelected().id" Mode="Raw" />
                                                </ExtraParams>
                                            </RowSelect>
                                        </DirectEvents>
                                         <Listeners>
                                                <RowSelect Handler="#{Store9}.reload();" Buffer="250" />
                                         </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
                                </BottomBar>
                                <View>
                                    <ext:GridView ID="GridView1" runat="server">
                                        <HeaderRows>
                                            <ext:HeaderRow>
                                                <Columns>
                                                    <ext:HeaderColumn Cls="x-small-editor">
                                                        <Component>
                                                            <ext:ComboBox 
                                                                ID="ComboBox6" 
                                                                runat="server"
                                                                TriggerAction="All"
                                                                Mode="Local"
                                                                DisplayField="eTitle"
                                                                ValueField="eTitle">
                                                                <Store>
                                                                    <ext:Store ID="Store8" runat="server" DataSourceID="SqlDataSource4">
                                                                        <Reader>
                                                                            <ext:JsonReader runat="server">
                                                                                <Fields>
                                                                                    <ext:RecordField Name="eTitle" />
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                                <Listeners>
                                                                    <Select Handler="applyFilter(this);" />
                                                                </Listeners>     
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn Cls="x-small-editor">
                                                        <Component>
                                                           <ext:DropDownField ID="DropDownField2" Editable="false" Width="400"   runat="server">
                                                            <Component>
                                                                <ext:TreePanel ID="TreePanel2" runat="server" Height="300" Title="分类">
                                                                <Listeners>
                                                                    <Click Handler="this.dropDownField.setValue(node.text,node.id,false);applyFilter(this);" Delay="500"></Click>
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox3"  AnchorHorizontal="98%" Editable="false" DisplayField="ExamType" ValueField="ID" runat="server">
                                                            <Store>
                                                                <ext:Store ID="Store5" DataSourceID="SqlDataSource3" runat="server">
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
                                                             <Listeners>
                                                                    <Select Handler="applyFilter(this);" />
                                                            </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox4"   AnchorHorizontal="98%" Editable="false" DisplayField="Years" ValueField="Years" DataIndex="eYear"  runat="server">
                                                            <Store>
                                                                <ext:Store ID="Store6" DataSourceID="SqlDataSource2" runat="server">
                                                                <Reader>
                                                                    <ext:JsonReader>
                                                                    <Fields>
                                                                        <ext:RecordField Name="Years"></ext:RecordField>
                                                                    </Fields>
                                                                    </ext:JsonReader>
                                                                </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                             <Listeners>
                                                                    <Select Handler="applyFilter(this);" />
                                                            </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox5" AnchorHorizontal="98%" Editable="false" DisplayField="pName" ValueField="pID" DataIndex="pName" runat="server">
                                                               <Store>
                                                                    <ext:Store ID="Store7" DataSourceID="SqlDataSource1" runat="server">
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
                                                                 <Listeners>
                                                                    <Select Handler="applyFilter(this);" />
                                                                 </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:Button ID="ClearFilterButton" runat="server" Icon="Cancel">
                                                                <ToolTips>
                                                                    <ext:ToolTip ID="ToolTip1" runat="server" Html="Clear filter" />
                                                                </ToolTips>
                                             
                                                                <Listeners>
                                                                    <Click Handler="clearFilter(null);" />
                                                                </Listeners>                                            
                                                            </ext:Button>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                </Columns>
                                            </ext:HeaderRow>
                                        </HeaderRows>
                                    </ext:GridView>
                                </View>
                                <LoadMask ShowMask="true" /> 
                                </ext:GridPanel>
                    </ext:LayoutRow>
                    <ext:LayoutRow RowHeight="0.25">
                        <ext:GridPanel ID="GridPanel2" runat="server" Height="300" Title="试卷规则">
                            <TopBar>
                                <ext:Toolbar  ID="Toolbar2" runat="server">
                                    <Items>
                                        <ext:Button runat="server" Text="添加规则" Icon="CogAdd">
                                            <DirectEvents>
                                                <Click OnEvent="RulesAdd"></Click>
                                            </DirectEvents>
                                            <Listeners>
                                                <Click Handler="#{FormPanel2}.getForm().reset();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="编辑规则" Icon="CogEdit" >
                                            <DirectEvents>
                                                <Click OnEvent="RulesEdit"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="删除规则" Icon="CogDelete">
                                            <DirectEvents>
                                                <Click OnEvent="RulesDel"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        <Store>
                            <ext:Store ID="Store9"  runat="server" OnRefreshData="Store9_Refresh">
                                <Reader>
                                    <ext:JsonReader IDProperty="GID">
                                        <Fields>
                                            <ext:RecordField Name="GID"></ext:RecordField>
                                            <ext:RecordField Name="ExamGID"></ext:RecordField>
                                            <ext:RecordField Name="RulesTitle"></ext:RecordField>
                                            <ext:RecordField Name="RulesScore"></ext:RecordField>
                                            <ext:RecordField Name="RulesScoreSet"></ext:RecordField>
                                            <ext:RecordField Name="RulesTypeName"></ext:RecordField>
                                            <ext:RecordField Name="RulesContent"></ext:RecordField>
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                                <BaseParams>
                                    <ext:Parameter 
                                        Name="SupplierID" 
                                        Value="Ext.getCmp('#{GridPanel1}') && #{GridPanel1}.getSelectionModel().hasSelection() ? #{GridPanel1}.getSelectionModel().getSelected().id : -1"
                                        Mode="Raw" 
                                        />
                                </BaseParams>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column DataIndex="RulesTypeName" Header="分组类型"></ext:Column>
                                <ext:Column DataIndex="RulesContent" Width="300" Header="类型介绍"></ext:Column>
                                <ext:Column DataIndex="RulesScore" Header="每题分数"></ext:Column>
                                <ext:Column DataIndex="RulesScoreSet" Header="分数设置"></ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
                                <DirectEvents>
                                    <RowSelect OnEvent="RowSelect2" Buffer="100">
                                        <EventMask ShowMask="true" Target="CustomTarget" CustomTarget="#{GridPanel3}" />
                                        <ExtraParams>
                                            <%-- or can use params[2].id as value --%>
                                            <ext:Parameter Name="RulesGID" Value="this.getSelected().id" Mode="Raw" />
                                        </ExtraParams>
                                    </RowSelect>
                                </DirectEvents>
                                    <Listeners>
                                        <RowSelect Handler="#{Store10}.reload();" Buffer="250" />
                                    </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        </ext:GridPanel>
                    </ext:LayoutRow> 
                    <ext:LayoutRow RowHeight="0.5">
                        <ext:GridPanel ID="GridPanel3" runat="server" Height="300" Title="试题列表">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="Toolbar3">
                                    <Items>
                                        <ext:Button runat="server" ID="BtnAddItem" Text="添加试题" Icon="BookAdd">
                                            <DirectEvents>
                                                <Click OnEvent="BookAdd_Open"></Click>
                                            </DirectEvents>
                                            <Listeners>
                                                <Click Handler="#{FormPanel3}.getForm().reset();"></Click>
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="Button10" Text="试题修改" Icon="BookEdit">
                                             <DirectEvents>
                                                <Click OnEvent="BookEdit_Open"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="Button11" Text="删除试题" Icon="BookDelete">
                                            <DirectEvents>
                                                <Click OnEvent="BookDel"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store runat="server" ID="Store10" OnRefreshData="Store10_Refresh">
                                    <Reader>
                                        <ext:JsonReader IDProperty="QGID">
                                            <Fields>
                                                <ext:RecordField  Name="QGID"></ext:RecordField>
                                                <ext:RecordField  Name="ExamGID"></ext:RecordField>
                                                <ext:RecordField  Name="RulesGID"></ext:RecordField>
                                                <ext:RecordField  Name="qContent"></ext:RecordField>
                                                <ext:RecordField  Name="qType"></ext:RecordField>
                                                <ext:RecordField  Name="qSelectNum"></ext:RecordField>
                                                <ext:RecordField  Name="qOrderNum"></ext:RecordField>
                                                <ext:RecordField  Name="qAnswer"></ext:RecordField>
                                                <ext:RecordField  Name="Analysis"></ext:RecordField>
                                                <ext:RecordField  Name="ReviewCount"></ext:RecordField>
                                                <ext:RecordField  Name="AnalyseNum"></ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                    <BaseParams>
                                    <ext:Parameter 
                                        Name="RulesGID" 
                                        Value="Ext.getCmp('#{GridPanel2}') && #{GridPanel2}.getSelectionModel().hasSelection() ? #{GridPanel2}.getSelectionModel().getSelected().id : -1"
                                        Mode="Raw" 
                                        />
                                    </BaseParams>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:Column DataIndex="qContent" Width="300" Header="试题内容"></ext:Column>
                                    <ext:Column DataIndex="qType" Header="试题类型"></ext:Column>
                                    <ext:Column DataIndex="qSelectNum" Header="选项个数"></ext:Column>
                                    <ext:Column DataIndex="qOrderNum" Header="排序位置"></ext:Column>
                                    <ext:Column DataIndex="qAnswer" Header="答案"></ext:Column>
                                    <ext:Column DataIndex="ReviewCount" Header="ReviewCount"></ext:Column>
                                    <ext:Column DataIndex="Analysis" Header="分析"></ext:Column>
                                    <ext:Column DataIndex="AnalyseNum" Header="分析数目"></ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true">
                                <DirectEvents>
                                    <RowSelect OnEvent="RowSelect3" Buffer="100"> 
                                        <ExtraParams>
                                            <%-- or can use params[2].id as value --%>
                                            <ext:Parameter Name="QGID" Value="this.getSelected().id" Mode="Raw" />
                                        </ExtraParams>
                                    </RowSelect>
                                </DirectEvents>
                                    <Listeners>
                                        <RowSelect Handler="#{Store10}.reload();" Buffer="250" />
                                    </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        </ext:GridPanel>
                    </ext:LayoutRow>
                </Rows>
            </ext:RowLayout>
            
            
        </Items>
    </ext:Viewport>
    <ext:Window ID="Window1" runat="server" Modal="true"  ShowOnLoad="false"  Hidden="True" Closable="True"  Collapsible="false"  Height="430" Icon="Application"
        Title="试卷添加" Icons="Attach" Width="350"  >
        <Items>
            <ext:FormPanel ID="FormPanel1" runat="server"  Margins="0 5 5 5" ButtonAlign="Right"  Region="East" Padding="5">
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
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Modal="true"  ShowOnLoad="false"  Hidden="True" Height="370"  Closable="True"   Collapsible="false"   Icon="Application"
        Title="规则添加" Width="700">
        <Items>
            <ext:FormPanel ID="FormPanel2" runat="server" Margins="0 5 5 5" ButtonAlign="Right"  Region="East" Padding="5">
                <Items>
                    <ext:TextField ID="tfGID"  FieldLabel="规则编号" Disabled="True" runat="server" DataIndex="GID" />
                    <ext:TextField ID="tfRulesName" runat="server"  FieldLabel="规则名称" DataIndex="RulesTypeName">
                    </ext:TextField>
                    <ext:HtmlEditor ID="tfRulesContent"   Height="150" FieldLabel="题型介绍" DataIndex="RulesContent" runat="server">
                    </ext:HtmlEditor> 
                    <ext:SpinnerField ID="tfRulesScore" 
                                        MinValue="0"
                                        MaxValue="1000"
                                        AllowDecimals="true"
                                        DecimalPrecision="1"
                                        IncrementValue="1"
                                        Accelerate="true"
                                        AlternateIncrementValue="10"
                                        FieldLabel="每题分数" DataIndex="RulesScore" runat="server">
                    </ext:SpinnerField>
                    <ext:SpinnerField ID="tfRulesScoreSet" FieldLabel="分数设置"
                                        MinValue="0"
                                        MaxValue="1000"
                                        AllowDecimals="true"
                                        DecimalPrecision="1"
                                        IncrementValue="1"
                                        Accelerate="true"
                                        DataIndex="RulesScoreSet"
                                        AlternateIncrementValue="10"    
                                        runat="server">
                    </ext:SpinnerField>
                    <ext:SpinnerField ID="SpinnerField1" FieldLabel="题型排序" DataIndex="SSorts" runat="server">
                    </ext:SpinnerField>
                </Items>
                <Buttons>
                    <ext:Button ID="Button8" runat="server" Icon="Disk" Text="添加">
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Window>
      <ext:Window ID="Window3" runat="server" Modal="true"  ShowOnLoad="false"  Hidden="True" Height="520"  Closable="True"   Collapsible="false"   Icon="Application"
        Title="试题添加" Width="700">
        <Items>
            <ext:FormPanel ID="FormPanel3" runat="server" ButtonAlign="Right"  Padding="5" >
                <Items>
                    <ext:TextField ID="TextField1" runat="server"   FieldLabel="试题编号" Disabled="True" DataIndex="QGID">
                    </ext:TextField>
                    <ext:ComboBox ID="txtqType" Editable="false" FieldLabel="试题类型" DisplayField="TypeName" DataIndex="qType" ValueField="ID" runat="server">
                        <Store>
                            <ext:Store ID="Store11" DataSourceID="SqlDataSource3" runat="server">
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
                    <ext:SpinnerField ID="SpinnerField2" 
                                        MinValue="0"
                                        MaxValue="1000"
                                        AllowDecimals="true"
                                        DecimalPrecision="1"
                                        IncrementValue="5"
                                        Accelerate="true"
                                        AlternateIncrementValue="10"
                                        FieldLabel="选项个数" DataIndex="qSelectNum" runat="server">
                    </ext:SpinnerField>
                    <ext:SpinnerField ID="SpinnerField3" 
                                        MinValue="0"
                                        MaxValue="1000"
                                        AllowDecimals="true"
                                        DecimalPrecision="1"
                                        IncrementValue="5"
                                        Accelerate="true"
                                        AlternateIncrementValue="10"
                                        FieldLabel="试题排序" DataIndex="qOrderNum" runat="server">
                    </ext:SpinnerField>
                    <ext:MultiCombo ID="txtqAnswer1" runat="server"  FieldLabel="正确项" DataIndex="qAnswer" SelectionMode="All" >
                        <Items>
                            <ext:ListItem Text="1" Value="1" />
                            <ext:ListItem Text="0" Value="0" />
                            <ext:ListItem Text="A" Value="A" />
                            <ext:ListItem Text="B" Value="B" />
                            <ext:ListItem Text="C" Value="C" />
                            <ext:ListItem Text="D" Value="D" />
                            <ext:ListItem Text="E" Value="E" />
                            <ext:ListItem Text="F" Value="F" />
                            <ext:ListItem Text="G" Value="G" />
                            <ext:ListItem Text="H" Value="H" />
                            <ext:ListItem Text="I" Value="I" />
                            <ext:ListItem Text="J" Value="J" />
                        </Items> 
                        <SelectedItems>
                            <ext:SelectedListItem Value="A" />
                        </SelectedItems>
                    </ext:MultiCombo>
                     <ext:HtmlEditor ID="HtmlEditor1"   Height="150" FieldLabel="试题内容" DataIndex="qContent" runat="server">
                    </ext:HtmlEditor>
                    <ext:HtmlEditor ID="HtmlEditor2"   Height="150" FieldLabel="试题分析" DataIndex="Analysis" runat="server">
                    </ext:HtmlEditor> 
                </Items>
                <Buttons>
                    <ext:Button ID="Button12" runat="server" Icon="Disk" Text="Submit">
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
        </ext:Window>
</asp:Content>

