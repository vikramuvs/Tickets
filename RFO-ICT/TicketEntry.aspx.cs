using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class TicketingSystem_TicketEntry : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
      
    protected void Page_Load(object sender, EventArgs e)
    {
        ticketTokenDetails.Visible = false;
        raiseTicketDiv.Visible = true;

        if (!IsPostBack)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            SqlCommand cmd=new SqlCommand("SELECT AppID,AppName FROM tbl_ApplicationMaster",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlApp.DataSource = dt;
            ddlApp.DataTextField = "AppName";
            ddlApp.DataValueField = "AppID";
            ddlApp.DataBind();
        }

    }
    protected void cancelTicket(object sender, EventArgs e)
    {
        Response.Redirect("RaiseTicket.aspx");

    }

    protected void submitTicket(object sender, EventArgs e)
    {
        con.Open();
        //SqlCommand cmdT = new SqlCommand("SELECT AppID FROM tbl_ApplicationMaster WHERE AppName=@AppName", con);
        //cmdT.Parameters.AddWithValue("@AppName",ddlApp.SelectedItem.Text);
        string AppID=ddlApp.SelectedItem.Value.ToString();
        string str = null;
        SqlCommand cmdA = new SqlCommand("SELECT AppCode FROM tbl_ApplicationMaster WHERE AppName=@AppName", con);
        cmdA.Parameters.AddWithValue("@AppName",ddlApp.SelectedItem.Text);
        string AppCode = cmdA.ExecuteScalar().ToString();

        str = "SELECT MAX(TicketNo) AS TicketNo FROM tbl_TicketDetails WHERE RaisedAppID=@AppID";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.AddWithValue("@AppID", ddlApp.SelectedItem.Value);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        con.Close();
        da1.Fill(ds);
        if (ds.Rows.Count > 0)
        {
            string TicketNo = ds.Rows[0]["TicketNo"].ToString();
            if (TicketNo == "")
            {
                lblTicketNo.InnerText = AppCode + "-" + "000000001";

            }
            else
            {
                string[] Array = TicketNo.Split('-');
                int FC = Convert.ToInt32(Array[1]);
                FC = FC + 1;
                if (FC.ToString().Length == 1)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "00000000" + FC;
                }
                else if (FC.ToString().Length == 2)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "0000000" + FC;
                }
                else if (FC.ToString().Length == 3)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "000000" + FC;
                }
                else if (FC.ToString().Length == 4)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "00000" + FC;
                }
                else if (FC.ToString().Length == 5)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "0000" + FC;
                }
                else if (FC.ToString().Length == 6)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "000" + FC;
                }
                else if (FC.ToString().Length == 7)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "00" + FC;
                }
                else if (FC.ToString().Length == 8)
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + "0" + FC;
                }
                else
                {
                    lblTicketNo.InnerText = AppCode.ToString() + "-" + FC;
                }
            }
        }
        //string emailID = Session["email"].ToString();
        string emailID = Session["uName"].ToString();
        //string ID=Session["RaisedByID"].ToString();
        int ID= int.Parse(Session["uID"].ToString());

        SqlCommand cmdI = new SqlCommand("INSERT INTO tbl_TicketDetails(TicketNo,TicketRaisedDate,RaisedAppID,RaisedByID,RaisedByContactNo,RaisedByEmailID,IssueDetails,LastActionTaken,LastActionTakenDate) VALUES(@TicketNo,@TicketRaisedDate,@RaisedAppID,@RaisedByID,@RaisedByContactNo,@RaisedByEmailID,@IssueDetails,@LastActionTaken,@LastActionTakenDate)", con);
        //SqlCommand cmd = new SqlCommand("sp_InsertTicket", con);
        cmdI.CommandType = CommandType.Text;
        cmdI.Parameters.AddWithValue("@TicketNo", lblTicketNo.InnerText);
        cmdI.Parameters.AddWithValue("@TicketRaisedDate", DateTime.Now);
        cmdI.Parameters.AddWithValue("@RaisedAppID", int.Parse(ddlApp.SelectedValue));
        cmdI.Parameters.AddWithValue("@RaisedByID", ID);
        cmdI.Parameters.AddWithValue("@RaisedByEmailID", emailID);
        cmdI.Parameters.AddWithValue("@RaisedByContactNo", mobile.Text);
        cmdI.Parameters.AddWithValue("@IssueDetails", subject.Text);
        cmdI.Parameters.AddWithValue("@LastActionTaken", "R");
        cmdI.Parameters.AddWithValue("@LastActionTakenDate", DateTime.Now);
        con.Open();
        int result=cmdI.ExecuteNonQuery();
        con.Close();

        if (result > 0)
        {
            raiseTicketDiv.Visible = false;
            ticketTokenDetails.Visible = true;
        }


       // ScriptManager.RegisterStartupScript(this, GetType(), "AlertCode", "alert('Your Ticket Number is: " + lblTicketNo.InnerText + " ');", true);
        
        ////con.Open(); 

    }

}