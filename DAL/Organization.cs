using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
namespace LCSS.DAL
{
	/// <summary>
	/// 数据访问类:Organization
	/// </summary>
	public partial class Organization
	{
		public Organization()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Org_Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Organization");
			strSql.Append(" where Org_Code=@Org_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = Org_Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Organization(");
			strSql.Append("Org_Code,Org_Name,Org_Parent_Code,Org_Status,Org_Layer)");
			strSql.Append(" values (");
			strSql.Append("@Org_Code,@Org_Name,@Org_Parent_Code,@Org_Status,@Org_Layer)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Org_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Org_Parent_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Org_Status", SqlDbType.Bit,1),
					new SqlParameter("@Org_Layer", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.Org_Code;
			parameters[1].Value = model.Org_Name;
			parameters[2].Value = model.Org_Parent_Code;
			parameters[3].Value = model.Org_Status;
			parameters[4].Value = model.Org_Layer;

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
		public bool Update(LCSS.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Organization set ");
			strSql.Append("Org_Name=@Org_Name,");
			strSql.Append("Org_Parent_Code=@Org_Parent_Code,");
			strSql.Append("Org_Status=@Org_Status,");
			strSql.Append("Org_Layer=@Org_Layer");
			strSql.Append(" where Org_ID=@Org_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Org_Parent_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Org_Status", SqlDbType.Bit,1),
					new SqlParameter("@Org_Layer", SqlDbType.NVarChar,20),
					new SqlParameter("@Org_ID", SqlDbType.BigInt,8),
					new SqlParameter("@Org_Code", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Org_Name;
			parameters[1].Value = model.Org_Parent_Code;
			parameters[2].Value = model.Org_Status;
			parameters[3].Value = model.Org_Layer;
			parameters[4].Value = model.Org_ID;
			parameters[5].Value = model.Org_Code;

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
		public bool Delete(long Org_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where Org_ID=@Org_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Org_ID;

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
		public bool Delete(string Org_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where Org_Code=@Org_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = Org_Code;

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
		public bool DeleteList(string Org_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where Org_ID in ("+Org_IDlist + ")  ");
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
		public LCSS.Model.Organization GetModel(long Org_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Org_ID,Org_Code,Org_Name,Org_Parent_Code,Org_Status,Org_Layer from Organization ");
			strSql.Append(" where Org_ID=@Org_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Org_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Org_ID;

			LCSS.Model.Organization model=new LCSS.Model.Organization();
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
		public LCSS.Model.Organization DataRowToModel(DataRow row)
		{
			LCSS.Model.Organization model=new LCSS.Model.Organization();
			if (row != null)
			{
				if(row["Org_ID"]!=null && row["Org_ID"].ToString()!="")
				{
					model.Org_ID=long.Parse(row["Org_ID"].ToString());
				}
				if(row["Org_Code"]!=null)
				{
					model.Org_Code=row["Org_Code"].ToString();
				}
				if(row["Org_Name"]!=null)
				{
					model.Org_Name=row["Org_Name"].ToString();
				}
				if(row["Org_Parent_Code"]!=null)
				{
					model.Org_Parent_Code=row["Org_Parent_Code"].ToString();
				}
				if(row["Org_Status"]!=null && row["Org_Status"].ToString()!="")
				{
					if((row["Org_Status"].ToString()=="1")||(row["Org_Status"].ToString().ToLower()=="true"))
					{
						model.Org_Status=true;
					}
					else
					{
						model.Org_Status=false;
					}
				}
				if(row["Org_Layer"]!=null)
				{
					model.Org_Layer=row["Org_Layer"].ToString();
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
			strSql.Append("select Org_ID,Org_Code,Org_Name,Org_Parent_Code,Org_Status,Org_Layer ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append(" Org_ID,Org_Code,Org_Name,Org_Parent_Code,Org_Status,Org_Layer ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append("select count(1) FROM Organization ");
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
				strSql.Append("order by T.Org_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Organization T ");
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
			parameters[0].Value = "Organization";
			parameters[1].Value = "Org_ID";
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

