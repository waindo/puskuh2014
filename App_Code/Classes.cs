using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Sql;
using System.Data.SqlClient;


namespace PGN
{
    public class generateNUm
    {
        private string _stConSt;
        public string _stNumbr;
        #region Constructor
        public void Datas()
        {
            this._stConSt = System.Configuration.ConfigurationManager.AppSettings["dBconnection"];

        }
        #endregion

        #region generateNum
        public String GenerateNumber(string _byCompa, int _stSysc1, byte _stSysc2, string _stDates, string _stUsrid)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = "[pgn].[p_NUMBG]";
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_compa", System.Data.SqlDbType.VarChar)).Value = _byCompa;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_clas1", System.Data.SqlDbType.TinyInt)).Value = _stSysc1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_clas2", System.Data.SqlDbType.TinyInt)).Value = _stSysc2;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_dates", System.Data.SqlDbType.VarChar)).Value = _stDates;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_UsrID", System.Data.SqlDbType.VarChar)).Value = _stUsrid;

                SqlParameter vobParam = new System.Data.SqlClient.SqlParameter("@ot_nomor", System.Data.SqlDbType.VarChar, 20);
                //SqlParameter vobParam = new System.Data.SqlClient.SqlParameter("@ot_group", System.Data.SqlDbType.VarChar, 20);
                vobParam.Direction = System.Data.ParameterDirection.Output;
                vobCommd.Parameters.Add(vobParam);



                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed)
                    {
                        vobConne.Open();

                    }
                    vobCommd.Connection = vobConne;
                    vobCommd.ExecuteNonQuery();
                    _stNumbr = vobParam.Value.ToString();

                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }


            return _stNumbr;
        }

        #endregion

    }
    //public class inspeksiKerangan
    //{
    //    private string _stConSt;
    //    public string _stNumbr;

    //    #region Constructor
    //    public void Datas()
    //    {
    //        this._stConSt = System.Configuration.ConfigurationManager.AppSettings["dBconnection"];
    //    }
    //    #endregion

    //    #region insertKerangan
    //    public String insertKerangan(string _byCompa, int _stSysc1, byte _stSysc2, string _stDates, string _stUsrid)
    //    {
    //        string vstExcep;
    //        System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
    //        System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
    //        System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
    //        System.Data.DataSet vdsDatas = new System.Data.DataSet();
    //        try
    //        {
    //            vobCommd.CommandText = "[pgn].[p_NUMBG]";
    //            vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
    //            vobCommd.CommandTimeout = 600;
    //            vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_compa", System.Data.SqlDbType.VarChar)).Value = _byCompa;
    //            vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_clas1", System.Data.SqlDbType.TinyInt)).Value = _stSysc1;
    //            vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_clas2", System.Data.SqlDbType.TinyInt)).Value = _stSysc2;
    //            vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_dates", System.Data.SqlDbType.VarChar)).Value = _stDates;
    //            vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_UsrID", System.Data.SqlDbType.VarChar)).Value = _stUsrid;

    //            SqlParameter vobParam = new System.Data.SqlClient.SqlParameter("@ot_nomor", System.Data.SqlDbType.VarChar, 20);
    //            //SqlParameter vobParam = new System.Data.SqlClient.SqlParameter("@ot_group", System.Data.SqlDbType.VarChar, 20);
    //            vobParam.Direction = System.Data.ParameterDirection.Output;
    //            vobCommd.Parameters.Add(vobParam);



    //            try
    //            {
    //                if (vobConne.State == System.Data.ConnectionState.Closed)
    //                {
    //                    vobConne.Open();

    //                }
    //                vobCommd.Connection = vobConne;
    //                vobCommd.ExecuteNonQuery();
    //                _stNumbr = vobParam.Value.ToString();

    //            }
    //            catch (System.Data.SqlClient.SqlException vsqExcep)
    //            { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
    //        }
    //        catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
    //        finally
    //        {
    //            if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
    //            vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
    //        }


    //        return _stNumbr;
    //    }

    //    #endregion

    //}
    public class UploadFile
    {
        private string _stConSt;
        public bool stSave = false;

        #region Constructor
        public void Datas()
        {
            this._stConSt = System.Configuration.ConfigurationManager.AppSettings["dBconnection"];

        }
        #endregion

        #region List Upload
        public DataSet getListFileTemp(String id)
        {
            string vstExcep;
            SqlConnection vobConne = new SqlConnection(this._stConSt);
            SqlCommand vobCommd = new SqlCommand();
            SqlDataAdapter vobAdapt = new SqlDataAdapter(vobCommd);
            DataSet vdsDatas = new DataSet();
            try
            {
                vobCommd.CommandText = @" 
                    SELECT [OBJECTID]
                          ,[CreationUser]
                          ,[DateCreated]
                          ,[DateModified]
                          ,[LastUser]
                          ,[TglInput]
                          ,[SourceLayerTabel]
                          ,[JenisDocument]
                          ,[URL]
                          ,[IDSource]
                          ,[IDHLink]
                          ,[Seqnc]
                          ,[FileLama]
                    FROM [pgn].[HYLINKDOCUMENT_TEMP]
                    WHERE [IDHLink]='" + id + @"'
                    ";
                vobCommd.CommandType = CommandType.Text;
                vobCommd.CommandTimeout = 600;
                if (vobConne.State == ConnectionState.Closed)
                    vobConne.Open();
                vobCommd.Connection = vobConne;
                vobAdapt.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                vobAdapt.Fill(vdsDatas, "HYLINKDOCUMENT_TEMP");
            }
            catch (SqlException ex)
            {
                vstExcep = ex.Message; vobConne.Close(); vdsDatas = null;
            }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        #endregion

        #region Hapus Upload
        public bool HapusListUploadTemp(String id)
        {
            string vstExcep = "";
            SqlConnection vobConne = new SqlConnection(this._stConSt);
            SqlCommand vobCommd = new SqlCommand();
            SqlDataAdapter vobAdapt = new SqlDataAdapter(vobCommd);
            try
            {
                vobCommd.CommandText = @"DELETE FROM pgn.HYLINKDOCUMENT_TEMP WHERE[IDHLink]='" + id + @"' ";
                vobCommd.CommandTimeout = 600;
                vobCommd.CommandType = CommandType.Text;
                if (vobConne.State == ConnectionState.Closed)
                    vobConne.Open();
                vobCommd.Connection = vobConne;
                vobCommd.ExecuteNonQuery();
                stSave = true;
            }
            catch (SqlException ex)
            {
                vstExcep = ex.Message; stSave = false;
            }
            finally
            {
                if (vobConne.State == ConnectionState.Open)
                    vobConne.Close();
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return stSave;
        }
        public bool HapusFileUploadTemp(String id)
        {
            string vstExcep;
            DataSet vdsDatas = new DataSet();
            try
            {
                vdsDatas = this.getListFileTemp(id);
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "uploadDocument";
                string source = "";
                DataTable dt = vdsDatas.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    source = "" + dt.Rows[i]["IDSource"].ToString();
                    System.IO.File.Delete(path + "\\Temp\\" + source);
                }
                stSave = true;
            }
            catch (Exception ex)
            {
                vstExcep = ex.Message; vdsDatas = null;
                stSave = false;
            }
            finally
            {
                vdsDatas.Dispose();
            }
            return stSave;
        }
        #endregion

        #region Upload
        //public bool SaveMapCC(String _stparam, string _stCclid, byte _stSubGr, string _stUsReq, byte _stCases, string _stRemrk, byte _stDelet,byte _stseqnc, string _stdetlJ, string _stzoReq, byte _stMTyId, string _stMapID)
        public bool UploadFiles(string param,
                                string CreationUser,
                                string DateCreated,
                                string DateModified,
                                string LastUser,
                                string TglInput,
                                string SourceLayerTabel,
                                string JenisDocument,
                                string URL,
                                string IDSource,
                                string IDHLink,
                                string FileLama)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = "[pgn].[p_HyperLinkDocu]";
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@param", System.Data.SqlDbType.VarChar)).Value = param;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreationUser", System.Data.SqlDbType.VarChar)).Value = CreationUser;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateCreated", System.Data.SqlDbType.VarChar)).Value = DateCreated;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateModified", System.Data.SqlDbType.VarChar)).Value = DateModified;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastUser", System.Data.SqlDbType.VarChar)).Value = LastUser;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TglInput", System.Data.SqlDbType.VarChar)).Value = TglInput;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SourceLayerTabel", System.Data.SqlDbType.VarChar)).Value = SourceLayerTabel;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JenisDocument", System.Data.SqlDbType.VarChar)).Value = JenisDocument;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@URL", System.Data.SqlDbType.VarChar)).Value = URL;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDSource", System.Data.SqlDbType.VarChar)).Value = IDSource;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDHLink", System.Data.SqlDbType.VarChar)).Value = IDHLink;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileLama", System.Data.SqlDbType.VarChar)).Value = FileLama;
                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed)
                    {
                        vobConne.Open();

                    }
                    vobCommd.Connection = vobConne;
                    vobCommd.ExecuteNonQuery();
                    stSave = true;

                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }


            return stSave;
        }

        public bool UploadFilesTemp(string param,
                                string CreationUser,
                                string DateCreated,
                                string DateModified,
                                string LastUser,
                                string TglInput,
                                string SourceLayerTabel,
                                string JenisDocument,
                                string URL,
                                string IDSource,
                                string IDHLink,
                                string FileLama)
        {
            string vstExcep = "";
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = "[pgn].[p_HyperLinkDocu_Temp]";
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@param", System.Data.SqlDbType.VarChar)).Value = param;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreationUser", System.Data.SqlDbType.VarChar)).Value = CreationUser;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateCreated", System.Data.SqlDbType.VarChar)).Value = DateCreated;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateModified", System.Data.SqlDbType.VarChar)).Value = DateModified;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastUser", System.Data.SqlDbType.VarChar)).Value = LastUser;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TglInput", System.Data.SqlDbType.VarChar)).Value = TglInput;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SourceLayerTabel", System.Data.SqlDbType.VarChar)).Value = SourceLayerTabel;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JenisDocument", System.Data.SqlDbType.VarChar)).Value = JenisDocument;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@URL", System.Data.SqlDbType.VarChar)).Value = URL;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDSource", System.Data.SqlDbType.VarChar)).Value = IDSource;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IDHLink", System.Data.SqlDbType.VarChar)).Value = IDHLink;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileLama", System.Data.SqlDbType.VarChar)).Value = FileLama;
                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed)
                    {
                        vobConne.Open();

                    }
                    vobCommd.Connection = vobConne;
                    vobCommd.ExecuteNonQuery();
                    stSave = true;

                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }

            return stSave;
        }
        #endregion
    }
    public class ExecuteSTP
    {
        private string _stConSt;
        public bool stSave = false;

        #region Constructor
        public void Datas()
        {
            this._stConSt = System.Configuration.ConfigurationManager.AppSettings["dBconnection"];

        }
        #endregion

        #region ListInspeksi
        public System.Data.DataSet ListInspeksi(string _stProcs, string _stParam1, string _stParam2, string _stParam3)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param3", System.Data.SqlDbType.VarChar)).Value = _stParam3;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListInspeksi");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }


        public System.Data.DataSet ListPipaRencana(string _stProcs, string _stParam1)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListPipaRencana");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        public System.Data.DataSet ListProgres(string _stProcs, string _stParam1, string _stParam2)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListProgres");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        public System.Data.DataSet ListProgres1(string _stProcs, string _stParam1, string _stParam2)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListProgres1");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        #endregion

        #region ListReport
        public System.Data.DataSet ListReports(string _stProcs, string _stParam1, string _stParam2, string _stParam3)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param3", System.Data.SqlDbType.VarChar)).Value = _stParam3;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListReport");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        #endregion

        #region ListReportpelanggan
        public System.Data.DataSet ListReportspelanggan(string _stProcs, string _stParam1, string _stParam2, string _stParam3, string _stParam4)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param3", System.Data.SqlDbType.VarChar)).Value = _stParam3;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param4", System.Data.SqlDbType.VarChar)).Value = _stParam4;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "ListReport");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        #endregion


        #region GetIdInspeksi
        public System.Data.DataSet GetIdInspeksi(string _stProcs, string _stParam1, string _stParam2)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = _stProcs;
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param1", System.Data.SqlDbType.VarChar)).Value = _stParam1;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@in_param2", System.Data.SqlDbType.VarChar)).Value = _stParam2;

                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed) { vobConne.Open(); }
                    vobCommd.Connection = vobConne;
                    vobAdapt.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
                    vobAdapt.Fill(vdsDatas, "GetIdInspeksi");
                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }
            return vdsDatas;
        }
        #endregion

        #region Upload
        public bool saveRencana(string param,
                                string users,
                                string proje,
                                float prenc,
                                string dates,
                                float pasng,
                                float persn,
                                string idpro)
        {
            string vstExcep;
            System.Data.SqlClient.SqlConnection vobConne = new System.Data.SqlClient.SqlConnection(this._stConSt);
            System.Data.SqlClient.SqlCommand vobCommd = new System.Data.SqlClient.SqlCommand();
            System.Data.SqlClient.SqlDataAdapter vobAdapt = new System.Data.SqlClient.SqlDataAdapter(vobCommd);
            System.Data.DataSet vdsDatas = new System.Data.DataSet();
            try
            {
                vobCommd.CommandText = "pgn.p_progresRencana";
                vobCommd.CommandType = System.Data.CommandType.StoredProcedure;
                vobCommd.CommandTimeout = 600;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@param", System.Data.SqlDbType.VarChar)).Value = param;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@users", System.Data.SqlDbType.VarChar)).Value = users;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@proje", System.Data.SqlDbType.VarChar)).Value = proje;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@prenc", System.Data.SqlDbType.Money)).Value = prenc;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dates", System.Data.SqlDbType.SmallDateTime)).Value = dates;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pasng", System.Data.SqlDbType.Money)).Value = pasng;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@persn", System.Data.SqlDbType.Money)).Value = persn;
                vobCommd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@idpro", System.Data.SqlDbType.VarChar)).Value = idpro;
                try
                {
                    if (vobConne.State == System.Data.ConnectionState.Closed)
                    {
                        vobConne.Open();

                    }
                    vobCommd.Connection = vobConne;
                    vobCommd.ExecuteNonQuery();
                    stSave = true;

                }
                catch (System.Data.SqlClient.SqlException vsqExcep)
                { vstExcep = vsqExcep.Message; vobConne.Close(); vdsDatas = null; }
            }
            catch (System.Data.SqlClient.SqlException vsqExcep) { vstExcep = vsqExcep.Message; vdsDatas = null; }
            finally
            {
                if (vobConne.State == System.Data.ConnectionState.Open) { vobConne.Close(); };
                vobAdapt.Dispose(); vobCommd.Dispose(); vobConne.Dispose();
            }


            return stSave;
        }

        #endregion

    }

    public class nCrypt_dCrypt
    {
        public nCrypt_dCrypt()
        { }

        private string _Param = "";
        public string Namas { get { return this._Param; } set { this._Param = value; } }

        public string nCrypt(string _Param)
        {
            short _shLoops = Convert.ToInt16(_Param.Length);
            short i = 0;
            string _stStrng = "";
            //WILMAR.GIS.nCrypt_dCrypt encrypt = new WILMAR.GIS.nCrypt_dCrypt();

            string _stTemps = ""; //menampung semua charakter


            for (i = 0; i < _shLoops; i++)
            {
                _stStrng = _Param.Substring(i, 1); //mengambil nilai character per huruf
                nHuruf(_stStrng);
                _stTemps += Namas;
            }

            return _stTemps;
        }

        public string dCrypt(string _Param)
        {
            short _shLoops = Convert.ToInt16(_Param.Length);
            int i = 0;
            string _stStrng = "";
            //WILMAR.GIS.nCrypt_dCrypt encrypt = new WILMAR.GIS.nCrypt_dCrypt();

            string _stTemps = ""; //menampung semua charakter


            for (i = 0; i < _shLoops; i++)
            {
                _stStrng = _Param.Substring(i, 2); //mengambil nilai character per huruf
                dHuruf(_stStrng);
                _stTemps += Namas;
                i = i + 1;
            }

            return _stTemps;
        }

        public string nHuruf(string _Chars)
        {

            Namas = _Chars;
            Namas = Namas.Replace("1", "!-");
            Namas = Namas.Replace("2", "-@");
            Namas = Namas.Replace("3", "()");
            Namas = Namas.Replace("4", "*<");
            Namas = Namas.Replace("5", ">^");
            Namas = Namas.Replace("6", "$!");
            Namas = Namas.Replace("7", "}~");
            Namas = Namas.Replace("8", "@|");
            Namas = Namas.Replace("9", "*^");
            Namas = Namas.Replace("0", "@)");
            Namas = Namas.Replace("/", "(*");
            Namas = Namas.Replace("=", "^(");
            Namas = Namas.Replace(":", "(-");
            Namas = Namas.Replace("_", "<>");
            Namas = Namas.Replace(".", "><");

            Namas = Namas.Replace("a", "23");
            Namas = Namas.Replace("b", "45");
            Namas = Namas.Replace("c", "56");
            Namas = Namas.Replace("d", "87");
            Namas = Namas.Replace("e", "25");
            Namas = Namas.Replace("f", "44");
            Namas = Namas.Replace("g", "96");
            Namas = Namas.Replace("h", "55");
            Namas = Namas.Replace("i", "34");
            Namas = Namas.Replace("j", "63");
            Namas = Namas.Replace("k", "73");
            Namas = Namas.Replace("l", "74");
            Namas = Namas.Replace("m", "51");
            Namas = Namas.Replace("n", "24");
            Namas = Namas.Replace("o", "68");
            Namas = Namas.Replace("p", "98");
            Namas = Namas.Replace("q", "42");
            Namas = Namas.Replace("r", "46");
            Namas = Namas.Replace("s", "88");
            Namas = Namas.Replace("t", "78");
            Namas = Namas.Replace("u", "52");
            Namas = Namas.Replace("v", "16");
            Namas = Namas.Replace("w", "14");
            Namas = Namas.Replace("x", "36");
            Namas = Namas.Replace("y", "77");
            Namas = Namas.Replace("z", "40");
            Namas = Namas.Replace("A", "23");
            Namas = Namas.Replace("B", "45");
            Namas = Namas.Replace("C", "56");
            Namas = Namas.Replace("D", "87");
            Namas = Namas.Replace("E", "25");
            Namas = Namas.Replace("F", "44");
            Namas = Namas.Replace("G", "96");
            Namas = Namas.Replace("H", "55");
            Namas = Namas.Replace("I", "34");
            Namas = Namas.Replace("J", "63");
            Namas = Namas.Replace("K", "73");
            Namas = Namas.Replace("L", "74");
            Namas = Namas.Replace("M", "51");
            Namas = Namas.Replace("N", "24");
            Namas = Namas.Replace("O", "68");
            Namas = Namas.Replace("P", "98");
            Namas = Namas.Replace("Q", "42");
            Namas = Namas.Replace("R", "46");
            Namas = Namas.Replace("S", "88");
            Namas = Namas.Replace("T", "78");
            Namas = Namas.Replace("U", "52");
            Namas = Namas.Replace("V", "16");
            Namas = Namas.Replace("W", "14");
            Namas = Namas.Replace("X", "36");
            Namas = Namas.Replace("Y", "77");
            Namas = Namas.Replace("Z", "40");

            //angka

            return Namas;
        }

        public string dHuruf(string _Chars)
        {

            Namas = _Chars;
            Namas = Namas.Replace("!-", "1");
            Namas = Namas.Replace("-@", "2");
            Namas = Namas.Replace("()", "3");
            Namas = Namas.Replace("*<", "4");
            Namas = Namas.Replace(">^", "5");
            Namas = Namas.Replace("$!", "6");
            Namas = Namas.Replace("}~", "7");
            Namas = Namas.Replace("@|", "8");
            Namas = Namas.Replace("*^", "9");
            Namas = Namas.Replace("@)", "0");
            Namas = Namas.Replace("(*", "/");
            Namas = Namas.Replace("^(", "=");
            Namas = Namas.Replace("(-", ":");
            Namas = Namas.Replace("<>", "_");
            Namas = Namas.Replace("><", ".");

            Namas = Namas.Replace("23", "a");
            Namas = Namas.Replace("45", "b");
            Namas = Namas.Replace("56", "c");
            Namas = Namas.Replace("87", "d");
            Namas = Namas.Replace("25", "e");
            Namas = Namas.Replace("44", "f");
            Namas = Namas.Replace("96", "g");
            Namas = Namas.Replace("55", "h");
            Namas = Namas.Replace("34", "i");
            Namas = Namas.Replace("63", "j");
            Namas = Namas.Replace("73", "k");
            Namas = Namas.Replace("74", "l");
            Namas = Namas.Replace("51", "m");
            Namas = Namas.Replace("24", "n");
            Namas = Namas.Replace("68", "o");
            Namas = Namas.Replace("98", "p");
            Namas = Namas.Replace("42", "q");
            Namas = Namas.Replace("46", "r");
            Namas = Namas.Replace("88", "s");
            Namas = Namas.Replace("78", "t");
            Namas = Namas.Replace("52", "u");
            Namas = Namas.Replace("16", "v");
            Namas = Namas.Replace("14", "w");
            Namas = Namas.Replace("36", "x");
            Namas = Namas.Replace("77", "y");
            Namas = Namas.Replace("40", "z");
            Namas = Namas.Replace("23", "A");
            Namas = Namas.Replace("45", "B");
            Namas = Namas.Replace("56", "C");
            Namas = Namas.Replace("87", "D");
            Namas = Namas.Replace("25", "E");
            Namas = Namas.Replace("44", "F");
            Namas = Namas.Replace("96", "G");
            Namas = Namas.Replace("55", "H");
            Namas = Namas.Replace("34", "I");
            Namas = Namas.Replace("63", "J");
            Namas = Namas.Replace("73", "K");
            Namas = Namas.Replace("74", "L");
            Namas = Namas.Replace("51", "M");
            Namas = Namas.Replace("24", "N");
            Namas = Namas.Replace("68", "O");
            Namas = Namas.Replace("98", "P");
            Namas = Namas.Replace("42", "Q");
            Namas = Namas.Replace("46", "R");
            Namas = Namas.Replace("88", "S");
            Namas = Namas.Replace("78", "T");
            Namas = Namas.Replace("52", "U");
            Namas = Namas.Replace("16", "V");
            Namas = Namas.Replace("14", "W");
            Namas = Namas.Replace("36", "X");
            Namas = Namas.Replace("77", "Y");
            Namas = Namas.Replace("40", "Z");

            return Namas;
        }



    }


}