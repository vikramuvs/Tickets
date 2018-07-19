using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewTicket : System.Web.UI.Page
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
                    Response.Redirect("Login.aspx");
                if (ex.GetType().ToString() == "System.ArgumentOutOfRangeException")
                {
                    queryTypeSrc = null;
                    queryTypeCommand = null;
                    BindDefaultGrid(userID);
                }
            }
        }

    }
    protected void BindAll()
    {
        try
        {
            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();

            // string emailID = "rfobangalore@aranya.gov.in";
            string TicketQ = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a  ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId";

            SqlCommand cmd = new SqlCommand(TicketQ, con);
            // cmd.Parameters.AddWithValue("@TicketNo", txtSearchTicket.Text);
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
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)(lb.NamingContainer);
            Label lbOfficerId = row.FindControl("lblUserID") as Label;
            Session["editID"] = lbOfficerId.Text;
            int userId = int.Parse(lbOfficerId.Text);
            DataTable dt = new DataTable();
            //  DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            //  Response.Redirect("AdminLandingPage.aspx#openModal1");
            string query = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,b.UserName as BeingHandledBy,t.RaisedByContactNo,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID INNER JOIN tbl_UserMaster u on t.RaisedByID=u.UserId LEFT OUTER JOIN tbl_UserMaster b on t.BeingHandledByID = b.UserId WHERE ID=@ID";
            //query += "left outer join tbl_ApplicationMaster AM on A.AppID1 = AM.AppID ";
            //query += "left outer join tbl_ApplicationMaster AP on A.AppID2 = AP.AppID ";
            //query += "left outer join tbl_ApplicationMaster AQ on A.AppID3 = AQ.AppID ";
            //query += "left outer join tbl_ApplicationMaster AR on A.AppID4 = AR.AppID ";
            //query += "left outer join tbl_ApplicationMaster AT on A.AppID5 = AT.AppID ";
            //query += "where U.[Role] != 'Admin' and U.UserId = @userID";
            // string query1 = "select AppID, AppName from tbl_ApplicationMaster";
            //string query2 = " select AM.AppName, AM.AppURL from tbl_ApplicationMaster as AM inner join (select AppID ";
            //query2 += " from (select * from tbl_AppMapMaster1 where UserID=@uID) AM unpivot (AppID for IDNo in (AppID1, AppID2, AppID3, AppID4, AppID5) )as unpvt)";
            //query2 += "TempTable on AM.AppID=TempTable.AppID";

            SqlCommand cmd = new SqlCommand(query, con);
            // SqlCommand cmd1 = new SqlCommand(query1, con);
            //SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd.Parameters.AddWithValue("@ID", userId);
            cmd.CommandType = CommandType.Text;

            // cmd1.CommandType = CommandType.Text;

            //cmd2.Parameters.Add("@uID", userId);
            //cmd2.CommandType = CommandType.Text;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

            da.Fill(dt);
            // da1.Fill(dt1);
            // da2.Fill(dt2);

            //con.Open();

            if (dt.Rows[0]["BeingHandledBy"].ToString() == string.Empty)
            {
                 btnUpdate.Enabled = true;
               //btnUpdate.CssClass = "btn disabled";
            }

            if (dt.Rows[0]["BeingHandledBy"].ToString() != string.Empty)
            {
                btnUpdate.Enabled = false;
                btnUpdate.CssClass = "btn disabled";
            }

            rptEditDetails.DataSource = dt;
            rptEditDetails.DataBind();

            // lbAppName.DataSource = dt1.DefaultView;
            //lbAppName.DataTextField = dt1.Rows[1].ToString();
            //lbAppName.DataValueField = dt1.Rows[0].ToString();
            //  lbAppName.DataTextField = "AppName";
            //  lbAppName.DataValueField = "AppID";
            //  lbAppName.DataBind();

            // lbAppAlloted.DataSource = dt2.DefaultView;
            // lbAppAlloted.DataTextField = "AppName";
            // lbAppName.DataValueField = "AppID";
            // lbAppAlloted.DataBind();

            //con.Close();
        }

        catch (Exception ex)
        {
            if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
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
            string query = "update tbl_TicketDetails set BeingHandledByID = @userId, LastActionTaken = 'I', LastActionTakenDate = @date, TicketAttendedOnDate = @attendedDate where ID = @id;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userId", int.Parse(Session["uID"].ToString()));
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@attendedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", int.Parse(Session["editID"].ToString()));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindAll();
        }
        catch (Exception ex)
        {
            if (ex.InnerException is System.NullReferenceException)
                Response.Redirect("../Login.aspx");
        }
    }

    protected void BindGrid(int userID, string emailID, string role, string queryTypeSrc, string queryTypeCommand)
    {
        string ticketQuery = null;

        switch (queryTypeCommand)
        {
            case "MR":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.RaisedByID=" + userID.ToString();
                break;

            case "MW":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.LastActionTaken='R' and t.RaisedByID=" + userID.ToString();
                break;

            case "MI":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.LastActionTaken='I' and t.RaisedByID=" + userID.ToString();
                break;

            case "MC":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='C') and t.RaisedByID=" + userID.ToString();
                break;

            case "MX":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='X') and t.RaisedByID=" + userID.ToString();
                break;

            case "C":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='C' or t.LastActionTaken='c')";
                break;

            case "X":
                ticketQuery = "SELECT t.ID,t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='X' or t.LastActionTaken='x')";
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

    protected void BindDefaultGrid(int userID)
    {
        string ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
        ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.RaisedByID=" + userID.ToString();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(ticketQuery, con);
        da.Fill(dt);
        gridTicketDetails.Visible = true;
        gridTicketDetails.DataSource = dt;
        gridTicketDetails.DataBind();
    }

    protected void gridTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow grvRow = e.Row;
            //  ImageButton ibStatus = (ImageButton)grvRow.FindControl("btnFetch");
            //string hlProcessText = ((HyperLink)gridTicketDetails.Rows[e.Row.RowIndex].Cells[8].Controls[0]).Text;
            TableCell statusCell = e.Row.Cells[5];
            //TableCell linkButtonCell = e.Row.Cells[8];

            if (statusCell.Text == "I")
            {
                statusCell.Text = "In Process";
                statusCell.BackColor = System.Drawing.Color.Orange;
                statusCell.ForeColor = System.Drawing.Color.White;
                //   ibStatus.AlternateText = "Process Further";
                //   ibStatus.ImageUrl = "../Images/processFurther.png";
            }

            else if (statusCell.Text == "C")
            {
                statusCell.Text = "Close";
                statusCell.BackColor = System.Drawing.Color.Green;
                statusCell.ForeColor = System.Drawing.Color.White;
                //  ibStatus.AlternateText = null;
                //  ibStatus.ImageUrl = null;
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
                //  ibStatus.AlternateText = "Assign";
                //  ibStatus.ImageUrl = "../Images/Assign.png";
            }

            else if (statusCell.Text == "X")
            {
                statusCell.Text = "Rejected";
                statusCell.BackColor = System.Drawing.Color.Red;
                statusCell.ForeColor = System.Drawing.Color.White;
                // ibStatus.AlternateText = null;
                // ibStatus.ImageUrl = null;
            }

            //else
            //{
            //    ibStatus.AlternateText = "Assign";
            //    ibStatus.ImageUrl = "../Images/Assign.png";
            //}
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