using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Waindo.Conn;

public partial class Pages_home : System.Web.UI.Page
{
    protected Connection conn;

    protected void Page_Load(object sender, EventArgs e)
    {
        bool normal = true;
        if (normal && (Request.Params["sm"] is object)) normal = ServiceSelect(Request.Params["sm"].ToString());
        if (normal)
        {
            if (!IsPostBack)
            {

            }
        }
    }

    private bool ServiceSelect(string sm)
    {
        switch (sm)
        {

            case "jmlpolygon":
                Response.ContentType = "application/xhtml+xml";
                Response.Write(polygon());
                Response.End();
                return false;
                break;

            case "jmlrekap":
                Response.ContentType = "application/xhtml+xml";
                Response.Write(rekap());
                Response.End();
                return false;
                break;

            default:
                Response.ContentType = "text/plain";
                Response.End();
                return true;
        }
    }


    public string polygon()
    {
        String output = "";
        string DropDownAsset = "";
        string tambahan = "";
        string tambahan1 = "";

        if (Request.Params["DropDownAsset"] is object) DropDownAsset = Request.Params["DropDownAsset"].ToString();
        try
        {
            PUSKUH.ExecuteSTP eSTP = new PUSKUH.ExecuteSTP();
            eSTP.Datas();
            DataSet ds = new DataSet();
            ds = eSTP.ListReports("graphic", DropDownAsset, tambahan, tambahan1);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            output = "<chart caption=\"DASHBOARD \" XAxisName=\"KHWIL\" palette=\"2\" animation=\"1\" formatNumberScale=\"0\" numberSuffix=\"\" showValues=\"0\" numDivLines=\"4\" legendPosition=\"BOTTOM\">";
            output += "<categories>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<category label=\"" + RemoveWhiteSpace(dt.Rows[i]["KHWIL"].ToString()) + "\" />";
            }
            output += "</categories>";
            output += "<dataset seriesName=\"JUMLAH\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<set value=\"" + RemoveWhiteSpace(dt.Rows[i]["JUMLAH"].ToString()) + "\" />";
            }
            output += "</dataset>";

            output += "<styles> <definition><style type=\"font\" name=\"CaptionFont\" color=\"666666\" size=\"15\" /><style type=\"font\" name=\"SubCaptionFont\" bold=\"0\" /></definition><application><apply toObject=\"caption\" styles=\"CaptionFont\" /><apply toObject=\"SubCaption\" styles=\"SubCaptionFont\" /></application></styles></chart>";
        }
        catch (Exception e)
        {
            output = e.Message;
        }
        return output;

    }


    public string rekap()
    {
        String output = "";
        string DropDownAsset = "";
        string tambahan = "";
        string tambahan1 = "";

        if (Request.Params["DropDownAsset"] is object) DropDownAsset = Request.Params["DropDownAsset"].ToString();
        try
        {
            PUSKUH.ExecuteSTP eSTP = new PUSKUH.ExecuteSTP();
            eSTP.Datas();
            DataSet ds = new DataSet();
            ds = eSTP.ListReports("graphic", DropDownAsset, tambahan, tambahan1);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            output = "<chart caption=\"DASHBOARD REKAP \" XAxisName=\"KHWIL\" palette=\"2\" animation=\"1\" formatNumberScale=\"0\" numberSuffix=\"\" showValues=\"0\" numDivLines=\"4\" legendPosition=\"BOTTOM\">";
            output += "<categories>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<category label=\"" + RemoveWhiteSpace(dt.Rows[i]["KHWIL"].ToString()) + "\" />";
            }
            output += "</categories>";
            output += "<dataset seriesName=\"JUMLAH PEMOHON\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<set value=\"" + RemoveWhiteSpace(dt.Rows[i]["JMLPEMOHON"].ToString()) + "\" />";
            }
            output += "</dataset>";

            output += "<dataset seriesName=\"JUMLAH PENUNJUK\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<set value=\"" + RemoveWhiteSpace(dt.Rows[i]["JMLPENUNJUKAN"].ToString()) + "\" />";
            }
            output += "</dataset>";

            output += "<dataset seriesName=\"JUMLAH PENETAP\">";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<set value=\"" + RemoveWhiteSpace(dt.Rows[i]["JMLPENETAPAN"].ToString()) + "\" />";
            }
            output += "</dataset>";

            output += "<styles> <definition><style type=\"font\" name=\"CaptionFont\" color=\"666666\" size=\"15\" /><style type=\"font\" name=\"SubCaptionFont\" bold=\"0\" /></definition><application><apply toObject=\"caption\" styles=\"CaptionFont\" /><apply toObject=\"SubCaption\" styles=\"SubCaptionFont\" /></application></styles></chart>";
        }
        catch (Exception e)
        {
            output = e.Message;
        }
        return output;

    }


    private string RemoveWhiteSpace(string value)
    {
        value = value.Replace("&", "&amp;");
        value = value.Replace("<", "&lt;");
        value = value.Replace(">", "&gt;");
        value = value.Replace("'", "&apos;");
        value = value.Replace(",", ".");
        value = value.Replace(@"\", "&quot;");
        return value;
    }
}