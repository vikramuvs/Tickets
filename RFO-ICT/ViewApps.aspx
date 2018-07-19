<%@ Page Title="" Language="C#" MasterPageFile="../TicketMaster.master" AutoEventWireup="true" CodeFile="ViewApps.aspx.cs" Inherits="TicketingSystem_RFO_ICT_ViewApps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">

<asp:GridView ID="grvRFOICT" runat="server" AutoGenerateColumns="true" DataSourceID="dsApps" 
EmptyDataText="Sorry no records here." >
<Columns>
<asp:TemplateField>
<ItemTemplate>
<asp:Button ID="btnGet" runat="server" Text="Get this ticket" CssClass="btn btn-info" ></asp:Button>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

<asp:SqlDataSource ID="dsApps" runat="server" ConnectionString="Data Source=DESKTOP-C4OIS76; Initial Catalog=aranyaold; Integrated Security=true;" SelectCommand="Select * from tbl_TicketDetails where BeingHandledByID is null"></asp:SqlDataSource>

</asp:Content>


