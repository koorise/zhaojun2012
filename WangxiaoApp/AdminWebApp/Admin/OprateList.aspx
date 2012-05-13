<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OprateList.aspx.cs" Inherits="Admin_OprateList" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ext:GridPanel ID="GridPanel1" runat="server" Height="300" Layout="fit" Title="Title">
        <Store>
            <ext:Store runat="server">
                <Reader>
                    <ext:JsonReader >
                        <Fields>
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
        </Store>
    </ext:GridPanel>
</asp:Content>

