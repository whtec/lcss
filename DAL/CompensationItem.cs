using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PC.DBUtility;
namespace LCSS.DAL
{
	/// <summary>
	/// 数据访问类:CompensationItem
	/// </summary>
	public partial class CompensationItem
	{
		public CompensationItem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CI_Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CompensationItem");
			strSql.Append(" where CI_Code=@CI_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = CI_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.CompensationItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CompensationItem(");
			strSql.Append("CI_Code,CI_Name,CI_Remarks,CI_BuiltIin,CI_Status,CI_Sequence,CI_Org_Code,CI_CT_Code)");
			strSql.Append(" values (");
			strSql.Append("@CI_Code,@CI_Name,@CI_Remarks,@CI_BuiltIin,@CI_Status,@CI_Sequence,@CI_Org_Code,@CI_CT_Code)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_Code", SqlDbType.VarChar,20),
					new SqlParameter("@CI_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@CI_Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@CI_BuiltIin", SqlDbType.Bit,1),
					new SqlParameter("@CI_Status", SqlDbType.Bit,1),
					new SqlParameter("@CI_Sequence", SqlDbType.Int,4),
					new SqlParameter("@CI_Org_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CI_CT_Code", SqlDbType.VarChar,20)};
			parameters[0].Value = model.CI_Code;
			parameters[1].Value = model.CI_Name;
			parameters[2].Value = model.CI_Remarks;
			parameters[3].Value = model.CI_BuiltIin;
			parameters[4].Value = model.CI_Status;
			parameters[5].Value = model.CI_Sequence;
			parameters[6].Value = model.CI_Org_Code;
			parameters[7].Value = model.CI_CT_Code;

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
		public bool Update(LCSS.Model.CompensationItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CompensationItem set ");
			strSql.Append("CI_Name=@CI_Name,");
			strSql.Append("CI_Remarks=@CI_Remarks,");
			strSql.Append("CI_BuiltIin=@CI_BuiltIin,");
			strSql.Append("CI_Status=@CI_Status,");
			strSql.Append("CI_Sequence=@CI_Sequence,");
			strSql.Append("CI_Org_Code=@CI_Org_Code,");
			strSql.Append("CI_CT_Code=@CI_CT_Code");
			strSql.Append(" where CI_ID=@CI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@CI_Remarks", SqlDbType.NVarChar,200),
					new SqlParameter("@CI_BuiltIin", SqlDbType.Bit,1),
					new SqlParameter("@CI_Status", SqlDbType.Bit,1),
					new SqlParameter("@CI_Sequence", SqlDbType.Int,4),
					new SqlParameter("@CI_Org_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CI_CT_Code", SqlDbType.VarChar,20),
					new SqlParameter("@CI_ID", SqlDbType.BigInt,8),
					new SqlParameter("@CI_Code", SqlDbType.VarChar,20)};
			parameters[0].Value = model.CI_Name;
			parameters[1].Value = model.CI_Remarks;
			parameters[2].Value = model.CI_BuiltIin;
			parameters[3].Value = model.CI_Status;
			parameters[4].Value = model.CI_Sequence;
			parameters[5].Value = model.CI_Org_Code;
			parameters[6].Value = model.CI_CT_Code;
			parameters[7].Value = model.CI_ID;
			parameters[8].Value = model.CI_Code;

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
		public bool Delete(long CI_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CompensationItem ");
			strSql.Append(" where CI_ID=@CI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = CI_ID;

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
		public bool Delete(string CI_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CompensationItem ");
			strSql.Append(" where CI_Code=@CI_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = CI_Code;

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
		public bool DeleteList(string CI_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CompensationItem ");
			strSql.Append(" where CI_ID in ("+CI_IDlist + ")  ");
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
		public LCSS.Model.CompensationItem GetModel(long CI_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CI_ID,CI_Code,CI_Name,CI_Remarks,CI_BuiltIin,CI_Status,CI_Sequence,CI_Org_Code,CI_CT_Code from CompensationItem ");
			strSql.Append(" where CI_ID=@CI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CI_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = CI_ID;

			LCSS.Model.CompensationItem model=new LCSS.Model.CompensationItem();
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
		public LCSS.Model.CompensationItem DataRowToModel(DataRow row)
		{
			LCSS.Model.CompensationItem model=new LCSS.Model.CompensationItem();
			if (row != null)
			{
				if(row["CI_ID"]!=null && row["CI_ID"].ToString()!="")
				{
					model.CI_ID=long.Parse(row["CI_ID"].ToString());
				}
				if(row["CI_Code"]!=null)
				{
					model.CI_Code=row["CI_Code"].ToString();
				}
				if(row["CI_Name"]!=null)
				{
					model.CI_Name=row["CI_Name"].ToString();
				}
				if(row["CI_Remarks"]!=null)
				{
					model.CI_Remarks=row["CI_Remarks"].ToString();
				}
				if(row["CI_BuiltIin"]!=null && row["CI_BuiltIin"].ToString()!="")
				{
					if((row["CI_BuiltIin"].ToString()=="1")||(row["CI_BuiltIin"].ToString().ToLower()=="true"))
					{
						model.CI_BuiltIin=true;
					}
					else
					{
						model.CI_BuiltIin=false;
					}
				}
				if(row["CI_Status"]!=null && row["CI_Status"].ToString()!="")
				{
					if((row["CI_Status"].ToString()=="1")||(row["CI_Status"].ToString().ToLower()=="true"))
					{
						model.CI_Status=true;
					}
					else
					{
						model.CI_Status=false;
					}
				}
				if(row["CI_Sequence"]!=null && row["CI_Sequence"].ToString()!="")
				{
					model.CI_Sequence=int.Parse(row["CI_Sequence"].ToString());
				}
				if(row["CI_Org_Code"]!=null)
				{
					model.CI_Org_Code=row["CI_Org_Code"].ToString();
				}
				if(row["CI_CT_Code"]!=null)
				{
					model.CI_CT_Code=row["CI_CT_Code"].ToString();
				}
                if (row["CI_Type"] != null)
                {
                    model.CI_Type = row["CI_Type"].ToString();
                }
                if (row["CI_NODP"] != null && row["CI_NODP"].ToString() != "")
                {
                    model.CI_NODP = int.Parse(row["CI_NODP"].ToString());
                }
                if (row["CI_Formula"] != null)
                {
                    model.CI_Formula = row["CI_Formula"].ToString();
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
			strSql.Append("select CI_ID,CI_Code,CI_Name,CI_Remarks,CI_BuiltIin,CI_Status,CI_Sequence,CI_Org_Code,CI_CT_Code ");
			strSql.Append(" FROM CompensationItem ");
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
			strSql.Append(" CI_ID,CI_Code,CI_Name,CI_Remarks,CI_BuiltIin,CI_Status,CI_Sequence,CI_Org_Code,CI_CT_Code ");
			strSql.Append(" FROM CompensationItem ");
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
			strSql.Append("select count(1) FROM CompensationItem ");
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
				strSql.Append("order by T.CI_ID desc");
			}
			strSql.Append(")AS Row, T.*  from CompensationItem T ");
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
			parameters[0].Value = "CompensationItem";
			parameters[1].Value = "CI_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 根据组织代码获得相关薪酬项目列表
        /// </summary>
        public DataSet GetListByOrg(string CI_Org_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CI_ID,CI_Code,CI_Name,CI_Remarks,CI_BuiltIin,CI_Status,CI_Sequence,CI_Org_Code,CI_CT_Code ");
            strSql.Append(" FROM CompensationItem ");
            SqlParameter[] parameters =  { 
                new SqlParameter("@CI_Org_Code",SqlDbType.VarChar,20)
            };
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据项目名称查找匹配的项目代码
        /// </summary>
        public string GetCodeByName(string CI_Name, string CI_Org_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CI_Code from CompensationItem");
            strSql.Append(" where CI_Name=@CI_Name and CI_Org_Code=@CI_Org_Code");
            SqlParameter[] parameters = {
					new SqlParameter("@CI_Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI_Org_Code", SqlDbType.VarChar,20)};
            parameters[0].Value = CI_Name;
            parameters[1].Value = CI_Org_Code;

            object obj = DbHelperSQL.ExecuteScalar(strSql.ToString(), parameters);
            if (obj == null)
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// 根据项目名称查找匹配的薪酬项目
        /// </summary>
        public LCSS.Model.CompensationItem GetModelByName(string CI_Name, string CI_Org_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from CompensationItem");
            strSql.Append(" where CI_Name=@CI_Name and CI_Org_Code=@CI_Org_Code");
            SqlParameter[] parameters = {
					new SqlParameter("@CI_Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI_Org_Code", SqlDbType.VarChar,20)};
            parameters[0].Value = CI_Name;
            parameters[1].Value = CI_Org_Code;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds == null||ds.Tables.Count==0||ds.Tables[0].Rows.Count==0)
                return null;
            return DataRowToModel(ds.Tables[0].Rows[0]);
        }
		#endregion  ExtensionMethod
	}
}

