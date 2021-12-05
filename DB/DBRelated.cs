using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public static class DBRelated
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private static string ConnectLine = "192.168.XX.X;XXXXXXXXXX";

        /// <summary>
        /// 取得資料庫資料
        /// </summary>
        /// <param name="SQLCommand">sql指令</param>
        /// <param name="connectString">連線字串</param>
        /// <param name="timeoutTime">超時時間</param>
        /// <returns>資料庫資料</returns>
        public static DataTable DoSQLQuery(string SQLCommand, string connectString, int timeoutTime = 15)
        {
            DataTable result = null;
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                result = DoSQLQuery(SQLCommand, sqlConnection, timeoutTime);
                sqlConnection.Close();
            }
            return result;
        }

        /// <summary>
        ///取得資料庫資料
        /// </summary>
        /// <param name="SQLCommand"></param>
        /// <param name="connectString"></param>
        /// <param name="timeoutTime"></param>
        /// <returns>資料庫資料</returns>
        public static DataTable DoSQLQuery(string SQLCommand, SqlConnection connectString, int timeoutTime = 15)
        {
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQLCommand, connectString))
            {
                try
                {
                    sqlDataAdapter.SelectCommand.CommandTimeout = timeoutTime;
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dataTable;
        }

        /// <summary>
        /// 取得連線字串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectString()
        {
            return ConnectLine;
        }
    }
}