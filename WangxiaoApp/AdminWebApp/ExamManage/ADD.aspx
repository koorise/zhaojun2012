<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ADD.aspx.cs" Inherits="ExamManage_ADD" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ext:FormPanel ID="FormPanel1" runat="server" ButtonAlign="Right" Height="185" Padding="5" Region="Center"
          >
        <Items>
            <ext:TextField ID="TextField1" runat="server" AnchorHorizontal="100%" FieldLabel="Label">
            </ext:TextField>
        </Items>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Icon="Disk" Text="Submit">
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</asp:Content>

