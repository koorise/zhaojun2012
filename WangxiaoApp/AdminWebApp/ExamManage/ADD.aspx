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
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:GridPanel ID="GridPanel1"  runat="server"   Margins="0 0 5 5" Region="Center" Frame="true" Title="试卷列表" Icon="TextListBullets">
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
            <ColumnModel runat="server">
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
            <View>
                <ext:GridView runat="server">
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

