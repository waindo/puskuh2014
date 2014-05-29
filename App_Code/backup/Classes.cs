using System;
using System.Collections.Generic;
using System.Web;

namespace PUSKUH
{
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

    }

    public class Classes
    {
        public Classes()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}