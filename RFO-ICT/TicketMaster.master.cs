using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TicketMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        if (Request.Url.AbsoluteUri.Contains("Ticket"))
        {
            Apps.Attributes.Remove("class");
            Tickets.Attributes.Add("class", "active");
            home.Attributes.Remove("class");
        }

        if (Request.Url.AbsoluteUri.Contains("LandingPage"))
        {
            Tickets.Attributes.Remove("class");
            Apps.Attributes.Add("class", "active");
            home.Attributes.Remove("class");
        }

        if (Request.Url.AbsoluteUri.Contains("App"))
        {
            Tickets.Attributes.Remove("class");
            home.Attributes.Add("class", "active");
            Apps.Attributes.Remove("class");
        }

        try
        {
            if (Session["uName"].ToString() != null)
            {
                userName.InnerHtml = Session["uName"].ToString();
                userRole.InnerHtml = Session["Role"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../Login.aspx");
        }
    }

    protected void logOutButton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Login.aspx");
    }
}
