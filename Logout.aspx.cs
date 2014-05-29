using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Session.RemoveAll();
        Session.Abandon();
        Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
        Response.Write("location.href = 'Login.aspx';");
        Response.Write("</script>");
        //Response.Redirect("Login.aspx");
    }
}
