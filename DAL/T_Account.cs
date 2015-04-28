/**  版本信息模板在安装目录下，可自行修改。
* T_Account.cs
*
* 功 能： N/A
* 类 名： T_Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/23 11:27:28   N/A    初版
*
* Copyright (c) 2012 PC Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PC.DBUtility;//Please add references
namespace LCSS.DAL
{
	/// <summary>
	/// 数据访问类:T_Account
	/// </summary>
	public partial class T_Account
	{
		public T_Account()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ACCT_LoginID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Account");
			strSql.Append(" where ACCT_LoginID=@ACCT_LoginID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_LoginID", SqlDbType.VarChar,20)			};
			parameters[0].Value = ACCT_LoginID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.T_Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Account(");
			strSql.Append("ACCT_LoginID,ACCT_Pwd,ACCT_UserName,ACCT_Deadlock,ACCT_ExpiryDate,ACCT_NoExpiry,ACCT_Disable,ACCT_US_Code,ACCT_Org_Code)");
			strSql.Append(" values (");
			strSql.Append("@ACCT_LoginID,@ACCT_Pwd,@ACCT_UserName,@ACCT_Deadlock,@ACCT_ExpiryDate,@ACCT_NoExpiry,@ACCT_Disable,@ACCT_US_Code,@ACCT_Org_Code)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_LoginID", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ACCT_Deadlock", SqlDbType.Int,4),
					new SqlParameter("@ACCT_ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@ACCT_NoExpiry", SqlDbType.Bit,1),
					new SqlParameter("@ACCT_Disable", SqlDbType.Bit,1),
					new SqlParameter("@ACCT_US_Code", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_Org_Code", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ACCT_LoginID;
			parameters[1].Value = model.ACCT_Pwd;
			parameters[2].Value = model.ACCT_UserName;
			parameters[3].Value = model.ACCT_Deadlock;
			parameters[4].Value = model.ACCT_ExpiryDate;
			parameters[5].Value = model.ACCT_NoExpiry;
			parameters[6].Value = model.ACCT_Disable;
			parameters[7].Value = model.ACCT_US_Code;
			parameters[8].Value = model.ACCT_Org_Code;

			object obj = DbHelperSQL.ReturnValue(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.T_Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Account set ");
			strSql.Append("ACCT_Pwd=@ACCT_Pwd,");
			strSql.Append("ACCT_UserName=@ACCT_UserName,");
			strSql.Append("ACCT_Deadlock=@ACCT_Deadlock,");
			strSql.Append("ACCT_ExpiryDate=@ACCT_ExpiryDate,");
			strSql.Append("ACCT_NoExpiry=@ACCT_NoExpiry,");
			strSql.Append("ACCT_Disable=@ACCT_Disable,");
			strSql.Append("ACCT_US_Code=@ACCT_US_Code,");
			strSql.Append("ACCT_Org_Code=@ACCT_Org_Code");
			strSql.Append(" where ACCT_ID=@ACCT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_Pwd", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@ACCT_Deadlock", SqlDbType.Int,4),
					new SqlParameter("@ACCT_ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@ACCT_NoExpiry", SqlDbType.Bit,1),
					new SqlParameter("@ACCT_Disable", SqlDbType.Bit,1),
					new SqlParameter("@ACCT_US_Code", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_Org_Code", SqlDbType.VarChar,20),
					new SqlParameter("@ACCT_ID", SqlDbType.BigInt,8),
					new SqlParameter("@ACCT_LoginID", SqlDbType.VarChar,20)};
			parameters[0].Value = model.ACCT_Pwd;
			parameters[1].Value = model.ACCT_UserName;
			parameters[2].Value = model.ACCT_Deadlock;
			parameters[3].Value = model.ACCT_ExpiryDate;
			parameters[4].Value = model.ACCT_NoExpiry;
			parameters[5].Value = model.ACCT_Disable;
			parameters[6].Value = model.ACCT_US_Code;
			parameters[7].Value = model.ACCT_Org_Code;
			parameters[8].Value = model.ACCT_ID;
			parameters[9].Value = model.ACCT_LoginID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ACCT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Account ");
			strSql.Append(" where ACCT_ID=@ACCT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ACCT_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ACCT_LoginID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Account ");
			strSql.Append(" where ACCT_LoginID=@ACCT_LoginID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_LoginID", SqlDbType.VarChar,20)			};
			parameters[0].Value = ACCT_LoginID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ACCT_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Account ");
			strSql.Append(" where ACCT_ID in ("+ACCT_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.T_Account GetModel(long ACCT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ACCT_ID,ACCT_LoginID,ACCT_Pwd,ACCT_UserName,ACCT_Deadlock,ACCT_ExpiryDate,ACCT_NoExpiry,ACCT_Disable,ACCT_US_Code,ACCT_Org_Code from T_Account ");
			strSql.Append(" where ACCT_ID=@ACCT_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ACCT_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ACCT_ID;

			LCSS.Model.T_Account model=new LCSS.Model.T_Account();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCSS.Model.T_Account GetLoginInfo(string ACCT_LoginID, string ACCT_Pwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ACCT_ID,ACCT_LoginID,ACCT_Pwd,ACCT_UserName,ACCT_Deadlock,ACCT_ExpiryDate,ACCT_NoExpiry,ACCT_Disable,ACCT_US_Code,ACCT_Org_Code from T_Account ");
            strSql.Append(" where ACCT_LoginID=@ACCT_LoginID and ACCT_Pwd=@ACCT_Pwd");
            SqlParameter[] parameters = {
					new SqlParameter("@ACCT_LoginID", SqlDbType.VarChar,20),
                    new SqlParameter("@ACCT_Pwd", SqlDbType.VarChar,20)
			};
            parameters[0].Value = ACCT_LoginID;
            parameters[1].Value = ACCT_Pwd;

            LCSS.Model.T_Account model = new LCSS.Model.T_Account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.T_Account DataRowToModel(DataRow row)
		{
			LCSS.Model.T_Account model=new LCSS.Model.T_Account();
			if (row != null)
			{
				if(row["ACCT_ID"]!=null && row["ACCT_ID"].ToString()!="")
				{
					model.ACCT_ID=long.Parse(row["ACCT_ID"].ToString());
				}
				if(row["ACCT_LoginID"]!=null)
				{
					model.ACCT_LoginID=row["ACCT_LoginID"].ToString();
				}
				if(row["ACCT_Pwd"]!=null)
				{
					model.ACCT_Pwd=row["ACCT_Pwd"].ToString();
				}
				if(row["ACCT_UserName"]!=null)
				{
					model.ACCT_UserName=row["ACCT_UserName"].ToString();
				}
				if(row["ACCT_Deadlock"]!=null && row["ACCT_Deadlock"].ToString()!="")
				{
					model.ACCT_Deadlock=int.Parse(row["ACCT_Deadlock"].ToString());
				}
				if(row["ACCT_ExpiryDate"]!=null && row["ACCT_ExpiryDate"].ToString()!="")
				{
					model.ACCT_ExpiryDate=DateTime.Parse(row["ACCT_ExpiryDate"].ToString());
				}
				if(row["ACCT_NoExpiry"]!=null && row["ACCT_NoExpiry"].ToString()!="")
				{
					if((row["ACCT_NoExpiry"].ToString()=="1")||(row["ACCT_NoExpiry"].ToString().ToLower()=="true"))
					{
						model.ACCT_NoExpiry=true;
					}
					else
					{
						model.ACCT_NoExpiry=false;
					}
				}
				if(row["ACCT_Disable"]!=null && row["ACCT_Disable"].ToString()!="")
				{
					if((row["ACCT_Disable"].ToString()=="1")||(row["ACCT_Disable"].ToString().ToLower()=="true"))
					{
						model.ACCT_Disable=true;
					}
					else
					{
						model.ACCT_Disable=false;
					}
				}
				if(row["ACCT_US_Code"]!=null)
				{
					model.ACCT_US_Code=row["ACCT_US_Code"].ToString();
				}
				if(row["ACCT_Org_Code"]!=null)
				{
					model.ACCT_Org_Code=row["ACCT_Org_Code"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ACCT_ID,ACCT_LoginID,ACCT_Pwd,ACCT_UserName,ACCT_Deadlock,ACCT_ExpiryDate,ACCT_NoExpiry,ACCT_Disable,ACCT_US_Code,ACCT_Org_Code ");
			strSql.Append(" FROM T_Account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ACCT_ID,ACCT_LoginID,ACCT_Pwd,ACCT_UserName,ACCT_Deadlock,ACCT_ExpiryDate,ACCT_NoExpiry,ACCT_Disable,ACCT_US_Code,ACCT_Org_Code ");
			strSql.Append(" FROM T_Account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Account ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.ReturnValue(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ACCT_ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Account T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Account";
			parameters[1].Value = "ACCT_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

