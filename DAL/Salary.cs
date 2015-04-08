using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
namespace LCSS.DAL
{
	/// <summary>
	/// 数据访问类:Salary
	/// </summary>
	public partial class Salary
	{
		public Salary()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Sal_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Salary");
			strSql.Append(" where Sal_ID=@Sal_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Sal_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Sal_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.Salary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Salary(");
			strSql.Append("Sal_Year,Sal_Month,Sal_Add_User,Sal_Add_Time)");
			strSql.Append(" values (");
			strSql.Append("@Sal_Year,@Sal_Month,@Sal_Add_User,@Sal_Add_Time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Sal_Year", SqlDbType.Int,4),
					new SqlParameter("@Sal_Month", SqlDbType.Int,4),
					new SqlParameter("@Sal_Add_User", SqlDbType.VarChar,20),
					new SqlParameter("@Sal_Add_Time", SqlDbType.DateTime)};
			parameters[0].Value = model.Sal_Year;
			parameters[1].Value = model.Sal_Month;
			parameters[2].Value = model.Sal_Add_User;
			parameters[3].Value = model.Sal_Add_Time;

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
		public bool Update(LCSS.Model.Salary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Salary set ");
			strSql.Append("Sal_Year=@Sal_Year,");
			strSql.Append("Sal_Month=@Sal_Month,");
			strSql.Append("Sal_Add_User=@Sal_Add_User,");
			strSql.Append("Sal_Add_Time=@Sal_Add_Time");
			strSql.Append(" where Sal_ID=@Sal_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Sal_Year", SqlDbType.Int,4),
					new SqlParameter("@Sal_Month", SqlDbType.Int,4),
					new SqlParameter("@Sal_Add_User", SqlDbType.VarChar,20),
					new SqlParameter("@Sal_Add_Time", SqlDbType.DateTime),
					new SqlParameter("@Sal_ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Sal_Year;
			parameters[1].Value = model.Sal_Month;
			parameters[2].Value = model.Sal_Add_User;
			parameters[3].Value = model.Sal_Add_Time;
			parameters[4].Value = model.Sal_ID;

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
		public bool Delete(long Sal_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Salary ");
			strSql.Append(" where Sal_ID=@Sal_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Sal_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Sal_ID;

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
		public bool DeleteList(string Sal_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Salary ");
			strSql.Append(" where Sal_ID in ("+Sal_IDlist + ")  ");
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
		public LCSS.Model.Salary GetModel(long Sal_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Sal_ID,Sal_Year,Sal_Month,Sal_Add_User,Sal_Add_Time from Salary ");
			strSql.Append(" where Sal_ID=@Sal_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Sal_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Sal_ID;

			LCSS.Model.Salary model=new LCSS.Model.Salary();
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
		public LCSS.Model.Salary DataRowToModel(DataRow row)
		{
			LCSS.Model.Salary model=new LCSS.Model.Salary();
			if (row != null)
			{
				if(row["Sal_ID"]!=null && row["Sal_ID"].ToString()!="")
				{
					model.Sal_ID=long.Parse(row["Sal_ID"].ToString());
				}
				if(row["Sal_Year"]!=null && row["Sal_Year"].ToString()!="")
				{
					model.Sal_Year=int.Parse(row["Sal_Year"].ToString());
				}
				if(row["Sal_Month"]!=null && row["Sal_Month"].ToString()!="")
				{
					model.Sal_Month=int.Parse(row["Sal_Month"].ToString());
				}
				if(row["Sal_Add_User"]!=null)
				{
					model.Sal_Add_User=row["Sal_Add_User"].ToString();
				}
				if(row["Sal_Add_Time"]!=null && row["Sal_Add_Time"].ToString()!="")
				{
					model.Sal_Add_Time=DateTime.Parse(row["Sal_Add_Time"].ToString());
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
			strSql.Append("select Sal_ID,Sal_Year,Sal_Month,Sal_Add_User,Sal_Add_Time ");
			strSql.Append(" FROM Salary ");
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
			strSql.Append(" Sal_ID,Sal_Year,Sal_Month,Sal_Add_User,Sal_Add_Time ");
			strSql.Append(" FROM Salary ");
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
			strSql.Append("select count(1) FROM Salary ");
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
				strSql.Append("order by T.Sal_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Salary T ");
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
			parameters[0].Value = "Salary";
			parameters[1].Value = "Sal_ID";
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

