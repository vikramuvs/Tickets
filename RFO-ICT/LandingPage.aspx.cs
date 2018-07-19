using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class LandingPage : System.Web.UI.Page
{
    int uID = int.MinValue;
    string uName;
    string conString = ConfigurationManager.ConnectionStrings["con"].ToString();
    int counter = 0;
    int columnCount = 4;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            uName = Session["uName"].ToString();
            uID = int.Parse(Session["uID"].ToString());
            // string uLevel = Session["uLevel"].ToString();
            // lblUser.Text = uName;
            defaultList();
        }
        catch (Exception except)
            {
                Response.Redirect("../Login.aspx");
            }
    }

    protected void defaultList()
    {
        string query = "sp_SearchApplication";
        //SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uID", uID);
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dlAppList.DataSource = reader;
                dlAppList.ItemDataBound += new RepeaterItemEventHandler(dlAppList_ItemDataBound);
                dlAppList.DataBind();
                //rptList.DataSource = reader;
                //rptList.DataBind();
            }
        }
     }

    protected string EncryptQueryString(string url)
    {
        //string monday_EString = "|\\/|()%\\|)/-\\/|_#$+*!|\\|&";
        //string tuesday_EString = "+()#$|)@\\/|#$+|)\\||\\/|&";
        //string wednesday_EString = "|/\\|#!)!\\/#$!)@\\/|#$+!)\\!\\/&";
        //string thursday_EString = "+|-|()|)\\$!)@\\/|#$+|)\\/(-|";
        //string friday_EString = "!|)\\|)@\\/|#$+|)\\|%&(-|";
        //string saturday_EString = "$@+()|)\\!)@||/|#$+%^*#(-|";
        //string sunday_EString = "$()|\\/!)@\\/\\#$!-|)\\!|\\/&(-|";

        //string today = DateTime.Now.Day.ToString();
        //string todays_EString = String.Empty;

        //switch (today)
        //{
        //    case "Monday" :
        //        todays_EString = DateTime.Now.Date.ToString() + monday_EString;
        //        break;

        //    case "Tuesday" :
        //        todays_EString = DateTime.Now.Date.ToString() + tuesday_EString;
        //        break;

        //    case "Wednesday" :
        //        todays_EString = DateTime.Now.Date.ToString() + wednesday_EString;
        //        break;

        //    case "Thursday" :
        //        todays_EString = DateTime.Now.Date.ToString() + thursday_EString;
        //        break;

        //    case "Friday" :
        //        todays_EString = DateTime.Now.Date.ToString() + friday_EString;
        //        break;

        //    case "Saturday" :
        //        todays_EString = DateTime.Now.Date.ToString() + saturday_EString;
        //        break;

        //    case "Sunday" :
        //        todays_EString = DateTime.Now.Date.ToString() + sunday_EString;
        //        break;
        //}

        //EncryptDecrpytString eString = new EncryptDecrpytString();
        //string todays_EString_Encrypted = eString.Encrypt(todays_EString, "r0b1nr0y");
        EncryptDecrpytString objEDQueryString = new EncryptDecrpytString();
        return url + "?" + objEDQueryString.Encrypt("emailId=" + uName, "r0b1nr0y");
    }

    protected void logOutButton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login.aspx");
    }

    protected void btnClick(object sender, EventArgs e)
    {
        LinkButton lbAppID = (LinkButton)sender;
        DataListItem dtRow = (DataListItem)(lbAppID.NamingContainer);

        Label appURL = dtRow.FindControl("lblAppID") as Label;
       
        Response.Redirect(EncryptQueryString(appURL.Text));
    }

    protected void dlAppList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Separator)
            if ((++counter % columnCount) != 0)
                e.Item.Visible = false;
    }
}
