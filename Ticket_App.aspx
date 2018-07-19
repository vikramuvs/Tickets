<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="Ticket_App.aspx.cs" Inherits="Ticket_App" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Tile.css" rel="Stylesheet" />
    <style>
        div > a:link
        {
            color: White;
        }
        
        div > a:hover
        {
            color: White;
        }
        
        div > a:visited
        {
            color: White;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <br />
    <div class="row container" style="font-family: Montserrat; font-size: large;">
        Welcome, &nbsp;
        <asp:Label Font-Size="Large" Font-Names="Montserrat" Text="" Font-Bold="true" runat="server"
            ID="lblUser"></asp:Label>
    </div>
    <br />

  <div class="container" style="min-height: 250px; margin: 0 auto;" >

        <a class="tile invoice" href="viewTicket.aspx?src=Dash&type=R">
            <div class="header">
                <div class="count" runat="server" id="raisedCount">
                    </div>
                <div class="title">
                    Tickets</div>
            </div>
            <div class="body">
                <div class="title">
                    Tickets Raised</div>
            </div>
        </a>

        <a class="tile resource" href="viewTicket.aspx?src=Dash&type=W">
            <div class="header">
                <div class="count" runat="server" id="awaitingResponseCount">
                    </div>
                <div class="title">
                   Tickets</div>
            </div>
            <div class="body">
                <div class="title">
                    Tickets Awaiting Response</div>
            </div>
        </a>

        <a class="tile job" href="viewTicket.aspx?src=Dash&type=I">
            <div class="header">
                <div class="count" runat="server" id="allotedCount">
                    </div>
                <div class="title">
                   Tickets</div>
            </div>
            <div class="body">
                <div class="title">
                    Tickets Assigned</div>
            </div>
        </a>


        <div class="tile wide quote">
        <a href="viewTicket.aspx?src=Dash&type=C">
            <div class="header">
                <div class="left" >
                    <div class="count" id="disposedCount" runat="server">
                        </div>
                    <div class="title">
                        Disposed</div>
                </div></a>
                <a href="viewTicket.aspx?src=Dash&type=X">
                <div class="right">
                    <div class="count" runat="server" id="rejectedCount">
                        </div>
                    <div class="title">
                        Rejected</div>
                </div></a>
            </div>
            <div class="body">
                <div class="title">
                   Tickets Concluded</div>
            </div>
        </a>
 
 </div>
</asp:Content>

