using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Waindo.Conn;
using System.Net;
using System.IO;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    Connection conn;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogindisable(object sender, EventArgs e)
    {
        Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
        Response.Write("alert('Mohon Maaf, Applikasi untuk sementara tidak dapat diakses');");
        //Response.Write("alert('Server sedang dimaintenance');");
        Response.Write("location.href = 'Login.aspx';");
        Response.Write("</script>");
    }
    protected void btnLogin2_ServerClick(object sender, EventArgs e)
    {
        string strcon = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionStringLogin"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);

        SqlCommand com = new SqlCommand("CheckUser", con);
        com.CommandType = CommandType.StoredProcedure;
        SqlParameter p1 = new SqlParameter("username", txtUserName.Value);
        SqlParameter p2 = new SqlParameter("password", txtPassword.Value);
        com.Parameters.Add(p1);
        com.Parameters.Add(p2);
        con.Open();


        SqlDataReader rd = com.ExecuteReader();
        if (rd.HasRows)
        {

            rd.Read();
            Session.Timeout = 600;
            Session["username"] = rd["username"].ToString();
            Session["unit"] = rd["unit"].ToString();
            Session["nama"] = rd["nama"].ToString();
            Session["kode"] = rd["kode"].ToString();
            String wil = rd["kode"].ToString();
            if (wil.ToString().Equals("1"))
            {
                Response.Redirect("pages/home.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write("alert('Username atau Password Salah..');");
            Response.Write("location.href = 'Login.aspx';");
            Response.Write("</script>");

        }
    }

    public bool validate()
    {
        //PrincipalContext pc = new PrincipalContext(ContextType.Domain, "corp.pgn.co.id");
        //bool isValid = false;
        //isValid = pc.ValidateCredentials(txtUserName.Value, txtPassword.Value);
        //return isValid;
        return true;
    }
    
}