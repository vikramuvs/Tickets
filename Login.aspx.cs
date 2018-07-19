using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.DirectoryServices.Protocols;
using System.Net;

public partial class Login : System.Web.UI.Page
{
    int isAuthenticated = int.MinValue;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //using (con)
        //{
        //    con.Open();
        //    using (SqlCommand cmd = new SqlCommand("select * from tbl_UserMaster where UserName=@uName and Password=@pass", con))
        //    {
        //        cmd.Parameters.AddWithValue("@uName", tbUserName.Text);
        //        cmd.Parameters.AddWithValue("@pass", tbPassword.Text);
        //        //string n = cmd.ExecuteScalar().ToString();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            Session["uName"] = dt.Rows[0]["UserName"];
        //            Session["uID"] = dt.Rows[0]["UserId"];

        //            //HttpCookie userInfo = new HttpCookie("emailId");
        //            //userInfo.Value = Session["uName"].ToString();
        //            //userInfo.Expires = DateTime.Now.AddHours(1);
        //            //userInfo.Domain = "192.168.50.138";
        //            //Response.Cookies.Add(userInfo);

        //            if (Session["uName"].ToString().ToLower().Equals("Admin".ToLower()))
        //                Response.Redirect("AdminLandingPage.aspx");
        //            else
        //                Response.Redirect("LandingPage.aspx");
        //        }

        //        else
        //        {
        //            lblStatus.Text = "Incorrect Username/Password. Please check your username and password.";
        //            lblStatus.Visible = true;
        //        }

        //     }
        //}

        isAuthenticated = Auth(tbUserName.Text, tbPassword.Text);

        if (isAuthenticated == 1)
        {
            SqlCommand cmd = new SqlCommand("select UserId, UserName, LoginStatus, Role , CircleID, CIRCLE_ENAME from tbl_UserMaster inner join tbl_CircleMaster on [tbl_UserMaster].CircleID=[tbl_CircleMaster].CIRCLE_ID where UserName = @uName", con);
            cmd.Parameters.AddWithValue("@uName", tbUserName.Text);

            //cmd.Parameters.AddWithValue();
           // cmd.Parameters.AddWithValue("@pass", tbPassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Session["uName"] = dt.Rows[0]["UserName"];
                Session["uID"] = dt.Rows[0]["UserId"];
                Session["userLevel"] = dt.Rows[0]["LoginStatus"];
                Session["Role"] = dt.Rows[0]["Role"];
                //Session["userCircle"] = dt.Rows[0]["CIRCLE_ENAME"];
                //Session["userCircleID"] = dt.Rows[0]["CircleID"];
                string getCircleForUserQuery = "select circleID from tbl_RFO_Circle_Mapper where userID=" + Session["uID"].ToString();
                SqlCommand cmd1 = new SqlCommand(getCircleForUserQuery, con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                int rowCountOfCircle = dt1.Rows.Count;
                if (rowCountOfCircle > 0)
                {
                    if (rowCountOfCircle > 1)
                    {
                        while (rowCountOfCircle > 1)
                        {
                            Session["userCircleID"] = dt1.Rows[rowCountOfCircle - 1]["circleID"].ToString() + ",";
                            rowCountOfCircle--;
                        }
                        Session["userCircleID"] += dt1.Rows[rowCountOfCircle - 1]["circleID"].ToString();
                        string s = Session["userCircleID"].ToString();
                    }

                    else if (rowCountOfCircle == 1)
                    {
                        Session["userCircleID"] = dt1.Rows[rowCountOfCircle]["circleID"].ToString();
                    }
                }
            }

            if (int.Parse(Session["userLevel"].ToString()) > 9)
            {

                Response.Redirect("AdminLandingPage.aspx");
            }
            
            else if (Session["Role"].ToString().Contains("ICT"))
            {
                Response.Redirect("RFO-ICT/Ticket_App.aspx");
            }
            
            else
            {
                //Session["uName"] = tbUserName.Text;
                Response.Redirect("Ticket_App.aspx");
            }
        }
        
        else
        {
            lblStatus.Text = "Invalid Credentials. Check and try again.";
            tbUserName.Text = "";
            tbPassword.Text = "";
            lblStatus.Visible = true;
        }
        
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbUserName.Text = "";
        tbPassword.Text = "";
    }

    protected int Auth(string strLdapUserId, string strLdapPassword)
    {
        int flag;

        try
        {
            // Set up the LDAP Server info.
            LdapDirectoryIdentifier myLdapDirectoryIdentifier = new LdapDirectoryIdentifier("localhost:389", true, false);

            // Establish LDAP userid and password to be used. 
            NetworkCredential myCredentials = new NetworkCredential("cn=" + strLdapUserId + ", cn=people, cn=Sandbox, dc=ITOrg", strLdapPassword);

            // Connect to the LDAP Server.
            LdapConnection myLdapConnection = new LdapConnection(myLdapDirectoryIdentifier, myCredentials, AuthType.Basic);

            // Set SSL and LDAP Protocol options.            
            myLdapConnection.SessionOptions.SecureSocketLayer = false;
            myLdapConnection.SessionOptions.ProtocolVersion = 3;

            // Bind to the LDAP Server.
            myLdapConnection.Bind();

           

            // No exception thrown. Authentication is successful.
            flag = 1;
            return flag;
        }

        catch (Exception)
        {
            // An exception is thrown. Authentication did NOT succeed.
            flag = 0;
            return flag;
        }
    }

    protected void btnClick_Click(object sender, EventArgs e)
    {
        //LdapConnection connection = new LdapConnection("fabrikam.com");
        NetworkCredential credential = new NetworkCredential("cn=Administrator, cn=People, cn=Sandbox, dc=ITOrg", "admin");
        
        LdapDirectoryIdentifier identifier = new LdapDirectoryIdentifier("localhost:389", true, false);
        LdapConnection connection = new LdapConnection(identifier, credential, AuthType.Basic);

        connection.Credential = credential;

        for (int i = 1; i <= 2; i++)
        {
            string dn = "cn=user" + i + ",cn=People,cn=Sandbox,dc=ITOrg";
            connection.SendRequest(new AddRequest(dn, "user"));
        }
    }


}