using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Ticket_App : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        // string emailID = "rfobangalore@aranya.gov.in";
        try 
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            string userID = Session["uID"].ToString();
            string emailID = Session["uName"].ToString();
            string userCircleID = Session["userCircleID"].ToString();
            lblUser.Text = emailID.ToString();

            PopulateDivs(userID, emailID, userCircleID);
        }

        catch(Exception ex)
        {
            if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }

        // cmd.Parameters.AddWithValue("@TicketNo", txtSearchTicket.Text);
        //cmd.Parameters.AddWithValue("@userID", userID);

        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //    if(dt.Rows.Count>0)
        //    {
        //con.Open();
        //gridTicketDetails.Visible = true;
        //con.Close();
    }


    private void PopulateDivs(string userID, string emailID, string userCircleID)
    {
        string[] splitUserCircles = null;
        int lengthOfUserCircle = 1;

        if (userCircleID.Contains(","))
        {
            splitUserCircles = userCircleID.Split(',');
            lengthOfUserCircle = splitUserCircles.GetLength(0);
        }

        string raisedTicketQuery = "SELECT count(ID) from tbl_TicketDetails";
        string attendedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken != 'R'";
        string notAttendedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken = 'R'";
        string waitingForAckQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='C' or LastActionTaken='c' ";
        string rejectedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='X' or LastActionTaken='x' ";
        string resolvedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='S' or LastActionTaken='s' ";

        string raisedByMeTicketQuery = "SELECT count(ID) from tbl_TicketDetails where RaisedByID=" + userID;
        string attended_MeQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken != 'R' and RaisedByID=" + userID;
        string notAttended_MeQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken = 'R' and RaisedByID=" + userID;
        string waitingForAck_MeQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='C' or LastActionTaken='c') and RaisedByID=" + userID;
        string rejectedMeQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='X' or LastActionTaken='x') and RaisedByID=" + userID;
        string resolvedMeQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='S' or LastActionTaken='s' and RaisedByID=" + userID;

        string myCircle_RaisedQuery = "SELECT count(ID) from tbl_TicketDetails where (CircleID=";
        string myCircle_Attended_Query = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken != 'R' and (CircleID=";
        string myCircle_NotAttended_Query = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken = 'R' and (CircleID=";
        string myCircle_WaitingForAck_Query = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='C' or LastActionTaken='c') and (CircleID=";
        string myCircle_RejectedQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='X' or LastActionTaken='x') and (CircleID=";
        string myCircle_ResolvedQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='S' or LastActionTaken='s') and (CircleID=";

        if (lengthOfUserCircle > 1)
        {
            while (lengthOfUserCircle > 1)
            {
                myCircle_RaisedQuery += splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                myCircle_Attended_Query += splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                myCircle_NotAttended_Query += splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                myCircle_WaitingForAck_Query +=  splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                myCircle_RejectedQuery += splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                myCircle_ResolvedQuery += splitUserCircles[lengthOfUserCircle - 1] + " or CircleID=";
                lengthOfUserCircle--;
            }
           myCircle_RaisedQuery += splitUserCircles[lengthOfUserCircle-1] + ")";
           myCircle_Attended_Query += splitUserCircles[lengthOfUserCircle - 1] + ")";
           myCircle_NotAttended_Query += splitUserCircles[lengthOfUserCircle - 1] + ")";
           myCircle_WaitingForAck_Query += splitUserCircles[lengthOfUserCircle - 1] + ")";
           myCircle_RejectedQuery += splitUserCircles[lengthOfUserCircle - 1] + ")";
           myCircle_ResolvedQuery += splitUserCircles[lengthOfUserCircle - 1] + ")";

        }

        else if (lengthOfUserCircle == 1)
        {
            myCircle_RaisedQuery += userCircleID + ")";
            myCircle_Attended_Query += userCircleID + ")";
            myCircle_NotAttended_Query += userCircleID + ")";
            myCircle_WaitingForAck_Query += userCircleID + ")";
            myCircle_RejectedQuery += userCircleID + ")";
            myCircle_ResolvedQuery += userCircleID + ")";
        }

        string allotedToMe_RaisedQuery = "SELECT count(ID) from tbl_TicketDetails where BeingHandledByID=" + userID;
        string allotedToMe_AttendedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken != 'R' and BeingHandledByID=" + userID;
        string allotedToMe_NotAttendedQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken = 'R' and BeingHandledByID=" + userID;
        string allotedToMe_WaitingForAckQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='C' or LastActionTaken='c') and BeingHandledByID=" + userID;
        string allotedToMe_RejectedQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='X' or LastActionTaken='x') and BeingHandledByID=" + userID;
        string allotedToMe_ResolvedQuery = "SELECT count(ID) from tbl_TicketDetails where (LastActionTaken='S' or LastActionTaken='s') and BeingHandledByID=" + userID;

        SqlCommand cmd1 = new SqlCommand(raisedTicketQuery, con);
        SqlCommand cmd2 = new SqlCommand(attendedQuery, con);
        SqlCommand cmd3 = new SqlCommand(notAttendedQuery, con);
        SqlCommand cmd4 = new SqlCommand(waitingForAckQuery, con);
        SqlCommand cmd5 = new SqlCommand(rejectedQuery, con);
        SqlCommand cmd6 = new SqlCommand(resolvedQuery, con);

        SqlCommand cmdM1 = new SqlCommand(raisedByMeTicketQuery, con);
        SqlCommand cmdM2 = new SqlCommand(attended_MeQuery, con);
        SqlCommand cmdM3 = new SqlCommand(notAttended_MeQuery, con);
        SqlCommand cmdM4 = new SqlCommand(waitingForAck_MeQuery, con);
        SqlCommand cmdM5 = new SqlCommand(rejectedMeQuery, con);
        SqlCommand cmdM6 = new SqlCommand(resolvedMeQuery, con);

        SqlCommand cmdC1 = new SqlCommand(myCircle_RaisedQuery, con);
        SqlCommand cmdC2 = new SqlCommand(myCircle_Attended_Query, con);
        SqlCommand cmdC3 = new SqlCommand(myCircle_NotAttended_Query, con);
        SqlCommand cmdC4 = new SqlCommand(myCircle_WaitingForAck_Query, con);
        SqlCommand cmdC5 = new SqlCommand(myCircle_RejectedQuery, con);
        SqlCommand cmdC6 = new SqlCommand(myCircle_ResolvedQuery, con);

        SqlCommand cmdA1 = new SqlCommand(allotedToMe_RaisedQuery, con);
        SqlCommand cmdA2 = new SqlCommand(allotedToMe_AttendedQuery, con);
        SqlCommand cmdA3 = new SqlCommand(allotedToMe_NotAttendedQuery, con);
        SqlCommand cmdA4 = new SqlCommand(allotedToMe_WaitingForAckQuery, con);
        SqlCommand cmdA5 = new SqlCommand(allotedToMe_RejectedQuery, con);
        SqlCommand cmdA6 = new SqlCommand(allotedToMe_ResolvedQuery, con);

        con.Open();

        raisedCount.InnerText = cmd1.ExecuteScalar().ToString();
        attendedCount.InnerText = cmd2.ExecuteScalar().ToString();
        notAttendedCount.InnerText = cmd3.ExecuteScalar().ToString();
        waitingForAcknowledgementCount.InnerText = cmd4.ExecuteScalar().ToString();
        rejectedCount.InnerText = cmd5.ExecuteScalar().ToString();
        resolvedCount.InnerText = cmd6.ExecuteScalar().ToString();

        relatedToMeRaisedCount.InnerText = cmdA1.ExecuteScalar().ToString();
        relatedToMeAttendedCount.InnerText = cmdA2.ExecuteScalar().ToString();
        relatedToMeNotAttendedCount.InnerText = cmdA3.ExecuteScalar().ToString();
        realtedToMeAwaitingAckCount.InnerText = cmdA4.ExecuteScalar().ToString();
        relatedToMeRejectedCount.InnerText = cmdA5.ExecuteScalar().ToString();
        relatedToMeResolvedCount.InnerText = cmdA6.ExecuteScalar().ToString();

        relatedToCircleRaisedCount.InnerText = cmdC1.ExecuteScalar().ToString();
        relatedToCircleAttendedCount.InnerText = cmdC2.ExecuteScalar().ToString();
        relatedToCircleNotAttendedCount.InnerText = cmdC3.ExecuteScalar().ToString();
        relatedToCircleAwaitingAckCount.InnerText = cmdC4.ExecuteScalar().ToString();
        relatedToCircleRejectedCount.InnerText = cmdC5.ExecuteScalar().ToString();
        relatedToCircleResolvedCount.InnerText = cmdC6.ExecuteScalar().ToString();

        raisedByMeCount.InnerText = cmdM1.ExecuteScalar().ToString();
        byMe_AttendedCount.InnerText = cmdM2.ExecuteScalar().ToString();
        byMe_NotAttendedCount.InnerText = cmdM3.ExecuteScalar().ToString();
        byMe_AwaitingAckCount.InnerText = cmdM4.ExecuteScalar().ToString();
        byMe_RejectedCount.InnerText = cmdM5.ExecuteScalar().ToString();
        byMe_ResolvedCount.InnerText = cmdM6.ExecuteScalar().ToString();

        con.Close();
    }
}