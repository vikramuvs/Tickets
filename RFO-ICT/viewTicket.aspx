<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="viewTicket.aspx.cs" Inherits="viewTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.emptyGrid
{
    text-align: center;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <link id="Link1" rel="stylesheet" type="text/css" href="../StyleViewTicket.css" runat="server" />
    
     <div id="mySidenav1">
                    <a href="TicketEntry.aspx" id="raiseTicket1">Raise Ticket</a>
                    <a href="viewTicket.aspx" id="viewTicket1"> View Tickets</a>
                     <a href="ProcessTickets.aspx" id="processTicket1">Process Tickets</a>
                </div>
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
                <button id="Button1" type="submit" class="btn btn-info" onserverclick="searchTicket" runat="server" title="Search Tickets"><i class="fas fa-search"></i></button> 
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

     <div style="overflow-x: auto; width: 97%; margin: 100px auto;" runat="server" id="gridContainer">

        <asp:GridView ID="gridTicketDetails" runat="server" CssClass="col-lg-12 gridstyle"  AutoGenerateColumns="False" HorizontalAlign="Center" Font-Size="Large" 
        CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
        EmptyDataText = "Seems like you have not raised any tickets! Kindly raise tickets for them to show up here! :)" OnRowDataBound="gridTicketDetails_RowDataBound"
        Font-Names="Montserrat" Font-Bold="true">

            <Columns>
               <%-- <asp:BoundField DataField="TicketNo" HeaderText="Ticket No" ItemStyle-Width="200">
                    <ItemStyle Width="200px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="TicketDetails.aspx?TicketNo={0}"
                                HeaderText="Ticket No" ItemStyle-Width = "120" ItemStyle-HorizontalAlign="Center"  />

                <asp:BoundField DataField="TicketRaisedDate" HeaderText="Raised Date" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center" Height="50px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="AppName" HeaderText="Application Name" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="UserName" HeaderText="Being Handled By" ItemStyle-Width="120"><%--Name--%>
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="TicketAttendedOnDate" HeaderText="Ticket Attended Date" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="LastActionTaken" HeaderText="Action Taken" ItemStyle-Width="120">
                    <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="LastActionTakenDate" HeaderText="Last Action Taken Date" ItemStyle-Width="120">
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
            <EmptyDataRowStyle ForeColor="White" BackColor="Black" CssClass="emptyGrid" Font-Bold=true/>
        </asp:GridView>
    </div>

      <div id="openModal1" class="modalDialog">
                <div>
                    <a href="#close" title="Close" class="close">X</a>

                   <div id="container" style="min-height: 50%; width: auto;">
                    <asp:DataList ID="rptEditDetails" runat="server" BackColor="White" ForeColor="Black">
                        <ItemTemplate>
                            <table align="center" cellpadding="0" cellspacing="0" width="1000px" border="0" style="background-color: #ffffff; height: auto;">
                                <tr>
                                    <td>
                                        <hr style="color: #FBB917;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                        Ticket No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketNo" CssClass="form-control" Text='<%# Eval("TicketNo") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                        Ticket Raised Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketRaisedDate" CssClass="form-control" Text='<%# Eval("TicketRaisedDate") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                       Being Handled By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbBeingHandledBy" Text='<%# Eval("BeingHandledBy") %>' CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                        Concerned Application Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbAppName" CssClass="form-control" Text='<%# Eval("AppName") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td width="25%" align="left">
                                        Raised By:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbUserName" CssClass="form-control" Text='<%# Eval("UserName") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                               <tr>
                                    <td width="25%" align="left">
                                        Contact No:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbRaisedByContactNo" CssClass="form-control" Text='<%# Eval("RaisedByContactNo") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td width="25%" align="left">
                                        Ticket Attended On :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbTicketAttendedOnDate" CssClass="form-control" Text='<%# Eval("TicketAttendedOnDate") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                        Last Action Taken:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbLastActionTaken" CssClass="form-control" Text='<%# Eval("LastActionTaken") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left"> 
                                        Last Action Taken Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbALastActionTakenDate" CssClass="form-control" Text='<%# Eval("LastActionTakenDate") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" align="left">
                                        Issue Details:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbIssueDetails" CssClass="form-control" Text='<%# Eval("IssueDetails") %>' runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                 <%-- <tr>
                                    <td width="25%" align="left">
                                        Remarks:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" Text='<%# Eval("Remarks") %>' runat="server" Enabled="true"></asp:TextBox>
                                    </td>
                                </tr>--%>
                                </table>
                        </ItemTemplate>
                    </asp:DataList>
                       <table width="100%"> 
                           <tr width="100%">
                            <td width="20%"></td>
                               <td width="30%">
                                   <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Assign"
                                       OnClick="btnUpdate_Click" formnovalidate />
                               </td>
                               <td width="20%"></td>
                               <td width="30%">
                                   <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                                       OnClick="btnCancel_Click" formnovalidate />
                               </td>
                           </tr>
                       </table>
                      
                    <%--<div style="float: left; background-color: #fff; min-height: 40%;">--%>
                        <%-- <asp:ListBox ID="lbAppName" runat="server" AppendDataBoundItems="true" SelectionMode="Single">
                           <asp:ListItem Text='<%#Eval("AppName") %>' Value='<%#Eval("AppID") %>'></asp:ListItem> 
                        </asp:ListBox>--%>
                        <button id="btnFetch" title="Fetch" value="Fetch" onclick="fetchDetails()" ></button>
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

