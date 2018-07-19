<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="Ticket_App.aspx.cs" Inherits="Ticket_App" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link href="../Tile.css" rel="Stylesheet" />

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


<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
<br />
    <div class="row container" style="font-family: Montserrat; font-size: large;">
        Welcome, &nbsp;
        <asp:Label Font-Size="Large" Font-Names="Montserrat" Text="" Font-Bold="true" runat="server" ID="lblUser"></asp:Label>
    </div>
<br />
    <div style="margin-bottom: 100px;">
    <div class="container" style="min-height: 250px; background-color: #efefef; border-radius: 20px; min-width: 80%;">
        
    <div class="heading">
    Issues in Total
    </div>
        <a class="tile invoice" href="ProcessTickets.aspx?src=Dash&type=R">
            <div class="header">
                <div class="count" runat="server" id="raisedCount">
                    </div>
                <div class="title">
                    Issues</div>
            </div>
            <div class="body">
                <div class="title">
                    Issues Raised</div>
            </div>
        </a>

        <a class="tile resource" href="ProcessTickets.aspx?src=Dash&type=A">
            <div class="header">
                <div class="count" runat="server" id="attendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Attended</div>
            </div>
        </a>

        <a class="tile job" href="ProcessTickets.aspx?src=Dash&type=NA">
            <div class="header">
                <div class="count" runat="server" id="notAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Not Attended</div>
            </div>
        </a>

        <div class="tile wide quote">        
            <div class="header">
            <a href="viewTicket.aspx?src=Dash&type=C">
                <div class="left" >
                    <div class="count" id="waitingForAcknowledgementCount" runat="server">
                        </div>
                    <div class="title">
                        Awaiting Acknowledgement</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=X">
                <div class="right">
                    <div class="count" runat="server" id="rejectedCount">
                       </div>
                    <div class="title">
                        Rejected</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=S">
                <div class="right">
                    <div class="count" runat="server" id="resolvedCount">
                       </div>
                    <div class="title">
                        Resolved</div>
                </div>
                </a>
            </div>
            <div class="body">
                <div class="title">
                    Issues Addressed</div>
            </div>
        </div>
        </div>
        <br />

     <div class="container" style="min-height: 250px; background-color: #efefef; border-radius: 20px; min-width: 80%;">
        
    <div class="heading">
    Issues related to me
    </div>
        <a class="tile invoice" href="ProcessTickets.aspx?src=Dash&type=RR">
            <div class="header">
                <div class="count" runat="server" id="relatedToMeRaisedCount">
                    </div>
                <div class="title">
                    Issues</div>
            </div>
            <div class="body">
                <div class="title">
                    Issues Raised</div>
            </div>
        </a>

        <a class="tile resource" href="ProcessTickets.aspx?src=Dash&type=RA">
            <div class="header">
                <div class="count" runat="server" id="relatedToMeAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Attended</div>
            </div>
        </a>

        <a class="tile job" href="ProcessTickets.aspx?src=Dash&type=RNA">
            <div class="header">
                <div class="count" runat="server" id="relatedToMeNotAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Not Attended</div>
            </div>
        </a>

        <div class="tile wide quote">        
            <div class="header">
            <a href="viewTicket.aspx?src=Dash&type=RC">
                <div class="left" >
                    <div class="count" id="realtedToMeAwaitingAckCount" runat="server">
                        </div>
                    <div class="title">
                        Awaiting Acknowledgement</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=RX">
                <div class="right">
                    <div class="count" runat="server" id="relatedToMeRejectedCount">
                       </div>
                    <div class="title">
                        Rejected</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=RS">
                <div class="right">
                    <div class="count" runat="server" id="relatedToMeResolvedCount">
                       </div>
                    <div class="title">
                        Resolved</div>
                </div>
                </a>
            </div>
            <div class="body">
                <div class="title">
                    Issues Addressed</div>
            </div>
        </div>
        </div>
    <br />
    <div class="container" style="min-height: 250px; background-color: #efefef; border-radius: 20px; min-width: 80%;">
        
    <div class="heading">
    Issues related to my circle(s)
    </div>
        <a class="tile invoice" href="ProcessTickets.aspx?src=Dash&type=CR">
            <div class="header">
                <div class="count" runat="server" id="relatedToCircleRaisedCount">
                    </div>
                <div class="title">
                    Issues</div>
            </div>
            <div class="body">
                <div class="title">
                    Issues Raised</div>
            </div>
        </a>

        <a class="tile resource" href="ProcessTickets.aspx?src=Dash&type=CA">
            <div class="header">
                <div class="count" runat="server" id="relatedToCircleAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Attended</div>
            </div>
        </a>

        <a class="tile job" href="ProcessTickets.aspx?src=Dash&type=CNA">
            <div class="header">
                <div class="count" runat="server" id="relatedToCircleNotAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Not Attended</div>
            </div>
        </a>

        <div class="tile wide quote">        
            <div class="header">
            <a href="viewTicket.aspx?src=Dash&type=CC">
                <div class="left" >
                    <div class="count" id="relatedToCircleAwaitingAckCount" runat="server">
                        </div>
                    <div class="title">
                        Awaiting Acknowledgement</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=CX">
                <div class="right">
                    <div class="count" runat="server" id="relatedToCircleRejectedCount">
                       </div>
                    <div class="title">
                        Rejected</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=CS">
                <div class="right">
                    <div class="count" runat="server" id="relatedToCircleResolvedCount">
                       </div>
                    <div class="title">
                        Resolved</div>
                </div>
                </a>
            </div>
            <div class="body">
                <div class="title">
                    Issues Addressed</div>
            </div>
        </div>
        </div>
        <br />
        <div class="container" style="min-height: 250px; background-color: #efefef; border-radius: 20px; min-width: 80%;">
        <div class="heading">
        Issues Raised by me
        </div>
        <a class="tile resource" href="viewTicket.aspx?src=Dash&type=MR">
            <div class="header">
                <div class="count" runat="server" id="raisedByMeCount">
                    </div>
                <div class="title">
                    Issues</div>
            </div>
            <div class="body">
                <div class="title">
                    Issues Raised</div>
            </div>
        </a>

        <a class="tile quote" href="viewTicket.aspx?src=Dash&type=MA">
            <div class="header">
                <div class="count" runat="server" id="byMe_AttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                    Attended</div>
            </div>
        </a>

        <a class="tile job" href="viewTicket.aspx?src=Dash&type=MNA">
            <div class="header">
                <div class="count" runat="server" id="byMe_NotAttendedCount">
                    </div>
                <div class="title">
                   Issues</div>
            </div>
            <div class="body">
                <div class="title">
                   Not Attended</div>
            </div>
        </a>

        <div class="tile wide invoice">        
            <div class="header">
            <a href="viewTicket.aspx?src=Dash&type=MC">
                <div class="left" >
                    <div class="count" id="byMe_AwaitingAckCount" runat="server">
                        </div>
                    <div class="title">
                        Awaiting Acknowledgement</div>
                </div>
                </a>
                <a href="viewTicket.aspx?src=Dash&type=MX">
                <div class="right">
                    <div class="count" runat="server" id="byMe_RejectedCount">
                       </div>
                    <div class="title">
                        Rejected</div>
                </div>
                </a>
                 <a href="viewTicket.aspx?src=Dash&type=MS">
                <div class="right">
                    <div class="count" runat="server" id="byMe_ResolvedCount">
                       </div>
                    <div class="title">
                        Resolved</div>
                </div>
                </a>
            </div>
            <div class="body">
                <div class="title">
                    Issues Attended</div>
            </div>
        </div>
        </div>

  </div>
</asp:Content>

