﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ticket_App : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OnPageLoad();
    }

     protected void OnPageLoad()
    {
        lblUser.Text = "";
    }
}