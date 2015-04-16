using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PC.DBUtility;
namespace LCSS.DAL
{
	/// <summary>
	/// 数据访问类:Employees
	/// </summary>
	public partial class Employees
	{
		public Employees()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Emp_Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Employees");
			strSql.Append(" where Emp_Code=@Emp_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = Emp_Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该名员工
        /// </summary>
        public bool ExistsByName(string Emp_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employees");
            strSql.Append(" where Emp_Name=@Emp_Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Emp_Name", SqlDbType.NVarChar,20)			};
            parameters[0].Value = Emp_Name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该名员工
        /// </summary>
        public string GetCodeByName(string Emp_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Emp_Code from Employees");
            strSql.Append(" where Emp_Name=@Emp_Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@Emp_Name", SqlDbType.NVarChar,20)			};
            parameters[0].Value = Emp_Name;

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
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.Employees model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Employees(");
			strSql.Append("Emp_Code,Emp_Name,Emp_Sex,Emp_Org_Code,Emp_Sort)");
			strSql.Append(" values (");
			strSql.Append("@Emp_Code,@Emp_Name,@Emp_Sex,@Emp_Org_Code,@Emp_Sort)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Emp_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Emp_Sex", SqlDbType.NVarChar,1),
					new SqlParameter("@Emp_Org_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Emp_Sort", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.Emp_Code;
			parameters[1].Value = model.Emp_Name;
			parameters[2].Value = model.Emp_Sex;
			parameters[3].Value = model.Emp_Org_Code;
			parameters[4].Value = model.Emp_Sort;

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
		public bool Update(LCSS.Model.Employees model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Employees set ");
			strSql.Append("Emp_Name=@Emp_Name,");
			strSql.Append("Emp_Sex=@Emp_Sex,");
			strSql.Append("Emp_Org_Code=@Emp_Org_Code,");
			strSql.Append("Emp_Sort=@Emp_Sort");
			strSql.Append(" where Emp_ID=@Emp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Emp_Sex", SqlDbType.NVarChar,1),
					new SqlParameter("@Emp_Org_Code", SqlDbType.VarChar,20),
					new SqlParameter("@Emp_Sort", SqlDbType.SmallInt,2),
					new SqlParameter("@Emp_ID", SqlDbType.BigInt,8),
					new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Emp_Name;
			parameters[1].Value = model.Emp_Sex;
			parameters[2].Value = model.Emp_Org_Code;
			parameters[3].Value = model.Emp_Sort;
			parameters[4].Value = model.Emp_ID;
			parameters[5].Value = model.Emp_Code;

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
		public bool Delete(long Emp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employees ");
			strSql.Append(" where Emp_ID=@Emp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Emp_ID;

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
		public bool Delete(string Emp_Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employees ");
			strSql.Append(" where Emp_Code=@Emp_Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)			};
			parameters[0].Value = Emp_Code;

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
		public bool DeleteList(string Emp_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Employees ");
			strSql.Append(" where Emp_ID in ("+Emp_IDlist + ")  ");
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
		public LCSS.Model.Employees GetModel(long Emp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Emp_ID,Emp_Code,Emp_Name,Emp_Sex,Emp_Org_Code,Emp_Sort from Employees ");
			strSql.Append(" where Emp_ID=@Emp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Emp_ID", SqlDbType.BigInt)
			};
			parameters[0].Value = Emp_ID;

			LCSS.Model.Employees model=new LCSS.Model.Employees();
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
		public LCSS.Model.Employees DataRowToModel(DataRow row)
		{
			LCSS.Model.Employees model=new LCSS.Model.Employees();
			if (row != null)
			{
				if(row["Emp_ID"]!=null && row["Emp_ID"].ToString()!="")
				{
					model.Emp_ID=long.Parse(row["Emp_ID"].ToString());
				}
				if(row["Emp_Code"]!=null)
				{
					model.Emp_Code=row["Emp_Code"].ToString();
				}
				if(row["Emp_Name"]!=null)
				{
					model.Emp_Name=row["Emp_Name"].ToString();
				}
				if(row["Emp_Sex"]!=null)
				{
					model.Emp_Sex=row["Emp_Sex"].ToString();
				}
				if(row["Emp_Org_Code"]!=null)
				{
					model.Emp_Org_Code=row["Emp_Org_Code"].ToString();
				}
				if(row["Emp_Sort"]!=null && row["Emp_Sort"].ToString()!="")
				{
					model.Emp_Sort=int.Parse(row["Emp_Sort"].ToString());
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
			strSql.Append("select Emp_ID,Emp_Code,Emp_Name,Emp_Sex,Emp_Org_Code,Emp_Sort ");
			strSql.Append(" FROM Employees ");
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
			strSql.Append(" Emp_ID,Emp_Code,Emp_Name,Emp_Sex,Emp_Org_Code,Emp_Sort ");
			strSql.Append(" FROM Employees ");
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
			strSql.Append("select count(1) FROM Employees ");
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
				strSql.Append("order by T.Emp_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Employees T ");
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
			parameters[0].Value = "Employees";
			parameters[1].Value = "Emp_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

	}
}

