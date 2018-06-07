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
            SqlCommand cmd = new SqlCommand("select * from tbl_UserMaster where UserName=@uName and Password=@pass", con);
            cmd.Parameters.AddWithValue("@uName", tbUserName.Text);
            cmd.Parameters.AddWithValue("@pass", tbPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["uName"] = dt.Rows[0]["UserName"];
                Session["uID"] = dt.Rows[0]["UserId"];
            }

            if (Session["uName"].ToString().Contains("admin") || Session["uName"].ToString().Contains("Admin"))
            {

                Response.Redirect("AdminLandingPage.aspx");
            }
            else
            {
                //Session["uName"] = tbUserName.Text;
                Response.Redirect("LandingPage.aspx");
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


}