<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trackin1.aspx.cs" Inherits="Trackin1" %>

<!DOCTYPE html>
<html>
<head>
    <title>asda</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">--%>
  <%--  <style>
        body
        {
            margin: 0;
            font-family: Arial, Helvetica, sans-serif;
        }
        
        .topnav
        {
            overflow: hidden;
            background-color: #333;
        }
        
        .topnav a
        {
            float: left;
            display: block;
            color: #f2f2f2;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
            font-size: 17px;
        }
        
        .topnav a:hover
        {
            background-color: #ddd;
            color: black;
        }
        
        .active
        {
            background-color: #4CAF50;
            color: white;
        }
        
        .topnav .icon
        {
            display: none;
        }
        
        @media screen and (max-width: 600px)
        {
            .topnav a:not(:first-child)
            {
                display: none;
            }
            .topnav a.icon
            {
                float: right;
                display: block;
            }
        }
        
        @media screen and (max-width: 600px)
        {
            .topnav.responsive
            {
                position: relative;
            }
            .topnav.responsive .icon
            {
                position: absolute;
                right: 0;
                top: 0;
            }
            .topnav.responsive a
            {
                float: none;
                display: block;
                text-align: left;
            }
        }
    </style>--%>

    <style>
    .red
    {
        background-color: Red;
    }
    
    .green
    {
        background-color: Green;
    }
    
    .blue
    {
        background-color: blue;
    }
    
    .orange
    {
        background-color: Orange;
    }
    
    .yellow 
    {
        background-color: Yellow;
    }
     .navy
    {
        background-color: Navy;
    }
     .lime 
    {
        background-color: lime;
    }
     .maroon 
    {
        background-color: Maroon;
    }
     .black 
    {
        background-color: Black;
    }
    </style>
</head>
<body>
<form id="frm" runat="server">
  <%--  <div class="topnav" id="myTopnav">
        <a href="#home" class="active">Home</a> <a href="#news">Applications</a> <a href="#contact">
            Ticket</a> <a href="#about">Signout</a> <a href="javascript:void(0);" class="icon"
                onclick="myFunction()"><i class="fa fa-bars"></i></a>
    </div>
    <div style="padding-left: 16px">
        <h2>
            Responsive Topnav Example</h2>
        <p>
            Resize the browser window to see how it works.</p>
    </div>
    <script>
        function myFunction() {
            var x = document.getElementById("myTopnav");
            if (x.className === "topnav") {
                x.className += " responsive";
            } else {
                x.className = "topnav";
            }
        }
    </script>--%>

     <%--   <table border="1" id="tbl">
            <tr>
                <asp:Repeater id="Repeater1" runat="server">
                    <ItemTemplate>
                        <td runat="server"><%# Eval("ID") %></td>
                    </ItemTemplate>
                    <SeparatorTemplate>
            </tr>
            <tr>
                    </SeparatorTemplate>
                </asp:Repeater>
            </tr>
        </table>--%>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="dvGrid" style="width: 100%">
        <asp:GridView ID="gvTest" runat="server" CssClass="col-lg-12 gridstyle" AutoGenerateColumns="False" HorizontalAlign="Center" Font-Size="Large" 
        CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
        EmptyDataText = "Seems like you have not raised any tickets! Kindly raise tickets for them to show up here! :)"
        Font-Names="Montserrat" Font-Bold="true" AllowPaging=true AllowSorting=true OnSorting="SortGrid" OnPageIndexChanging="PageGrid" >

            <Columns>
               <%-- <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" ItemStyle-Width="200">
                    <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="TicketDetails.aspx?TicketNo={0}"
                                HeaderText="Ticket No" ItemStyle-Width = "120" ItemStyle-HorizontalAlign="Center" SortExpression="TicketNo"  />

                <asp:BoundField DataField="TicketRaisedDate" HeaderText="Raised Date" ItemStyle-Width="120" SortExpression="TicketRaisedDate">
                    <ItemStyle Width="120px" HorizontalAlign="Center" Height="50px"></ItemStyle>
                </asp:BoundField>

               <%-- <asp:BoundField DataField="AppName" HeaderText="Application Name" ItemStyle-Width="120" SortExpression="TicketNo">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>

                <%--<asp:BoundField DataField="UserName" HeaderText="Being Handled By" ItemStyle-Width="120" SortExpression="TicketNo">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>

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
  </form>   
</body>

<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="jquery.blockUI.js"></script>
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

<%--<script type="text/javascript">
    var table = document.getElementById('tbl');
    var tbody = table.getElementsByTagName('tbody')[0];
  //  var rows = tbody.getElementsByTagName('tr');
    var cells = tbody.getElementsByTagName('td');

    //for (var j = 0, rowlen = rows.length; j < rowlen; j++ ) {
        for (var i = 0, len = cells.length; i < len; i++) {
            if (i % cells.length === 0) {
                cells[i].className = 'red';
            }
            else if (i % cells.length === 1) {
                cells[i].className = 'green';
            }
            else if (i % cells.length === 2) {
                cells[i].className = 'blue';
            }
            else if (i % cells.length === 3) {
                cells[i].className = 'orange';
            }
            else if (i % cells.length === 4) {
                cells[i].className = 'yellow';
            }
            else if (i % cells.length === 5) {
                cells[i].className = 'violet';
            }
            else if (i % cells.length === 6) {
                cells[i].className = 'navy';
            }
            else if (i % cells.length === 7) {
                cells[i].className = 'lime';
            }
            else if (i % cells.length === 8) {
                cells[i].className = 'maroon';
            }
            else if (i % cells.length === 9) {
                cells[i].className = 'black';
            }
        }
 //  }
</script>--%>
</html>
