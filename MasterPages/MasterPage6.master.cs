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

public partial class MasterPages_MasterPage6 : System.Web.UI.MasterPage
{
    protected String userName = "";
    protected String grupName = "";
    protected String userId = "";
    protected String grupId = "";
    protected String wilayah = "";
    protected string ipaddress = "";
    Connection conn;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //this.onlineuser.Text = "Users Online : " + Application["UserCount"].ToString();
        //this.onlineusers.Text = "Users online " + Application["UserCount"].ToString();
        savelog();
        setProperties();
        if (!(Session["userID"] is object))
        {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write("alert('Session sudah habis. Silakan login kembali.');");
            Response.Write("location.href = '../Login.aspx';");
            Response.Write("</script>");
        }
    }

    private void setProperties()
    {
        if (Session["userNames"] is object)
        {
            userName = Session["userNames"].ToString();
        }
        if (Session["userID"] is object)
        {
            userId = Session["userID"].ToString();
        }
        if (Session["groupID"] is object)
        {
            grupId = Session["groupID"].ToString();
        }
        if (Session["groupName"] is object)
        {
            grupName = Session["groupName"].ToString();
        }
        if (Session["usersWilay"] is object)
        {
            wilayah = Session["usersWilay"].ToString();
        }
        if (Session["ipaddress"] is object)
        {
            ipaddress = Session["ipaddress"].ToString();
        }
    }
    private string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }
    public void savelog()
    {
        string url = HttpContext.Current.Request.Url.AbsolutePath;
        string name = "";
        string sql = "";
        if (Session["userID"] is object)
        {
            name = Session["userID"].ToString();
        }
        DataTable dt2 = null;
        string ipaddress = "";
        ipaddress = GetUserIP().ToString();
        conn = new Connection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStrPGNLocal"].ToString());
        System.Web.HttpBrowserCapabilities browser = Request.Browser;
        string peremban = browser.Type;
        sql = "INSERT INTO PGN.USERS_LOG(usersIdsss,logontime,keterangan) values ('" + name + "',getdate(),'" + ipaddress + ", " + peremban + "," + url + "') ";
        dt2 = conn.sqlQuery(sql);
    }
}