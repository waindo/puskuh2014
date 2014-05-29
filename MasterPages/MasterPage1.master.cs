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
using Waindo.Conn;
using System.Net;
using System.IO;

public partial class MasterPages_MasterPage1 : System.Web.UI.MasterPage
{
    protected String username = "";
    protected String unit = "";
    protected String Nama = "";
    protected String kode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        setProperties();
        if (!(Session["username"] is object))
        {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write("alert('Session sudah habis. Silakan login kembali.');");
            Response.Write("location.href = 'login_page.htm';");
            Response.Write("</script>");
        }

    }

    private void setProperties()
    {
        if (Session["username"] is object)
        {
            username = Session["username"].ToString();
        }
        if (Session["unit"] is object)
        {
            unit = Session["unit"].ToString();
        }
        if (Session["Nama"] is object)
        {
            Nama = Session["Nama"].ToString();
        }
        if (Session["kode"] is object)
        {
            kode = Session["kode"].ToString();
        }

    }
}
