using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


public partial class Ticket_App : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();
            lblUser.Text = emailID.ToString();
            string raisedTicketQuery = "SELECT count(ID) from tbl_TicketDetails where RaisedByID=" + Session["uID"].ToString();
            string awaitingResponseQuery = "SELECT count(ID) from tbl_TicketDetails where BeingHandledByID is null and RaisedByID=" + Session["uID"].ToString();
            string allotedTicketQuery = "SELECT count(ID) from tbl_TicketDetails where BeingHandledByID is not null and RaisedByID=" + Session["uID"].ToString();
            string disposedTicketQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='C' or LastActionTaken='c' and RaisedByID=" + Session["uID"].ToString();
            string rejectedTicketQuery = "SELECT count(ID) from tbl_TicketDetails where LastActionTaken='X' or LastActionTaken='x' and RaisedByID=" + Session["uID"].ToString();

            SqlCommand cmd = new SqlCommand(raisedTicketQuery, con);
            SqlCommand cmd2 = new SqlCommand(awaitingResponseQuery, con);
            SqlCommand cmd3 = new SqlCommand(allotedTicketQuery, con);
            SqlCommand cmd4 = new SqlCommand(disposedTicketQuery, con);
            SqlCommand cmd5 = new SqlCommand(rejectedTicketQuery, con);

            con.Open();
            raisedCount.InnerText = cmd.ExecuteScalar().ToString();
            awaitingResponseCount.InnerText = cmd2.ExecuteScalar().ToString();
            allotedCount.InnerText = cmd3.ExecuteScalar().ToString();
            disposedCount.InnerText = cmd4.ExecuteScalar().ToString();
            rejectedCount.InnerText = cmd5.ExecuteScalar().ToString();
            con.Close();        
        }
        
        catch (System.Exception ex)
        {
            if(ex.InnerException is System.NullReferenceException)
            Response.Redirect("Login.aspx");
        }
        
    }
}