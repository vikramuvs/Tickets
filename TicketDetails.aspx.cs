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

public partial class TicketingSystem_TicketDetails : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            string queryString = Request.QueryString[0].ToString();
            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();

            ShowTicketDetails(queryString, userID, emailID);
        }

        catch(Exception ex)
        {
            if (ex.GetType().ToString() == "System.NullReferenceException")
                Response.Redirect("Login.aspx");
        }
    }



    protected void ShowTicketDetails(string queryString, int userID, string emailID)
    {
        //divTicketDetails.Visible = true;
        string query = "SELECT t.TicketNo,t.TicketRaisedDate,t.Remarks,a.AppName,u.UserName,r.UserName as RaisedByName,t.RaisedByContactNo,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId LEFT OUTER JOIN tbl_UserMaster r on t.RaisedByID=r.UserId WHERE TicketNo='" + queryString + "' AND RaisedByID=" + userID.ToString();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        da.Fill(dt);
        dlTcktDtls.Enabled = true;
        dlTcktDtls.Visible = true;
        dlTcktDtls.DataSource = dt;
        dlTcktDtls.DataBind();
        ticketNo.InnerHtml = queryString;
    }


    [System.Web.Services.WebMethod]
    public static string GetStatus(string TicketNo)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        string query = "SELECT LastActionTaken AS status FROM tbl_TicketDetails WHERE TicketNo=@TicketNo";

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@TicketNo", TicketNo);
        con.Open();
        string status = cmd.ExecuteScalar().ToString();
        con.Close();
        return status;
    }
}