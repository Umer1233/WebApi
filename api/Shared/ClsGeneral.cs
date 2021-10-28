using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api.Shared
{
    public static class ClsGeneral
    {
        public static DataSet GetDataSet(string sp, Dictionary<string, object> dict)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 40000;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = sp;

                        foreach (var q in dict.ToList<KeyValuePair<string, object>>())
                        {
                            cmd.Parameters.Add(q.Key, SqlDbType.VarChar, 500).Value = q.Value;
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable GetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 40000;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSQL;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public static int ExecuteEffectedRows(string strSQL)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 40000;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static int ExcuteQuery(SqlConnection con, SqlTransaction transaction, string Query)
        {
            int effectedIDs = 0;
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = Query;
                    effectedIDs = command.ExecuteNonQuery();
                    transaction.Commit();
                    if (!string.IsNullOrEmpty(effectedIDs.ToString()) && Convert.ToInt32(effectedIDs) >= 0)
                    {
                        return Convert.ToInt32(effectedIDs);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
        public static int ExcuteQuery(SqlConnection con, string Query)
        {
            int effectedIDs = 0;
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.Transaction = transaction;
                    command.CommandType = CommandType.Text;
                    command.CommandText = Query;
                    effectedIDs = command.ExecuteNonQuery();
                    if (!string.IsNullOrEmpty(effectedIDs.ToString()) && Convert.ToInt32(effectedIDs) >= 0)
                    {
                        effectedIDs = Convert.ToInt32(effectedIDs);
                    }
                    else
                    {
                        effectedIDs = 0;
                    }
                    transaction.Commit();
                }
                con.Close();
                return effectedIDs;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}