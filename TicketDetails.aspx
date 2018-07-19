<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="TicketDetails.aspx.cs" Inherits="TicketingSystem_TicketDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<link rel="Stylesheet" href="Styles/StyleTimeLine.css" />
<script src="Scripts/milestones.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

      <div class="container">
      <div class="row" style="margin: 0 auto; width: 55%; font-size: x-large; font-family: Montserrat">
      Ticket Details for Ticket No : &nbsp; <a id="ticketNo" style="font-family: Roboto; font-weight: bold; font-size: x-large; text-decoration: underline;" runat="server"></a>
      </div><br />
          <div class="milestones" id="my1" type="hidden" style="margin-top: 20px;">
          </div>
    </div>

      <div id="divTicketDetails" style="margin: 150px auto; width:50%; height: auto;">
        <asp:DataList align="center" ID="dlTcktDtls" runat="server" AlternatingItemStyle-HorizontalAlign="Center" Font-Names="Roboto" Font-Size="Larger" CssClass="font-weight-bold table table-striped table-light table-hover" 
        Style="margin-bottom: 70px; display: grid; place-items: center;" ShowFooter="true" HorizontalAlign="Center">
            <ItemTemplate>
                <table>
                  <%--  <tr style="background-color:forestgreen; color:white;">
                        <th>Ticket No:</th><th><%# Eval("TicketNo")%></th>
                    </tr>--%>
                    <tr>
                        <td>Ticket Raised Date:
                        </td>
                        <td>
                            <%# Eval("TicketRaisedDate")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Application Name:
                        </td>
                        <td>
                            <%# Eval("AppName")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Raised By:
                        </td>
                        <td>
                            <%# Eval("RaisedByName")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Contact No.
                        </td>
                        <td>
                            <%# Eval("RaisedByContactNo")%>
                        </td>
                    </tr>
                    <tr >
                        <td>Handled By:
                        </td>
                        <td>
                            <%# Eval("UserName")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Attended Date:
                        </td>
                        <td>
                            <%# Eval("TicketAttendedOnDate")%>
                        </td>
                    </tr>
                    <tr >
                        <td>Last Action:
                        </td>
                        <td>
                            <%# Eval("LastActionTaken")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Last Action Date:
                        </td>
                        <td>
                            <%# Eval("LastActionTakenDate")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Issue Details:
                        </td>
                        <td>
                            <%# Eval("IssueDetails")%>
                        </td>
                    </tr>
                    <tr>
                        <td>Remarks:
                        </td>
                        <td>
                            <%# Eval("Remarks")%>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <script type="text/javascript">

        function GetStatusAjax(T) {
            $.ajax({
                type: "POST",
                url: '<%=ResolveUrl("TicketDetails.aspx/GetStatus") %>',
                data: '{TicketNo: "' + T + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                status = response.d;
                if (status == "R") {
                    StatusR();
                }
                //                else if (status == "A") {
                //                    StatusA();
                //                }
                else if (status == "I") {
                    StatusI();
                }
                else if (status == "C") {
                    StatusC();
                }
                else if (status == "X") {
                    StatusX();
                }
            }
        };
</script>

<script type="text/javascript">

        var status = "";

        function StatusR() {
            $('#my1').milestones({
                stage: 2,
                checks: 1,
                checkclass: 'checks',
                labels: ["Raised", "Attended", "In Progress", "Closed"]
            });
        }
        //        function StatusA() {
        //            $('#my1').milestones({
        //                stage: 3,
        //                checks: 2,
        //                checkclass: 'checks',
        //                labels: ["Raised", "Attended", "In Progress", "Closed"]
        //            });
        //        }
        function StatusI() {
            $('#my1').milestones({
                stage: 3,
                checks: 2,
                checkclass: 'checks',
                labels: ["Raised", "Attended", "In Progress", "Closed"]
            });
        }
        function StatusC() {
            $('#my1').milestones({
                stage: 4,
                checks: 4,
                stageclass: 'checks',
                labels: ["Raised", "Attended", "In Progress", "Closed"]
            });
        }
        function StatusX() {
            $('#my1').milestones({
                stage: 3,
                checks: 3,
                stageclass: 'checks',
                labels: ["Raised", "Attended", "Rejected"]
            });
        }
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                var pageURL = $(location).attr("href");
                //var my1 = document.getElementById("my1");
                //my1.hide();
                if (pageURL.split('=')[1] != null) {
                    GetStatusAjax(pageURL.split('=')[1]);
                    $('#my1').show();
                }
            });
        </script>
   
</asp:Content>

