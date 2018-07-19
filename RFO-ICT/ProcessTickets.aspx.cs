using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class TicketingSystem_RFO_ICT_ProcessTickets : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    string queryTypeSrc = null;
    string queryTypeCommand = null;
    int userID = 0;
    string emailID = null;
    string role = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //try
            //{
            //    string ticketQuery = string.Empty;
            //    int userID = int.Parse(Session["uID"].ToString());
            //    string emailID = Session["uName"].ToString();
            //    SqlCommand cmd = new SqlCommand();

            //    //if (Session["Role"].ToString().Contains("RFO"))
            //    //{
            //    //    ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID WHERE RaisedByID=@userID";
            //    //    cmd = new SqlCommand(ticketQuery, con);
            //    //    cmd.Parameters.AddWithValue("@userID", userID);
            //    //}

            //    if (Session["Role"].ToString().Contains("ICT"))
            //    {
            //        ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId";
            //        cmd = new SqlCommand(ticketQuery, con);
            //       // cmd.Parameters.AddWithValue("@handlerID", userID);
            //    }

            //    con.Open();
            //    gridTicketDetails.Visible = true;
            //    gridTicketDetails.EmptyDataText = "No Records Found";
            //    gridTicketDetails.DataSource = cmd.ExecuteReader();
            //    gridTicketDetails.DataBind();
            //    con.Close();
            //}
            try
            {
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                userID = int.Parse(Session["uID"].ToString());
                emailID = Session["uName"].ToString();
                role = Session["Role"].ToString();
                queryTypeSrc = Request.QueryString[0].ToString();
                queryTypeCommand = Request.QueryString[1].ToString();
                SqlCommand cmd = new SqlCommand();
                BindGrid(userID, emailID, role, queryTypeSrc, queryTypeCommand);
            }

            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "System.NullReferenceException")
                Response.Redirect("../Login.aspx");
                if (ex.GetType().ToString() == "System.ArgumentOutOfRangeException")
                {
                    queryTypeSrc = null;
                    queryTypeCommand = null;
                    BindDefaultGrid(userID);
                }
            }
        }
    }

    protected void BindDefaultGrid(int userID)
    {
        string ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,r.UserName as 'RaisedBy',t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
        ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId LEFT OUTER JOIN tbl_UserMaster r on t.RaisedByID=r.UserId ";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(ticketQuery, con);
        da.Fill(dt);
        gridTicketDetails.Visible = true;
        gridTicketDetails.DataSource = dt;
        gridTicketDetails.DataBind();
    }

    protected void BindGrid(int userID, string emailID, string role, string queryTypeSrc, string queryTypeCommand)
    {
        string ticketQuery = null;

        if (queryTypeSrc == "Dash")
        {
            switch (queryTypeCommand)
            {
                case "R":
                    ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,r.UserName as 'RaisedBy',t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                    ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId LEFT OUTER JOIN tbl_UserMaster r on t.RaisedByID=r.UserId ";
                    break;

                case "W":
                    ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,r.UserName as 'RaisedBy',t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                    ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId LEFT OUTER JOIN tbl_UserMaster r on t.RaisedByID=r.UserId WHERE t.LastActionTaken='R'";
                    break;

                case "I":
                    ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,r.UserName as 'RaisedBy',t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                    ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId LEFT OUTER JOIN tbl_UserMaster r on t.RaisedByID=r.UserId WHERE t.LastActionTaken='I'";
                    break;
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ticketQuery, con);
            da.Fill(dt);
            gridTicketDetails.Visible = true;
            gridTicketDetails.DataSource = dt;
            gridTicketDetails.EmptyDataText = "No Records Found!";
            gridTicketDetails.DataBind();
        }

        else
            BindDefaultGrid(userID);
    }

    protected void BindAllProcessTickets()
    {
        try
        {
            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();

            // string emailID = "rfobangalore@aranya.gov.in";
            string TicketQ = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a  ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId where BeingHandledByID = @handlerID";

            SqlCommand cmd = new SqlCommand(TicketQ, con);
            cmd.Parameters.AddWithValue("@handlerID", userID);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@userID", userID);

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //    if(dt.Rows.Count>0)
            //    {
            con.Open();
            //gridTicketDetails.Visible = true;
            gridTicketDetails.EmptyDataText = "No Records Found";
            gridTicketDetails.DataSource = cmd.ExecuteReader();
            gridTicketDetails.DataBind();
            con.Close();
        }

        catch (Exception ex)
        {
            if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }
    }

    protected void searchTicket(object sender, EventArgs e)
    {
        try
        {

            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();

            // string emailID = "rfobangalore@aranya.gov.in";
            string TicketQ = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID WHERE TicketNo=@TicketNo AND RaisedByID=@userID";

            SqlCommand cmd = new SqlCommand(TicketQ, con);
            cmd.Parameters.AddWithValue("@TicketNo", txtSearchTicket.Text);
            cmd.Parameters.AddWithValue("@userID", userID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 1)
            {
                //con.Open();
                //gridTicketDetails.Visible = true;
                //gridTicketDetails.EmptyDataText = "No Records Found";
                gridTicketDetails.Enabled = true;
                gridTicketDetails.Visible = true;
                gridTicketDetails.DataSource = dt;
                gridTicketDetails.DataBind();
            }

            else if (dt.Rows.Count < 1)
            {
                gridTicketDetails.EmptyDataText = "No Records Found";
                gridTicketDetails.Enabled = true;
                gridTicketDetails.Visible = true;
                gridTicketDetails.DataSource = dt;
                gridTicketDetails.DataBind();

            }

            else if (dt.Rows.Count == 1)
            {
                gridTicketDetails.Visible = false;

            }
            //con.Close();

            //}
            //else
            //{
            //    gridTicketDetails.Visible=false;
            //    Label2.Text="The search term"+txtSearchTicket+"&nbsp;Is not Available in the Ticket records or Invalid Login";
            //}
        }

        catch (Exception ex)
        {
            if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }

    }
    //protected void OnPaging(object sender, GridViewPageEventArgs e)
    //{
    //    gridTicketDetails.PageIndex = e.NewPageIndex;

    //}

    protected void btnFetch_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton ib = (ImageButton)sender;
            GridViewRow row = (GridViewRow)(ib.NamingContainer);
            Label lbTicketId = row.FindControl("lblTicketID") as Label;
            Session["processTicketID"] = lbTicketId.Text;
            int ticketId = int.Parse(lbTicketId.Text);
            string beingHandledBy = row.Cells[5].Text;

            DataTable dt = new DataTable();
            
            string query = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,b.UserName as BeingHandledBy,t.RaisedByContactNo,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails,t.Remarks FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID INNER JOIN tbl_UserMaster u on t.RaisedByID=u.UserId LEFT OUTER JOIN tbl_UserMaster b on t.BeingHandledByID = b.UserId WHERE ID=@ID";

            SqlCommand cmd = new SqlCommand(query, con);
          
            cmd.Parameters.AddWithValue("@ID", ticketId);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
          
            da.Fill(dt);
        
            if (beingHandledBy == "&nbsp;")
            {
                containerProcess.Visible = false;
                rptEditProcessDetails.Enabled = false;
                rptEditProcessDetails.Visible = false;
                dlAssign.Enabled = true;
                dlAssign.Visible = true;
                containerAssign.Visible = true;
                dlAssign.DataSource = dt;
                dlAssign.DataBind();
            }

            else
            {
                dlAssign.Enabled = false;
                dlAssign.Visible = false;
                containerAssign.Visible = false;
                containerProcess.Visible = true;
                rptEditProcessDetails.Enabled = true;
                rptEditProcessDetails.Visible = true;
                rptEditProcessDetails.DataSource = dt;
                rptEditProcessDetails.DataBind();
            }

           // rptEditProcessDetails.DataSource = dt;
           // rptEditProcessDetails.DataBind();
        }

        catch (Exception ex)
        {
           // if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        string query = "update tbl_TicketDetails set LastActionTaken = 'X', LastActionTakenDate = @date, where ID = @id;";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@date", DateTime.Now);
        cmd.Parameters.AddWithValue("@id", int.Parse(Session["processTicketID"].ToString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllProcessTickets();
    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        TextBox tbRemarks = (TextBox)rptEditProcessDetails.Items[0].FindControl("txtRemarks");
        string txtRemarks = tbRemarks.Text;

        if (txtRemarks.Trim() == "")
        {
            BindAllProcessTickets();
        }

        else
        {
            string query = "update tbl_TicketDetails set LastActionTakenDate = @date, Remarks = @remarks where ID = @id;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", int.Parse(Session["processTicketID"].ToString()));
            cmd.Parameters.AddWithValue("@remarks", txtRemarks);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindAllProcessTickets();
        }
          
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        string query = "update tbl_TicketDetails set BeingHandledByID = @userId, LastActionTaken = 'C', LastActionTakenDate = @date, TicketAttendedOnDate = @attendedDate where ID = @id;";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@userId", int.Parse(Session["uID"].ToString()));
        cmd.Parameters.AddWithValue("@date", DateTime.Now);
        cmd.Parameters.AddWithValue("@attendedDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@id", int.Parse(Session["processTicketID"].ToString()));
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        BindAllProcessTickets();
    }

    protected void gridTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow grvRow = e.Row;
            ImageButton ibStatus = (ImageButton)grvRow.FindControl("btnFetch");
            //string hlProcessText = ((HyperLink)gridTicketDetails.Rows[e.Row.RowIndex].Cells[8].Controls[0]).Text;
            TableCell statusCell = e.Row.Cells[7];
            //TableCell linkButtonCell = e.Row.Cells[8];

            if (statusCell.Text == "I")
            {
                statusCell.Text = "In Process";
                statusCell.BackColor = System.Drawing.Color.Orange;
                statusCell.ForeColor = System.Drawing.Color.White;
                ibStatus.AlternateText = "Process Further";
                ibStatus.ImageUrl = "../Images/processFurther.png";
            }

            else if (statusCell.Text == "C")
            {
                statusCell.Text = "Close";
                statusCell.BackColor = System.Drawing.Color.Green;
                statusCell.ForeColor = System.Drawing.Color.White;
                ibStatus.AlternateText = null;
                ibStatus.ImageUrl = null;
            }

            //else if (statusCell.Text == "A")
            //{
            //    statusCell.Text = "Ticket Attended";
            //    statusCell.BackColor = System.Drawing.Color.Yellow;
            //    statusCell.ForeColor = System.Drawing.Color.Black;
            //    ibStatus.AlternateText = "Process Further";
            //    ibStatus.ImageUrl = "../Images/processFurther.png";
            //}

            else if (statusCell.Text == "R")
            {
                statusCell.Text = "Ticket Raised";
                statusCell.BackColor = System.Drawing.Color.Yellow;
                statusCell.ForeColor = System.Drawing.Color.Black;
                ibStatus.AlternateText = "Assign";
                ibStatus.ImageUrl = "../Images/Assign.png";
            }

            else if (statusCell.Text == "X")
            {
                statusCell.Text = "Rejected";
                statusCell.BackColor = System.Drawing.Color.Red;
                statusCell.ForeColor = System.Drawing.Color.White;
                ibStatus.AlternateText = null;
                ibStatus.ImageUrl = null;
            }

            //else
            //{
            //    ibStatus.AlternateText = "Assign";
            //    ibStatus.ImageUrl = "../Images/Assign.png";
            //}
        }
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        try
        {
            // string diUserName = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbUserName"))).Text.ToString();
            // string diPassword = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbPassword"))).Text.ToString();
            // string diRole = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbRole"))).Text.ToString();
            //string diApp1 = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbAppName1"))).Text.ToString();
            //string diApp2 = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbAppName2"))).Text.ToString();
            //string diApp3 = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbAppName3"))).Text.ToString();
            //string diApp4 = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbAppName4"))).Text.ToString();
            //string diApp5 = ((TextBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("tbAppName5"))).Text.ToString();
            //ListBox lbAppNames = (ListBox)(rptEditDetails.Items[rptEditDetails.SelectedIndex].FindControl("lbAppName"));
            //lbAppNames.DataSource = dt;
            //ImageButton ib = (ImageButton)sender;
            //GridViewRow row = (GridViewRow)(ib.NamingContainer);
            //Label lbTicketId = row.FindControl("lblTicketID") as Label;
            string query = "update tbl_TicketDetails set BeingHandledByID = @userId, LastActionTaken = 'I', LastActionTakenDate = @date, TicketAttendedOnDate = @attendedDate where ID = @id;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", int.Parse(Session["uID"].ToString()));
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@attendedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", int.Parse(Session["processTicketID"].ToString()));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindAllProcessTickets();
        }
        catch (Exception ex)
        {
            //if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }
    }

    [System.Web.Services.WebMethod]
    public static string[] GetTicketList(string rfoID, string searchTerm)
    {
        List<string> ticketsRaised = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select TicketNo from tbl_TicketDetails where TicketNo like @SearchText + '%' and RaisedByID = @RaisedByID";
                cmd.Parameters.AddWithValue("@SearchText", searchTerm);
                cmd.Parameters.AddWithValue("@RaisedByID", rfoID);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ticketsRaised.Add(string.Format("{0}", sdr["TicketNo"]));
                    }
                }
                conn.Close();
            }
        }
        return ticketsRaised.ToArray();
    }

}