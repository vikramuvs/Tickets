<%@ Page Title="Process Tickets - Aranya Ticketing System" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="ProcessTickets.aspx.cs" Inherits="TicketingSystem_RFO_ICT_ProcessTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../StyleViewTicket.css" />

    <table align="center">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ticket Number:
            </td>
            <td>
                <asp:TextBox ID="txtSearchTicket" runat="server" CssClass="form-control" Height="40px" Width="200px" required></asp:TextBox>
                <%--<asp:RegularExpressionValidator ID="revUserName" runat="server" ErrorMessage="Please enter Alphabet and Numbers only"
                 ValidationExpression="^[0-9A-Z]+$" ControlToValidate="txtSearchTicket" Display="Dynamic"></asp:RegularExpressionValidator>--%>
            </td>
            <td>&nbsp;</td>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Text="Search" OnClick="searchTicket" CssClass="btn btn-info"/>--%>
                <button id="Button1" type="submit" class="btn btn-info" onserverclick="searchTicket" runat="server" title="Search Tickets"> <i class="fas fa-search"></i></button> 
            </td>
        </tr>
    </table>
    <table align="center">
        <tr>
            <td>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="" CssClass="label" ForeColor="#6B6B6B"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
    <div class="form-group" id="raiseTicketDiv" runat="server">
        <div id="mySidenav1">
            <a href="TicketEntry.aspx" id="raiseTicket1">Raise Ticket</a> <a href="viewTicket.aspx"
                id="viewTicket1">View Tickets</a> <a href="ProcessTickets.aspx" id="processTicket1">Process
                    Tickets</a>
        </div>
    </div>
    <div style="overflow-x: auto; z-index: 1; margin: 100px auto; width: 97%;">

        <asp:GridView ID="gridTicketDetails" runat="server" CssClass="col-lg-12" AutoGenerateColumns="False" HorizontalAlign="Center" Font-Size="Medium" CellPadding="4" GridLines="Horizontal" 
                      BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" BackColor="#444444" RowStyle-CssClass="gridstyle"
                      OnRowDataBound="gridTicketDetails_RowDataBound" 
                      Font-Names="Montserrat" Font-Bold="false">
        <Columns>
                <asp:TemplateField HeaderText="Ticket ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblTicketID" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" ItemStyle-Width="200">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TicketRaisedDate" HeaderText="Raised Date" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" Height="50px" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="AppName" HeaderText="Application Name" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="RaisedBy" HeaderText="Raised By" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UserName" HeaderText="Handled By" ItemStyle-Width="120"><%--Name--%>
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TicketAttendedOnDate" HeaderText="Attended Date" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LastActionTaken" HeaderText="Action Taken" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LastActionTakenDate" HeaderText="Last Action Taken Date" ItemStyle-Width="120">
                    <ItemStyle Width="11.1%" HorizontalAlign="Center" Font-Bold="true"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="11.1%">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnFetch" runat="server" PostBackUrl="#openModal1" OnClick="btnFetch_Click" Width="100px" Height="35px" formnovalidate />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle  ForeColor="Black" BackColor="White" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </div>

      <div id="openModal1" class="modalDialog">
                <div>
                    <a href="#close" title="Close" class="close">X</a>

                   <div id="containerProcess" style="width: auto;" runat="server" visible="false">
                    <asp:DataList ID="rptEditProcessDetails" runat="server" BackColor="White" ForeColor="Black" Enabled="false" Visible="false">
                        <ItemTemplate>
                            <table align="center" cellpadding="0" cellspacing="0" width="1000px" border="0" style="background-color: #ffffff; height: 80vh;">
                                <thead>
                                    <tr>
                                        <th style="height: 40px; text-align: center;" colspan="2"> Ticket Details for <%# Eval("TicketNo") %>
                                        </th>
                                    </tr>
                                </thead>
                              <%--  <tr>
                                    <td width="25%" align="left">
                                        Ticket No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketNo" CssClass="form-control" Text='<%# Eval("TicketNo") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td width="25%" align="right">
                                        Ticket Raised Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketRaisedDate" CssClass="form-control" Text='<%# Eval("TicketRaisedDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Raised App Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbAppName" CssClass="form-control" Text='<%# Eval("AppName") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td width="25%" align="right">
                                        Raised By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbUserName" CssClass="form-control" Text='<%# Eval("UserName") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                                    <td width="25%" align="right">
                                        Contact No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbRaisedByContactNo" CssClass="form-control" Text='<%# Eval("RaisedByContactNo") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                       Being Handled By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbBeingHandledBy" Text='<%# Eval("BeingHandledBy") %>' CssClass="form-control" runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td width="25%" align="right">
                                        Ticket Attended On :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketAttendedOnDate" CssClass="form-control" Text='<%# Eval("TicketAttendedOnDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Last Action Taken:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbLastActionTaken" CssClass="form-control" Text='<%# Eval("LastActionTaken") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right"> 
                                        Last Action Taken Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbALastActionTakenDate" CssClass="form-control" Text='<%# Eval("LastActionTakenDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Issue Details:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbIssueDetails" CssClass="form-control" Text='<%# Eval("IssueDetails") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                    <td width="25%" align="right">
                                        Remarks:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" Text='<%# Eval("Remarks") %>' TextMode="MultiLine" runat="server" Enabled="true" style="width: 60%;"></asp:TextBox>
                                    </td>
                                </tr>
                                </table>
                        </ItemTemplate>
                    </asp:DataList>
                       <table width="100%"> 
                           <tr width="100%">
                           <%-- <td width="20%"></td>--%>
                               <td width="25%" align="center">
                                   <asp:Button ID="btnProcess" runat="server" CssClass="btn btn-primary" Text="Update" OnClientClick="return confirm('Are you sure you want to Process this ticket further?');"
                                       OnClick="btnProcess_Click" formnovalidate />
                               </td>
                               <td width="25%" align="center">
                                <asp:Button ID="btnClose" runat="server" CssClass="btn btn-secondary" Text="Close Ticket" OnClientClick = "return confirm('Are you sure you want to CLOSE this ticket? This action cannot be undone!');"
                                       OnClick="btnClose_Click" formnovalidate />
                               </td>
                               <td width="25%" align="center">
                                   <asp:Button ID="btnReject" runat="server" CssClass="btn btn-info" Text="Reject Ticket" OnClientClick = "return confirm('Are you sure you want to REJECT this ticket? This action cannot be undone!');"
                                       OnClick="btnReject_Click" formnovalidate />
                               </td>
                               <td width="25%" align="center">
                                   <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                                       OnClick="btnCancel_Click" formnovalidate />
                               </td>
                           </tr>
                       </table>
                      
                    <%--<div style="float: left; background-color: #fff; min-height: 40%;">--%>
                        <%-- <asp:ListBox ID="lbAppName" runat="server" AppendDataBoundItems="true" SelectionMode="Single">
                           <asp:ListItem Text='<%#Eval("AppName") %>' Value='<%#Eval("AppID") %>'></asp:ListItem> 
                        </asp:ListBox>
                        <button id="btnFetch" title="Fetch" value="Fetch" onclick="fetchDetails()" ></button>--%>
                    </div>
                    <div id="containerAssign" runat="server" visible="false">
                      <asp:DataList ID="dlAssign" runat="server" BackColor="White" ForeColor="Black" Enabled="false" Visible="false">
                        <ItemTemplate>
                            <table align="center" cellpadding="0" cellspacing="0" width="1000px" border="0" style="background-color: #ffffff; height: 80vh;">
                                <thead>
                                    <tr>
                                        <th style="height: 40px; text-align: center;" colspan="2"> Ticket Details for <%# Eval("TicketNo") %>
                                        </th>
                                    </tr>
                                </thead>
                              <%--  <tr>
                                    <td width="25%" align="left">
                                        Ticket No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketNo" CssClass="form-control" Text='<%# Eval("TicketNo") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td width="25%" align="right">
                                        Ticket Raised Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketRaisedDate" CssClass="form-control" Text='<%# Eval("TicketRaisedDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Raised App Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbAppName" CssClass="form-control" Text='<%# Eval("AppName") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td width="25%" align="right">
                                        Ticket Raised By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbUserName" CssClass="form-control" Text='<%# Eval("UserName") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                                    <td width="25%" align="right">
                                        Contact No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbRaisedByContactNo" CssClass="form-control" Text='<%# Eval("RaisedByContactNo") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                       Being Handled By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbBeingHandledBy" Text='<%# Eval("BeingHandledBy") %>' CssClass="form-control" runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td width="25%" align="right">
                                        Ticket Attended On :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketAttendedOnDate" CssClass="form-control" Text='<%# Eval("TicketAttendedOnDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Last Action Taken:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbLastActionTaken" CssClass="form-control" Text='<%# Eval("LastActionTaken") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right"> 
                                        Last Action Taken Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbALastActionTakenDate" CssClass="form-control" Text='<%# Eval("LastActionTakenDate") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="right">
                                        Issue Details:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbIssueDetails" CssClass="form-control" Text='<%# Eval("IssueDetails") %>' runat="server" Enabled="false" style="width: 50%;"></asp:TextBox>
                                    </td>
                                </tr>
                                 
                                 <tr>
                                    <td width="25%" align="right">
                                        Remarks:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" CssClass="form-control" Text='<%# Eval("Remarks") %>' TextMode="MultiLine" runat="server" Enabled="true" style="width: 60%;"></asp:TextBox>
                                    </td>
                                </tr>
                                </table>
                        </ItemTemplate>
                    </asp:DataList>
                       <table width="100%"> 
                           <tr width="100%">
                           <%-- <td width="20%"></td>--%>
                               <td width="50%" align="center">
                                   <asp:Button ID="btnAssign" runat="server" CssClass="btn btn-primary" Text="Assign to me" OnClientClick="return confirm('Are you sure you want to assign this ticket to yourself & process this ticket further? You cannot undo this action!');"
                                       OnClick="btnAssign_Click" formnovalidate />
                               </td>
                             <%--  <td width="25%" align="center">
                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-secondary" Text="Close Ticket" OnClientClick = "return confirm('Are you sure you want to CLOSE this ticket? This action cannot be undone!');"
                                       OnClick="btnClose_Click" formnovalidate />
                               </td>
                               <td width="25%" align="center">
                                   <asp:Button ID="Button4" runat="server" CssClass="btn btn-info" Text="Reject Ticket" OnClientClick = "return confirm('Are you sure you want to REJECT this ticket? This action cannot be undone!');"
                                       OnClick="btnReject_Click" formnovalidate />
                               </td>--%>
                               <td width="50%" align="center">
                                   <asp:Button ID="btnCancelAssign" runat="server" CssClass="btn btn-danger" Text="Cancel"
                                       OnClick="btnCancel_Click" formnovalidate />
                               </td>
                           </tr>
                       </table>
                       </div>
                               <%-- <div>
                                <input type="button" id="btnFetch" title="Fetch" />
                                </div>--%>

                               <%-- <div style="background-color: #fff;">
                                <asp:LinkButton ID="lbRight" runat="server" Text=">>" OnClick="btnRight_Click"></asp:LinkButton>

                                <asp:LinkButton ID="lbLeft" runat="server" Text="<<" OnClick="btnLeft_Click"></asp:LinkButton>
                                </div>--%>

                                <%--<div style="float: right; background-color: #fff; height: auto;">
                                <asp:ListBox ID="lbAppAlloted" runat="server" AppendDataBoundItems="true" SelectionMode="Single" >--%>
                                <%--<asp:ListItem Text='<%#Eval("AppName") %>' Value='<%#Eval("AppID") %>'></asp:ListItem>--%>
                               <%-- </asp:ListBox>
                                </div>--%>
                          
                               
                </div>
            </div>
</asp:Content>
