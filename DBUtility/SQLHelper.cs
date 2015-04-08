//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//===============================================================================

using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBUtility
{

    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.    
    /// 这个类是静态的，应用程序启动时，自动驻留在内存中，所建连接，在使用过程中，
    /// 也只是Close()，放回到连接池中。并没有注销Dispose()，可以下次连接时，快速使用。
    /// </summary>
    public abstract class SQLHelper
    {

        //数据库连接字符串
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        #region
        //public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString;
        //public static readonly string ConnectionStringInventoryDistributedTransaction = ConfigurationManager.ConnectionStrings["SQLConnString2"].ConnectionString;
        //public static readonly string ConnectionStringOrderDistributedTransaction = ConfigurationManager.ConnectionStrings["SQLConnString3"].ConnectionString;
        //public static readonly string ConnectionStringProfile = ConfigurationManager.ConnectionStrings["SQLProfileConnString"].ConnectionString;
        #endregion

        //用哈希表存储缓存参数
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());


        #region 使用新数据库连接，执行一个SQL命令，返回受影响行数
        /// <summary>
        /// 使用新数据库连接，执行一个SQL命令，返回受影响行数
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 使用现有数据库连接对象，执行一个SQL命令，返回受影响行数
        /// <summary>
        /// 使用现有数据库连接对象，执行一个SQL命令，返回受影响行数
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region 使用现有SQL事务执行一个SQL命令，返回受影响行数
        /// <summary>
        /// 使用现有SQL事务执行一个SQL命令，返回受影响行数
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">SQL事务</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region 使用新数据库连接，执行一个SQL命令返回一个结果集
        /// <summary>
        /// 使用新数据库连接，执行一个SQL命令返回一个结果集
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回包含结果的SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                //如果创建了 SqlDataReader 并将 CommandBehavior 设置为 CloseConnection，
                //则关闭 SqlDataReader 会自动关闭此连接
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region 使用新数据库连接，执行一个SQL命令返回结果第一行第一列
        /// <summary>
        /// 使用新数据库连接，执行一个SQL命令返回结果第一行第一列
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回一个对象（可用Convert.To{Type}转换类型）</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region 使用现有数据库连接对象，执行一个SQL命令返回结果第一行第一列
        /// <summary>
        /// 使用现有数据库连接对象，执行一个SQL命令返回结果第一行第一列
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">现有的SqlConnection对象</param>
        /// <param name="commandType">SQL命令类型 (存储过程或文本等)</param>
        /// <param name="commandText">命令文本（存储过程名或SQL语句）</param>
        /// <param name="commandParameters">命令参数数组（允许null）</param>
        /// <returns>返回一个对象（可用Convert.To{Type}转换类型）</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region 增加SqlParameter数组到缓存
        /// <summary>
        /// 增加SqlParameter数组到缓存
        /// </summary>
        /// <param name="cacheKey">缓存项名</param>
        /// <param name="cmdParms">要缓存SqlParamters数组</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        #endregion

        #region 检索缓存的SqlParamters
        /// <summary>
        /// 检索缓存的SqlParamters
        /// </summary>
        /// <param name="cacheKey">根据缓存项名查找SqlParameter</param>
        /// <returns>被缓存的SqlParamters数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }
        #endregion

        #region 设置SQL命令属性并打开数据库连接
        /// <summary>
        /// 设置SQL命令属性并打开数据库连接
        /// </summary>
        /// <param name="cmd">命令对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象（可null）</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdParms">命令参数（可null）</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    ////检查未分配值的输出参数,将其分配以DBNull.Value.
                    //if ((parm.Direction == ParameterDirection.InputOutput || parm.Direction == ParameterDirection.Input) &&
                    //    (parm.Value == null))
                    //{
                    //    parm.Value = DBNull.Value;
                    //}
                    cmd.Parameters.Add(parm);
                }

            }
        }
        #endregion
    }
}