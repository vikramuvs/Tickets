<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TicketingSystem_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
<div>
    <div>
        Rows: <asp:TextBox ID="txtRows" runat="server" Width="30px"> </asp:TextBox> <br />
        Cols: &nbsp;<asp:TextBox ID="txtCols" runat="server" Width="30px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnGenerate" OnClick="btnGenerate_Click" runat="server" Text="Generate" />&nbsp;<br /> <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <br />
    </div>
    </div>
        <asp:Button ID="btnPost" runat="server" OnClick="btnGenerate_Click" Text="Cause Postback" />
</asp:Content>

