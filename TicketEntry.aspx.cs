using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;

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

        //SqlCommand cmdI = new SqlCommand("INSERT INTO tbl_TicketDetails(TicketNo,TicketRaisedDate,RaisedAppID,RaisedByID,RaisedByContactNo,RaisedByEmailID,IssueDetails,IssueRelatedTo,CircleID,AppIssueID) VALUES(@TicketNo,@TicketRaisedDate,@RaisedAppID,@RaisedByID,@RaisedByContactNo,@RaisedByEmailID,@IssueDetails,@IssueRelatedTo,@CircleID,@AppIssueID)", con);
        SqlCommand cmdI = new SqlCommand("sp_RaiseTicket", con);
        cmdI.CommandType = CommandType.StoredProcedure;
        cmdI.Parameters.AddWithValue("@TicketNo", lblTicketNo.InnerText);
        cmdI.Parameters.AddWithValue("@TicketRaisedDate", DateTime.Now);
        cmdI.Parameters.AddWithValue("@RaisedAppId", int.Parse(ddlApp.SelectedValue));
        cmdI.Parameters.AddWithValue("@RaisedById", ID);
        cmdI.Parameters.AddWithValue("@RaisedByEmailID", emailID);
        cmdI.Parameters.AddWithValue("@RaisedByContactNo", mobile.Text);
        cmdI.Parameters.AddWithValue("@IssueDetails", subject.Text);
        cmdI.Parameters.AddWithValue("@IssueRelatedTo", ddlIssueType.SelectedItem.Text);
        cmdI.Parameters.AddWithValue("@CircleID", int.Parse(Session["userCircleID"].ToString()));
        cmdI.Parameters.AddWithValue("@LastActionTakenDate", DateTime.Now);
        cmdI.Parameters.AddWithValue("@AppIssueID", ddlAppIssueType.SelectedValue != "" ? ddlAppIssueType.SelectedValue : DBNull.Value.ToString());
        con.Open();
        int result=cmdI.ExecuteNonQuery();
        con.Close();

        if (result > 0)
        {
            raiseTicketDiv.Visible = false;
            updPanelEntry.Visible = false;
            SendEmail(emailID, lblTicketNo.InnerText, ddlApp.SelectedItem.Text);
          //  SendSMS();
            ticketTokenDetails.Visible = true;
        }
       // ScriptManager.RegisterStartupScript(this, GetType(), "AlertCode", "alert('Your Ticket Number is: " + lblTicketNo.InnerText + " ');", true);   
        ////con.Open(); 

    }

    private void SendEmail(string toEmailID, string ticketNo, string appName)
    {
        
        using (MailMessage mm = new MailMessage("vikramuvs@gmail.com", toEmailID))
        {
            mm.Subject = "Complaint No: " + lblTicketNo.InnerText + " raised successfully on " + DateTime.Now.ToString() ;
            mm.IsBodyHtml = true;
            if (ddlIssueType.SelectedIndex != 1)
                mm.Body = this.PopulateBody(toEmailID, appName, DateTime.Now.Date.ToString(), ticketNo, true);
            else
                mm.Body = this.PopulateBody(toEmailID, appName, DateTime.Now.Date.ToString(), ticketNo);
            //mm.Body = "Dear " + toEmailID + "," + "<br/><br /><br />";
            //mm.Body += "Your complaint against the application <strong>" + appName + "</strong> has been successfully raised on " + DateTime.Now.ToString() + ".<br />";
            //mm.Body += "Your Ticket No. is:  <h5><b><u>" + ticketNo + "</u></b></h5>" + ". <br/>";
            //mm.Body += "Kindly note this Ticket No. and ";
            //mm.Body += "Mention this Ticket No. for all your future correspondances with the ICT Wing regarding complaints of the Computer Application. <br />";
            //mm.Body += "Thank You. <br /> Have a Nice Day! <br />";
            //mm.Body += "Team ICT. <br />";
            //mm.Body += "Information & Communication Technology Center, <br/>";
            //mm.Body += "Aranya Bhavana, <br />";
            //mm.Body += "18th Cross, Malleshwaram <br />";
            //mm.Body += "Bengaluru - 560 003";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("vikramuvs@gmail.com", "eureka!@");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        }
    }
    
    private string PopulateBody(string userName, string appName, string raisedDate, string ticketNo, bool toFillApplicationOrNot = false)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{UserName}", userName);
        body = body.Replace("{IssueType}", ddlIssueType.SelectedItem.Text);
        body = body.Replace("{RaisedDate}", raisedDate);
        body = body.Replace("{TicketNo}", ticketNo);
        if (toFillApplicationOrNot != false)
            body = body.Replace("{ExtraStuffForApplicationNameInCaseOfComplaintBeingAssociatedWithTheApplication}", "The concerned application for which the complaint was raised is <b>" + appName + "</b> <br />" );
        else
            body = body.Replace("{ExtraStuffForApplicationNameInCaseOfComplaintBeingAssociatedWithTheApplication}", "" );

        return body;
    }

    public static string GetResponse(string sURL)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
        request.MaximumAutomaticRedirections = 4;
        request.Credentials = CredentialCache.DefaultCredentials;
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string sResponse = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return sResponse;
        }
        catch
        {
            return "";
        }
    }

    public string SendSmsFromSMSLane(string MobileNo, string Msg)
    {
        if ((MobileNo == ""))
        {
            // return false;
            // TODO: Exit Function: Warning!!! Need to return the value
            //return;
        }

        string rtn;
        MobileNo = ("91" + MobileNo);
        string sUserID = "conservatorhq";
        string sPwd = "p1q2r3S";
        //string sSID = "MAlert";
        string sSID = "KFDICT";
        string sMessage = Msg;
        string sURL;
        StreamReader objReader;

        sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" + sUserID + "&password=" + sPwd + "&msisdn=" + MobileNo + "&sid=" + sSID + "&msg=" + sMessage + "&fl=0&gwid=2";

        try
        {
            Stream objStream;
            string sResponse = GetResponse(sURL);
            //Response.Write(sResponse);

            rtn = "true";
        }
        catch (Exception ex)
        {

            rtn = "False";
        }
        return rtn;
    }


    protected void ddlIssueType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIssueType.SelectedValue != "0")
        {
            if (ddlIssueType.SelectedValue == "1")
            {
                ddlAppDiv.Visible = false;
                ddlAppIssueTypeDiv.Visible = false;
                ddlApp.Enabled = false;
                ddlApp.Visible = false;
                ddlAppIssueType.Enabled = false;
                ddlAppIssueType.Visible = false;
                ddlTrainingDiv.Visible = false;
                ddlTrainingApps.Enabled = false;
                ddlTrainingApps.Visible = false;
                divInfra.Visible = true;
            }

            if (ddlIssueType.SelectedValue == "2")
            {
                ddlAppDiv.Visible = true;
                ddlApp.Enabled = true;
                ddlApp.Visible = true;
                ddlAppIssueTypeDiv.Visible = false;
                divInfra.Visible = false;
                ddlAppIssueType.Enabled = false;
                ddlAppIssueType.Visible = false;
                ddlTrainingDiv.Visible = false;
                ddlTrainingApps.Enabled = false;
                ddlTrainingApps.Visible = false;
                ddlApp.Items.Clear();
                BindApp(ddlApp);
            }

            if (ddlIssueType.SelectedValue == "3")
            {
                ddlTrainingDiv.Visible = true;
                ddlTrainingApps.Visible = true;
                ddlTrainingApps.Enabled = true;
                divInfra.Visible = false;
                ddlAppDiv.Visible = false;
                ddlApp.Enabled = false;
                ddlApp.Visible = false;
                ddlAppIssueTypeDiv.Visible = false;
                ddlAppIssueType.Enabled = false;
                ddlAppIssueType.Visible = false;
                ddlTrainingApps.Items.Clear();
                BindApp(ddlTrainingApps);
            }
        }
    }
    
    private void BindApp(DropDownList ddl)
    {
        SqlCommand cmd = new SqlCommand("SELECT AppID,AppName FROM tbl_ApplicationMaster order by AppName ASC", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ddl.DataSource = dt;
        ddl.DataTextField = "AppName";
        ddl.DataValueField = "AppID";
        ListItem item = new ListItem();
        item.Text = "--Select Application--";
        item.Value = "";
        ddl.Items.Insert(0, item);
        ddl.Items.FindByText("--Select Application--").Attributes.Add("hidden", "");
        //ddl.Items.FindByText("--Select Application--").Attributes.Remove("value");
        //ddl.Items.FindByText("--Select Application--").Attributes.Add("value", "");
        ddl.DataBind();
    }
    
    protected void ddlApp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlApp.SelectedIndex != 0)
        {
            ddlAppIssueTypeDiv.Visible = true;
            ddlAppIssueType.Enabled = true;
            ddlAppIssueType.Visible = true;
            //if (ddlAppIssueType.Items.Count == 0)
            ddlAppIssueType.Items.Clear();
            BindIssue(ddlAppIssueType);
        }
    }

    private void BindIssue(DropDownList ddl)
    {
        SqlCommand cmd = new SqlCommand("SELECT issueID,IssueType FROM tbl_IssueMaster", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);        
        ddl.DataSource = dt;
        ddl.DataTextField = "IssueType";
        ddl.DataValueField = "issueID";
        ddl.Items.Insert(0, new ListItem("--Select Issue--",""));
        ddl.Items.FindByText("--Select Issue--").Attributes.Add("hidden", "");
        ddl.DataBind();
    }
}