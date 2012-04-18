<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="year.aspx.cs" Inherits="Dictionary_year" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<script type="text/javascript">
    var template = '<span style="color:{0};">{1}</span>';

    var change = function (value) {
        return String.format(template, (value > 0) ? "green" : "red", value);
    };

    var pctChange = function (value) {
        return String.format(template, (value > 0) ? "green" : "red", value + "%");
    };

    var startEditing = function (e) {
        if (e.getKey() === e.ENTER) {
            var grid = GridPanel1,
                    record = grid.getSelectionModel().getSelected(),
                    index = grid.store.indexOf(record);

            grid.startEditing(index, 1);
        }
    };
   
    var afterEdit = function (e) {
        /*
        Properties of 'e' include:
        e.grid - This grid
        e.record - The record being edited
        e.field - The field name being edited
        e.value - The value being set
        e.originalValue - The original value for the field, before the edit.
        e.row - The grid row index
        e.column - The grid column index
        */

        // Call DirectMethod
        CompanyX.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
    };
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <ext:FormPanel ID="FormPanel1" runat="server" Icon="Add" Frame="true" LabelAlign="Right"   Padding="5"
        Title="添加" Width="500">
        <Items>
            <ext:TextField ID="txtYears" runat="server" AnchorHorizontal="100%" FieldLabel="年份">
            </ext:TextField>
        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Icon="Disk" Text="保存">
            <DirectEvents>
                <Click OnEvent="BtnAdd"></Click>    
            </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>

    <ext:GridPanel ID="GridPanel1" runat="server" AutoExpandColumn="Years"  Icon="Table" Frame="true" Height="400" StripeRows="true"
        TrackMouseOver="true"
            Width="500" Title="字典-年份">
    <Store>
        <ext:Store ID="Store1" runat="server" >
            <Reader>
                <ext:JsonReader IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID"  Type="Int" />
                        <ext:RecordField Name="Years" Type="Int" /> 
                    </Fields>
                </ext:JsonReader>
            </Reader> 
         </ext:Store>
    </Store>
    <Listeners>
        <KeyDown Fn="startEditing" />
        <AfterEdit Fn="afterEdit" />   
    </Listeners>
    <DirectEvents>
        <Command OnEvent="BtnDel">
             <ExtraParams>
                <ext:Parameter Name="CID" Value="record.data.ID" Mode="Raw"></ext:Parameter>
             </ExtraParams>
        </Command>
    </DirectEvents>
    <ColumnModel>
        <Columns>
           <ext:Column   Header="编号" Width="160" DataIndex="ID"/>
           <ext:Column   Header="年份" Width="160" DataIndex="Years">
           <Editor>
                <ext:TextField ID="TextField2" runat="server" />    
            </Editor>
           </ext:Column>
            <ext:CommandColumn Width="60">
                <Commands>
                    <ext:GridCommand Icon="Delete" CommandName="DEL" >                            
                        <ToolTip Text="Delete" />
                    </ext:GridCommand>
                </Commands>
            </ext:CommandColumn>
        </Columns>
    </ColumnModel>
    <SelectionModel>
        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
    </SelectionModel>
    </ext:GridPanel>
</asp:Content>

