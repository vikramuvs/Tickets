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
        //string a = "l";
        if (!IsPostBack)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            ViewState["sortField"] = "TicketNo";
            ViewState["sortDirection"] = "ASC";
            try
            {
                userID = int.Parse(Session["uID"].ToString());
                emailID = Session["uName"].ToString();
                role = Session["Role"].ToString();
                queryTypeSrc = Request.QueryString[0].ToString();
                queryTypeCommand = Request.QueryString[1].ToString();
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

        if (IsPostBack)
        {
           // ViewState["sortField"] = "TicketNo";
           // ViewState["sortDirection"] = "ASC";
            try
            {
                userID = int.Parse(Session["uID"].ToString());
                emailID = Session["uName"].ToString();
                role = Session["Role"].ToString();
                queryTypeSrc = Request.QueryString[0].ToString();
                queryTypeCommand = Request.QueryString[1].ToString();
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

    protected void BindGrid(int userID, string emailID, string role, string queryTypeSrc, string queryTypeCommand)
     {
        string ticketQuery = null;

        switch (queryTypeCommand)
        {
            case "R" :
                ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.RaisedByID=" + userID.ToString() + " ";
                break;

            case "W" :
                ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.LastActionTaken='R' and t.RaisedByID=" + userID.ToString();
                break;

            case "I" :
                ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.LastActionTaken='I' and t.RaisedByID=" + userID.ToString();
                break;
            
            case "C" :
                ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='C') and t.RaisedByID=" + userID.ToString();
                break;

             case "X" :
                ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails ";
                ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE (t.LastActionTaken='X') and t.RaisedByID=" + userID.ToString();
                break;
        }
        ticketQuery += "ORDER BY" + " " + ViewState["sortField"].ToString() + " " + ViewState["sortDirection"].ToString();
        
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
        string ticketQuery = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.BeingHandledByID,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails " ;
        ticketQuery += "FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE t.RaisedByID=" + userID.ToString();
        ticketQuery += " ORDER BY " + ViewState["sortField"].ToString() + " " + ViewState["sortDirection"].ToString(); 
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


    protected void searchTicket(object sender, EventArgs e)
    {
        try
        {

            int userID = int.Parse(Session["uID"].ToString());
            string emailID = Session["uName"].ToString();

            // string emailID = "rfobangalore@aranya.gov.in";
            string TicketQ = "SELECT t.TicketNo,t.TicketRaisedDate,a.AppName,u.UserName,t.TicketAttendedOnDate,t.LastActionTaken,t.LastActionTakenDate,t.IssueDetails FROM tbl_TicketDetails t INNER JOIN tbl_ApplicationMaster a ON t.RaisedAppID=a.AppID LEFT OUTER JOIN tbl_UserMaster u on t.BeingHandledByID=u.UserId WHERE TicketNo=@TicketNo AND RaisedByID=@userID";

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
                //gridTicketDetails.Visible = false;
                //gridTicketDetails.Enabled = false;
                //dlTcktDtls.DataSource = dt;
                //dlTcktDtls.DataBind();
                //divTicketDetails.Visible = true;
                //my1.Visible = true;
                Response.Redirect("TicketDetails.aspx?TicketNo=" + txtSearchTicket.Text);
            }

            //}
            //else
            //{
            //    gridTicketDetails.Visible=false;
            //    Label2.Text="The search term"+txtSearchTicket+"&nbsp;Is not Available in the Ticket records or Invalid Login";
            //}
        }

        catch (Exception ex)
        {
            if (ex.GetType().ToString() ==  "System.NullReferenceException")
                Response.Redirect("Login.aspx");
        }
 
    }
    //protected void OnPaging(object sender, GridViewPageEventArgs e)
    //{
    //    gridTicketDetails.PageIndex = e.NewPageIndex;
       
    //}

    protected void SortGrid(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression.ToString() == ViewState["sortField"].ToString())
        {
            switch (ViewState["sortDirection"].ToString())
            {
                case "ASC":
                    ViewState["sortDirection"] = "DESC";
                    break;
                case "DESC":
                    ViewState["sortDirection"] = "ASC";
                    break;
            }
        }

        else
        {
            ViewState["sortField"] = e.SortExpression;
            ViewState["sortDirection"] = "DESC";
        }

        BindGrid(userID, emailID, role, queryTypeSrc, queryTypeCommand);

    }

    protected void PageGrid(object sender, GridViewPageEventArgs e)
    {
        gridTicketDetails.PageIndex = e.NewPageIndex;
        BindGrid(userID, emailID, role, queryTypeSrc, queryTypeCommand);
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
                        ticketsRaised.Add(string.Format("{0}:{1}", sdr["TicketNo"], sdr["TicketNo"]));
                    }
                }
                conn.Close();
            }
        }
        return ticketsRaised.ToArray();
    }

    //[System.Web.Services.WebMethod]
    //public static string GetStatus(string TicketNo)
    //{
    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    //    string query = "SELECT LastActionTaken AS status FROM tbl_TicketDetails WHERE TicketNo=@TicketNo";
    //    SqlCommand cmd = new SqlCommand(query, con);
    //    cmd.Parameters.AddWithValue("@TicketNo", TicketNo);
    //    con.Open();
    //    string status = cmd.ExecuteScalar().ToString();
    //    con.Close();
    //    return status;
    //}

}