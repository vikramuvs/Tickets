<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="viewTicket.aspx.cs" Inherits="viewTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
.EmptyGrid
{
    text-align: center;
    background-color: Black;
    font-family: Montserrat;
    font-size: x-larger;
    color: White;
}
</style>

    <%--<style>
        body
        {
            background-color: #fafafa;
            font-family: 'Open Sans';
        }
        
        .container
        {
            margin-top: 150px;
        }
        
        .table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            width: 200px;
        }
        
        .table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        
        .table th, .table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
    </style>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    
    <div id="mySidenav1">
        <a href="TicketEntry.aspx" id="raiseTicket1">Raise Ticket</a> 
        <a href="viewTicket.aspx" id="viewTicket1">View Tickets</a>
    </div>

    <div style="width: 100%;" id="searchArea">
        <table align="center">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Search by Ticket Number:
                </td>
                <td>
                    <asp:TextBox ID="txtSearchTicket" runat="server" Height="40px" Width="200px"
                        CssClass="form-control" required> </asp:TextBox>
                    <%--<asp:RegularExpressionValidator ID="revUserName" runat="server" ErrorMessage="Please enter Alphabet and Numbers only"
                 ValidationExpression="^[0-9A-Z]+$" ControlToValidate="txtSearchTicket" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                  <%--  <asp:Button ID="Button1" runat="server" OnClick="searchTicket" CssClass="btn btn-info fas fa-search" ToolTip="Search Tickets"></asp:Button> --%>
                    <button type="submit" class="btn btn-info" onserverclick="searchTicket" runat="server" title="Search Tickets" data-toggle="tooltip" data-placement="top"> <i class="fas fa-search"></i></button> 
                </td>
            </tr>
        </table>
    </div>

    <table align="center">
        <tr>
            <td>
                <p>
                    <asp:Label ID="Label2" runat="server" Visible="true" ForeColor="black"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <div style="overflow-x: auto; width: 97%; margin: 100px auto;" runat="server" id="gridContainer">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="dvGrid" style="width: 100%">
        <asp:GridView ID="gridTicketDetails" runat="server" CssClass="col-lg-12 gridstyle"  AutoGenerateColumns="False" HorizontalAlign="Center" Font-Size="Large" 
        CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
        EmptyDataText = "Seems like you have not raised any tickets! Kindly raise tickets for them to show up here! :)" OnRowDataBound="gridTicketDetails_RowDataBound"
        Font-Names="Montserrat" Font-Bold="true" AllowPaging=true AllowSorting=true OnSorting="SortGrid" OnPageIndexChanging="PageGrid" PagerStyle-BorderStyle="Solid" PagerStyle-ForeColor="White" PagerSettings-NextPageText="Next">

            <Columns>
               <%-- <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" ItemStyle-Width="200">
                    <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="TicketDetails.aspx?TicketNo={0}"
                                HeaderText="Ticket No" ItemStyle-Width = "120" ItemStyle-HorizontalAlign="Center" SortExpression="TicketNo"  />

                <asp:BoundField DataField="TicketRaisedDate" HeaderText="Raised Date" ItemStyle-Width="120" SortExpression="TicketRaisedDate">
                    <ItemStyle Width="120px" HorizontalAlign="Center" Height="50px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="AppName" HeaderText="Application Name" ItemStyle-Width="120" SortExpression="AppName">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="UserName" HeaderText="Being Handled By" ItemStyle-Width="120" SortExpression="UserName"><%--Name--%>
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="TicketAttendedOnDate" HeaderText="Ticket Attended Date" ItemStyle-Width="120" SortExpression="TicketAttendedOnDate">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="LastActionTaken" HeaderText="Action Taken" ItemStyle-Width="120" SortExpression="LastActionTaken">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="LastActionTakenDate" HeaderText="Last Action Taken Date" ItemStyle-Width="120" SortExpression="LastActionTakenDate">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

             <%--   <asp:BoundField DataField="IssueDetails" HeaderText="Issue Details" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>

            </Columns>

            <FooterStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
            <EmptyDataRowStyle CssClass="EmptyGrid" />
        </asp:GridView>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>

     <script type="text/javascript">
         $(function () {
             $("[id$=txtSearchTicket]").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "viewTicket.aspx/GetTicketList",
                         data: "{ 'searchTerm': '" + request.term + "'," + "'rfoID': '" + '<%=Session["uID"].ToString() %>' +"'}",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         success: function (data) {
                             response($.map(data.d, function (item) {
                                 return {
                                     label: item.split(':')[0],
                                     val: item.split(':')[1]
                                 }
                             }))
                         },
                         error: function (response) {
                             alert(response.responseText);
                         },
                         failure: function (response) {
                             alert(response.responseText);
                         }
                     });
                 },
                 select: function (e, i) {
                     $("[id$=hfTicketID]").val(i.item.val);
                 },
                 minLength: 3
             });
         });  
</script>

<script type="text/javascript" src="jquery.blockUI.js">
</script>
<script type="text/javascript">
    $(function () {
        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({ message: '<div align = "center">' + '<img src="images/loadingAnim.gif"/></div>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB' }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    };
</script>


<asp:HiddenField ID="hfTicketID" runat="server" />
 
</asp:Content>

