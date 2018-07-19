<%@ Page Title="" Language="C#" MasterPageFile="TicketMaster.master" AutoEventWireup="true" CodeFile="TicketEntry.aspx.cs" Inherits="TicketingSystem_TicketEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="TicketEntry.aspx" runat="server" />
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" />--%>
    <link rel="stylesheet" href="Styles/bootstrap.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
    <%--  <script type="text/javascript">
        function Validate() {
            var mobile1 = document.getElementById('<%=mobile.ClientID%>').value

            var pattern = /^\d{10}$/;
            if (pattern.test(mobile1)) {
                alert("Your mobile number : " + mobile);
                return true;
            }
            alert("It is not valid mobile number!");
            return false;
        }
    </script>--%>

    <script type="text/javascript">
        function limitText(limitField, limitNum) {
            if (limitField.value.length > limitNum) {
                limitField.value = limitField.value.substring(0, limitNum);
            }
        }
    </script>
    <div id="mySidenav1">
        <a href="TicketEntry.aspx" id="raiseTicket1">Raise Ticket</a>
        <a href="viewTicket.aspx" id="viewTicket1">View Tickets</a>
    </div>

    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>

    <div class="form-group" id="raiseTicketDiv" runat="server">
        <asp:UpdatePanel ID="updPanelEntry" runat="server">

            <ContentTemplate>
        <div class="container">
            &nbsp;
        <h2>Raise Ticket</h2>
            <%--<form action="/action_page.php">--%>
            <%--<div class="form-group">
            <label for="name">Application Name:</label>
            <input type="text" class="form-control" id="name" placeholder="Enter Application Name" name="name" runat="server"/>
        </div>--%>
            <%--<select name="Applcations" runat="server">
            <option value="Enursey">Enursey</option>
            <option value="saab">Saab</option>
            <option value="fiat">Fiat</option>
            <option value="audi">Audi</option>
        </select>--%>

            <div class="form-group">
                <label for="ddlApp">What is your issue related to?</label>
                <asp:DropDownList ID="ddlIssueType" runat="server" Width="100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlIssueType_SelectedIndexChanged" required>
                    <asp:ListItem Text="-Select the type of issue-" Value="" hidden="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="IT Infrastructure" Value="1" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Applications" Value="2" Selected="False"></asp:ListItem>
                    <asp:ListItem Text="Training" Value="3" Selected="False"></asp:ListItem>
                </asp:DropDownList>   
                &nbsp;
            &nbsp;
            </div>

            <div id="divInfra" class="form-group" runat="server" visible="false" style="min-height: 100px; background-color: grey;">
                <%--<label for="ddlApp">Select Application:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" CssClass="form-control" Enabled="false" Visible="false"></asp:DropDownList>
                &nbsp;
            &nbsp;--%>
            </div>

            <div id="ddlAppDiv" class="form-group" runat="server" visible="false">
                <label for="ddlApp">Select Application:</label>
                <asp:DropDownList ID="ddlApp" runat="server" Width="100%" CssClass="form-control" AutoPostBack="true" Enabled="false" Visible="false" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlApp_SelectedIndexChanged" required></asp:DropDownList>
                &nbsp;
            &nbsp;
            </div>

            <div id="ddlAppIssueTypeDiv" class="form-group" runat="server" visible="false">
                <label for="ddlApp">Select the issue related to the application:</label>
                <asp:DropDownList ID="ddlAppIssueType" runat="server" Width="100%" CssClass="form-control" Enabled="false" Visible="false" AppendDataBoundItems="true" required></asp:DropDownList>
                &nbsp;
            &nbsp;
            </div>

            <div id="ddlTrainingDiv" class="form-group" runat="server" visible="false">
                <label for="ddlApp">Select the application you wish to be trained on:</label>
                <asp:DropDownList ID="ddlTrainingApps" runat="server" Width="100%" CssClass="form-control" Enabled="false" Visible="false" AppendDataBoundItems="true" required></asp:DropDownList>
                &nbsp;
            &nbsp;
            </div>

            <div class="form-group">
                <label for="mobile">Mobile Number:</label>
                <%--<input type="number" class="form-control" id="mobile" placeholder="Enter Mobile Number" name="number" runat="server" onchange="Validate()" onkeydown="limitText(this,10);" onkeyup="limitText(this,10);" required="required"/>--%>
                <asp:TextBox ID="mobile" required ErrorMessage="Please enter the Mobile Number" CssClass="form-control" Placeholder="Enter Mobile Number" runat="server" ValidationGroup="gp1" onkeydown="limitText(this,10);" onkeyup="limitText(this,10);" MaxLength="10"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="reqM" ControlToValidate="mobile" CssClass="valid-tooltip" ErrorMessage="Please enter the Mobile Number" ForeColor="Red" runat="server" ValidationGroup="gp1"></asp:RequiredFieldValidator>--%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="regM" ControlToValidate="mobile" ErrorMessage="Please enter valid mobile number" ForeColor="Red" runat="server" ValidationExpression="^[5-9]\d{9}$" ValidationGroup="gp1" Style="text-align: right"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="subject">Issue Details:</label>
                <%--<textarea id="subject" class="form-control" name="subject" placeholder="Write Issue Details.." runat="server"></textarea>--%>
                <asp:TextBox ID="subject" CssClass="form-control" placeholder="Write Issue Details.." runat="server" TextMode="MultiLine" />
            </div>

            <div class="clearfix">
                <asp:Button ID="btnSubmit" runat="server" OnClick="submitTicket" Text="Submit" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="gp1" />
                <asp:Button ID="btnCancel" runat="server" type="button" OnClick="cancelTicket" Text="Cancel" CssClass="btn btn-danger" CausesValidation="false" formnovalidate />
                <%--<button type="submit" class="signupbtn" onclick="submitTicket" runat="server">Submit</button>
            <button type="button" class="cancelbtn" runat="server">Cancel</button>--%>
            </div>

            <div>
                <asp:ValidationSummary ID="vs1" runat="server" CssClass="valid-tooltip" EnableClientScript="true" ValidationGroup="gp1" ShowSummary="true" ForeColor="Red" ErrorMessage="Please enter the Mobile Number" ShowMessageBox="True" />
                <%--<label id="lblTicketNo" runat="server" text=""></label>--%>
            </div>

        </div>
                </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlIssueType" />
                <asp:AsyncPostBackTrigger ControlID="ddlApp" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
            </asp:UpdatePanel>

    </div>

    <div class="container">
        <div id="ticketTokenDetails" runat="server" style="position: absolute; height: 40%; background-color: rgb(f,f,f); left: 33%; top: 30%; width: 33%; color: Black; font-family: Lucida Sans; text-align: center; font-size: 1.85em; border: 1px solid gray; vertical-align: middle; box-shadow: 5px 10px 18px #888888">
            <br />
            Thank you for raising the request with us. Your Complaint No. is
    <label id="lblTicketNo" runat="server" style="font-size: 2em; text-decoration: underline; color: rgba(0, 33, 46, 0.801);">
    </label>
            .
        <br />
            Please keep this number for future reference. An SMS and an Email has been sent to you mentioning the same.
        </div>
    </div>
</asp:Content>


<%-- <asp:DropDownList ID="ddlLength" runat="server">
                <asp:ListItem Text="5" Value="5" />
                <asp:ListItem Text="8" Value="8" />
                <asp:ListItem Text="10" Value="10" />
            </asp:DropDownList>--%>