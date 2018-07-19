using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;


public partial class Trackin1 : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    int counter = 0;
    int columnCount = 4;
    int colorCounter = 0;
    int colorSeperator = 4;

    HtmlTableCell c = new HtmlTableCell();

    protected void Page_Load(object sender, EventArgs e)
    {
        ////Repeater Repeater1 = new Repeater();
        //SqlCommand command = new SqlCommand("SELECT top 10 ID as 'ID' from tbl_TicketDetails", connection);
        //connection.Open();
        //Repeater1.DataSource = command.ExecuteReader(CommandBehavior.CloseConnection);
        //Repeater1.ItemDataBound +=new RepeaterItemEventHandler(Repeater1_ItemDataBound);
        //Repeater1.DataBind();

        if (!IsPostBack)
        {
            ViewState["sortField"] = "ID";
            ViewState["sortDirection"] = "ASC";
            Bind_Grid();
        }
    }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            

            //if (e.Item.ItemType == ListItemType.Item)
            //{
            //   // int initialCounter = counter;
            //   // if (counter == 1 || counter == 3)
            //     //   counter--;
            //   // if (counter == 2 || counter == 0)
            //     //   counter++;
                
            //    c = (HtmlTableCell)e.Item.FindControl("td");
            //    //counter--;
            //    if ((colorCounter % colorSeperator) == 0)
            //    {
                   
            //        c.Attributes.Add("style","background-color: green");
            //       // c.ForeColor = System.Drawing.Color.White;
            //    }
            //    if ((colorCounter % colorSeperator) == 1)
            //    {
                    
            //        c.Attributes.Add("style", "background-color: blue");
            //    }
            //    if ((colorCounter % colorSeperator) == 2)
            //    {

            //        c.Attributes.Add("style", "background-color: yellow");
            //    }
            //    if ((colorCounter % colorSeperator) == 3)
            //    {

            //        c.Attributes.Add("style", "background-color: orange");
            //    }
            //    colorCounter++;
            //   // counter = initialCounter;
            //}

            if (e.Item.ItemType == ListItemType.Separator)
                if ((++counter % columnCount) != 0)
                    e.Item.Visible = false;
        }

    private void Bind_Grid()
    {
        string query = "SELECT * from tbl_TicketDetails ORDER BY " + ViewState["sortField"].ToString() + " " + ViewState["sortDirection"].ToString();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(query, connection);
        da.Fill(dt);
        try 
        {
            gvTest.DataSource = dt;
            gvTest.DataBind();
        }
        catch (Exception except)
        {
            gvTest.PageIndex = 0;
        }
    }

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
        
        Bind_Grid();

    }

    protected void PageGrid(object sender, GridViewPageEventArgs e)
    {
        gvTest.PageIndex = e.NewPageIndex;
        Bind_Grid();
    }
}