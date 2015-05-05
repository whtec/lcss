using System;
using System.Data;
using System.Data.SqlClient;
namespace PC.DBUtility
{
    internal interface IDbHelper
    {
        #region 使用唯一默认数据库连接
        //检查数据是否已存在
        bool Exists(string cmdText, SqlParameter[] commandParameters);
        //执行命令返回第一行第一列结果
        object ReturnValue(string cmdText, SqlParameter[] commandParameters);//(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        //执行命令返回受影响行数
        int ExecuteSql(string cmdText, SqlParameter[] commandParameters);//(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        //执行命令返回结果集
        DataSet Query(string cmdText);
        DataSet Query(string cmdText,CommandType cmdType, SqlParameter[] commandParameters);//(CommandType cmdType, string cmdText, params IDataParameter[] commandParameters);
        #endregion
    }
}
