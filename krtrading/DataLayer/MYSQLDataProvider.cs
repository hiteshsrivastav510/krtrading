using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace krtrading.DataLayer
{

    public class MYSQLDataProvider : IDisposable
    {
        private SqlConnection _connection;
        private readonly long? UserID = null;

        public MYSQLDataProvider()
        {
            //this._connection = new SqlConnection(ConfigurationManager.ConnectionStrings["krtradingconn"].ToString());
            this._connection = new SqlConnection(ConnectionProvider.ModelConnection);
        }
        private void OpenConnection()
        {
            if (this._connection.State.Equals(ConnectionState.Closed))
                this._connection.Open();
        }
        private void CloseConnection()
        {
            if (this._connection.State.Equals(ConnectionState.Open))
                this._connection.Close();
        }

        public enum ReturnType
        {
            DataSet,
            DataTable,
            Integer,
            OutputIntValue
        }

        public object CallProcedureWithoutParm(string procedure, ReturnType Value, string outparam = "")
        {
            if (Value.Equals(ReturnType.Integer))
            {
                int rows = ExecuteProcedure(procedure);
                return rows;
            }
            else if (Value.Equals(ReturnType.DataTable))
            {
                DataTable dt = GetDataTableWithQuery(procedure);
                return dt;
            }
            else if (Value.Equals(ReturnType.OutputIntValue))
            {
                string outValue = ExecuteProcedureWithOpValueWitoutParam(procedure, outparam);
                return outValue;
            }
            else
            {
                DataSet ds = GetDataSetWithQuery(procedure);
                return ds;

            }
        }
        public object CallProcedureWithArrayParm(string procedure, SqlParameter[] sqlParameters, ReturnType Value, string outparam = "")
        {
            if (Value.Equals(ReturnType.Integer))
            {
                int rows = ExecuteNonProcedure(procedure, sqlParameters);
                return rows;
            }
            else if (Value.Equals(ReturnType.DataTable))
            {
                DataTable dt = ExecProcedureWithDataTable(procedure, sqlParameters);
                return dt;
            }
            else if (Value.Equals(ReturnType.OutputIntValue))
            {
                string outValue = ExecuteProcedureWithOpValueArrayParam(procedure, sqlParameters, outparam);
                return outValue;
            }
            else
            {
                DataSet ds = ExecProcedureWithDataSetArrayParam(procedure, sqlParameters);
                return ds;

            }
        }
        public object CallProcedureWithListParm(string procedure, Collection<SqlParameter> sqlParameters, ReturnType Value, string outparam = "")
        {
            if (Value.Equals(ReturnType.Integer))
            {
                int rows = ExecuteProcedure(procedure, sqlParameters);
                return rows;
            }
            else if (Value.Equals(ReturnType.DataTable))
            {
                DataTable dt = ExecProcdeureNonQuery(procedure, sqlParameters);
                return dt;
            }
            else if (Value.Equals(ReturnType.OutputIntValue))
            {
                string outValue = ExecuteProcedureWithOpValue(procedure, sqlParameters, outparam);
                return outValue;
            }
            else
            {
                DataSet ds = ExecProcedureWithDataSet(procedure, sqlParameters);
                return ds;

            }
        }
        public int ExecuteProcedure(string procedure)
        {
            return this.ExecuteProcedure(procedure, null);
        }
        public int ExecuteProcedure(string procedure, Collection<SqlParameter> param)
        {
            int RowAfftected = 0;
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter parm in param)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                RowAfftected = cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            return RowAfftected;
        }
        public string ExecuteProcedureWithOpValueWitoutParam(string procedure, string opParam)
        {
            int RowAffected = 0;
            string rtn = string.Empty;
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                this.OpenConnection();
                RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    rtn = Convert.ToString(cmd.Parameters[opParam].Value);
                }
                this.CloseConnection();
            }
            return rtn;
        }

        public string ExecuteProcedureWithOpValue(string procedure, Collection<SqlParameter> parameters, string opParam)
        {
            int RowAffected = 0;
            string rtn = string.Empty;
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            if (Convert.ToString(parm) == opParam)
                            {
                                parm.Direction = ParameterDirection.Output;
                            }
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    rtn = Convert.ToString(cmd.Parameters[opParam].Value);
                }
                this.CloseConnection();
            }
            return rtn;
        }
        public string ExecuteProcedureWithOpValueArrayParam(string procedure, SqlParameter[] parameters, string opParam)
        {
            int RowAffected = 0;
            string rtn = string.Empty;
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            if (Convert.ToString(parm) == opParam)
                            {
                                parm.Direction = ParameterDirection.Output;
                            }
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    rtn = Convert.ToString(cmd.Parameters[opParam].Value);
                }
                this.CloseConnection();
            }
            return rtn;
        }

        public DataTable GetDataTableWithQuery(string Query)
        {
            DataTable dtReturnValue = new DataTable();
            using (SqlCommand cmd = new SqlCommand(Query, this._connection))
            {
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dtReturnValue);
            }
            return dtReturnValue;
        }
        public int RunQuery(string Query)
        {
            int rn = 0;
            SqlCommand cmd = new SqlCommand(Query, this._connection);
            this.OpenConnection();
            rn = cmd.ExecuteNonQuery();
            this.CloseConnection();
            return rn;
        }
        public DataSet GetDataSetWithQuery(string Query)
        {
            DataSet dsReturnValue = new DataSet();
            this.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(Query, this._connection))
            {
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dsReturnValue);
            }
            this.CloseConnection();
            return dsReturnValue;
        }
        public DataTable ExecProcdeureNonQuery(string procedure)
        {
            return this.ExecProcdeureNonQuery(procedure, null);
        }
        public DataTable ExecProcdeureNonQuery(string procedure, Collection<SqlParameter> parameters)
        {
            DataTable dtReturn = new DataTable();
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtReturn);
            }
            this.CloseConnection();
            return dtReturn;
        }

        public int ExecuteNonProcedure(string procedure, SqlParameter[] param)
        {
            int RowAfftected = 0;
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                {
                    foreach (SqlParameter parm in param)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                RowAfftected = cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            return RowAfftected;
        }
        public DataSet ExecProcedureWithDataSet(string procedure, Collection<SqlParameter> parameters)
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            this.CloseConnection();
            return ds;
        }

        public DataTable ExecProcedureWithDataTable(string procedure, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            this.CloseConnection();
            return dt;
        }

        public DataSet ExecProcedureWithDataSetArrayParam(string procedure, SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(procedure, this._connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    foreach (SqlParameter parm in parameters)
                    {
                        if (parm != null)
                        {
                            if (parm.Value == null)
                                parm.Value = DBNull.Value;
                            cmd.Parameters.Add(parm);
                        }
                    }
                }
                this.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            this.CloseConnection();
            return ds;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._connection == null)
                {
                    this._connection.Dispose();
                }
            }
        }

    }
}