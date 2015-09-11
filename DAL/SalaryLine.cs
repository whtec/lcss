using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using PC.DBUtility;
namespace LCSS.DAL
{
    /// <summary>
    /// 数据访问类:SalaryLine
    /// </summary>
    public partial class SalaryLine
    {
        public SalaryLine()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SL_Sal_ID, string SL_CI_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SalaryLine");
            strSql.Append(" where SL_Sal_ID=@SL_Sal_ID and SL_CI_Code=@SL_CI_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@SL_Sal_ID", SqlDbType.VarChar,20),
					new SqlParameter("@SL_CI_Code", SqlDbType.VarChar,20)			};
            parameters[0].Value = SL_Sal_ID;
            parameters[1].Value = SL_CI_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(LCSS.Model.SalaryLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SalaryLine(");
            strSql.Append("SL_Sal_ID,SL_CI_Code,SL_Emp_Code,SL_Pay)");
            strSql.Append(" values (");
            strSql.Append("@SL_Sal_ID,@SL_CI_Code,@SL_Emp_Code,@SL_Pay)");
            SqlParameter[] parameters = {
					new SqlParameter("@SL_Sal_ID", SqlDbType.VarChar,20),
					new SqlParameter("@SL_CI_Code", SqlDbType.VarChar,20),
					new SqlParameter("@SL_Emp_Code", SqlDbType.VarChar,20),
					new SqlParameter("@SL_Pay", SqlDbType.Money,8)};
            parameters[0].Value = model.SL_Sal_ID;
            parameters[1].Value = model.SL_CI_Code;
            parameters[2].Value = model.SL_Emp_Code;
            parameters[3].Value = model.SL_Pay;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(LCSS.Model.SalaryLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SalaryLine set ");
            strSql.Append("SL_Emp_Code=@SL_Emp_Code,");
            strSql.Append("SL_Pay=@SL_Pay");
            strSql.Append(" where SL_Sal_ID=@SL_Sal_ID and SL_CI_Code=@SL_CI_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@SL_Emp_Code", SqlDbType.VarChar,20),
					new SqlParameter("@SL_Pay", SqlDbType.Money,8),
					new SqlParameter("@SL_Sal_ID", SqlDbType.VarChar,20),
					new SqlParameter("@SL_CI_Code", SqlDbType.VarChar,20)};
            parameters[0].Value = model.SL_Emp_Code;
            parameters[1].Value = model.SL_Pay;
            parameters[2].Value = model.SL_Sal_ID;
            parameters[3].Value = model.SL_CI_Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string SL_Sal_ID, string SL_CI_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SalaryLine ");
            strSql.Append(" where SL_Sal_ID=@SL_Sal_ID and SL_CI_Code=@SL_CI_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@SL_Sal_ID", SqlDbType.VarChar,20),
					new SqlParameter("@SL_CI_Code", SqlDbType.VarChar,20)			};
            parameters[0].Value = SL_Sal_ID;
            parameters[1].Value = SL_CI_Code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public LCSS.Model.SalaryLine GetModel(string SL_Sal_ID, string SL_CI_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SL_ID,SL_Sal_ID,SL_CI_Code,SL_Emp_Code,SL_Pay from SalaryLine ");
            strSql.Append(" where SL_Sal_ID=@SL_Sal_ID and SL_CI_Code=@SL_CI_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@SL_Sal_ID", SqlDbType.VarChar,20),
					new SqlParameter("@SL_CI_Code", SqlDbType.VarChar,20)			};
            parameters[0].Value = SL_Sal_ID;
            parameters[1].Value = SL_CI_Code;

            LCSS.Model.SalaryLine model = new LCSS.Model.SalaryLine();
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
        public LCSS.Model.SalaryLine DataRowToModel(DataRow row)
        {
            LCSS.Model.SalaryLine model = new LCSS.Model.SalaryLine();
            if (row != null)
            {
                if (row["SL_ID"] != null && row["SL_ID"].ToString() != "")
                {
                    model.SL_ID = long.Parse(row["SL_ID"].ToString());
                }
                if (row["SL_Sal_ID"] != null)
                {
                    model.SL_Sal_ID = long.Parse(row["SL_Sal_ID"].ToString());
                }
                if (row["SL_CI_Code"] != null)
                {
                    model.SL_CI_Code = row["SL_CI_Code"].ToString();
                }
                if (row["SL_Emp_Code"] != null)
                {
                    model.SL_Emp_Code = row["SL_Emp_Code"].ToString();
                }
                if (row["SL_Pay"] != null && row["SL_Pay"].ToString() != "")
                {
                    model.SL_Pay = decimal.Parse(row["SL_Pay"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SL_ID,SL_Sal_ID,SL_CI_Code,SL_Emp_Code,SL_Pay ");
            strSql.Append(" FROM SalaryLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SL_ID,SL_Sal_ID,SL_CI_Code,SL_Emp_Code,SL_Pay ");
            strSql.Append(" FROM SalaryLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SalaryLine ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SL_CI_Code desc");
            }
            strSql.Append(")AS Row, T.*  from SalaryLine T ");
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
            parameters[0].Value = "SalaryLine";
            parameters[1].Value = "SL_CI_Code";
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
        /// 增加多条数据
        /// </summary>
        public bool AddMul(IList<LCSS.Model.SalaryLine> ilModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SalaryLine(");
            strSql.Append("SL_Sal_ID,SL_CI_Code,SL_Emp_Code,SL_Pay)");
            strSql.Append(" values ");
            StringBuilder strValues = new StringBuilder();
            foreach (LCSS.Model.SalaryLine model in ilModel)
            {
                strValues.AppendFormat(",({0},'{1}','{2}',{3})", model.SL_Sal_ID, model.SL_CI_Code, model.SL_Emp_Code, model.SL_Pay);
            }
            strValues.Remove(0, 1);
            strSql.Append(strValues.ToString());
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 查询人工成本列表（每月每人）（分页）
        /// </summary>
        /// <param name="PageSize">每页显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Emp_Code">员工编号</param>
        /// <returns></returns>
        public DataSet GetSalaryLineByMonth(int PageSize, int PageIndex, string OrderBy, string strWhere, string Org_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@OrderBy", SqlDbType.VarChar, 50),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@Org_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = OrderBy;
            parameters[3].Value = strWhere;
            parameters[4].Value = Org_Code;
            return DbHelperSQL.Query("GetList_SalaryLineByMonth", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 查询人工成本列表（每年每人）（分页）
        /// </summary>
        /// <param name="PageSize">每页显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Emp_Code">员工编号</param>
        /// <returns></returns>
        public DataSet GetSalaryLineByYear(int PageSize, int PageIndex, string OrderBy, string strWhere, string Org_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@OrderBy", SqlDbType.VarChar, 50),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@Org_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = OrderBy;
            parameters[3].Value = strWhere;
            parameters[4].Value = Org_Code;
            return DbHelperSQL.Query("GetList_SalaryLineByYear", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 查询导入的人工成本列表（每次导入每人）（分页）
        /// </summary>
        /// <param name="PageSize">每页显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Org_Code">组织编号</param>
        /// <returns></returns>
        public DataSet GetList_SalaryLineBySalary(int PageSize, int PageIndex, string OrderBy, string strWhere, string Org_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@OrderBy", SqlDbType.VarChar, 50),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@Org_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = OrderBy;
            parameters[3].Value = strWhere;
            parameters[4].Value = Org_Code;
            return DbHelperSQL.Query("GetList_SalaryLineBySalary", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 查询个人收入明细列表（分页）
        /// </summary>
        /// <param name="PageSize">每页显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Emp_Code">员工编号</param>
        /// <returns></returns>
        public DataSet GetList_SalaryLineByEmployees(int PageSize, int PageIndex, string OrderBy, string strWhere, string Emp_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@OrderBy", SqlDbType.VarChar, 50),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = PageSize;
            parameters[1].Value = PageIndex;
            parameters[2].Value = OrderBy;
            parameters[3].Value = strWhere;
            parameters[4].Value = Emp_Code;
            return DbHelperSQL.Query("GetList_SalaryLineByEmployees", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 查看个人指定编次的导入列表
        /// </summary>
        /// <param name="Sal_ID">导入编次</param>
        /// <param name="Emp_Code">员工编号</param>
        /// <returns></returns>
        public DataSet GetList_SalaryLineByEmployees2(string Sal_ID, string Emp_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Sal_ID", SqlDbType.VarChar,20),
                    new SqlParameter("@Emp_Code", SqlDbType.VarChar, 20)
					};
            parameters[0].Value = Sal_ID;
            parameters[1].Value = Emp_Code;
            return DbHelperSQL.Query("GetList_SalaryLineByEmployees2", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 个人月度总收入（按客户提供格式）,必须固定[CT_CODE]代码
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <param name="Emp_Code"></param>
        /// <returns></returns>
        public DataSet GetList_SalaryLineByEmployees3(int iYear, int iMonth, string Emp_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@Emp_Code", SqlDbType.VarChar,20),
                    new SqlParameter("@Sal_Year", SqlDbType.VarChar, 20),
                    new SqlParameter("@Sal_Month", SqlDbType.VarChar, 20)
					};
            parameters[0].Value = Emp_Code;
            parameters[1].Value = iYear.ToString();
            parameters[2].Value = iMonth.ToString();
            return DbHelperSQL.Query("GetList_SalaryLineByEmployees3", CommandType.StoredProcedure, parameters);
        }
        /// <summary>
        /// 得到指定年月工资信息
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <param name="Emp_Code"></param>
        /// <returns>返回2个表，包含基本工资项表和统计表</returns>
        public DataSet GetMyGongzitiao(int iYear,int iMonth,string Emp_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iYear", SqlDbType.Int),
					new SqlParameter("@iMonth", SqlDbType.Int),
                    new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = iYear;
            parameters[1].Value = iMonth;
            parameters[2].Value = Emp_Code;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT *
                      FROM [dbo].[View_SalaryLineByGZT] where [Sal_Year]=@iYear and [Sal_Month]=@iMonth and [SL_Emp_Code]=@Emp_Code
                      order by [Sal_Year],[Sal_Month],CT_Sequence,CI_Sequence");
            strSql.Append(@";SELECT *
                      FROM [dbo].[View_SalaryLineTotalByGZT] where [V_SLTG_Sal_Year]=@iYear and [V_SLTG_Sal_Month]=@iMonth and [V_SLTG_Emp_Code]=@Emp_Code
                      order by [V_SLTG_Sal_Year],[V_SLTG_Sal_Month],[V_SLTG_CT_Sequence]");
            return DbHelperSQL.Query(strSql.ToString(), CommandType.Text, parameters);
        }
        /// <summary>
        /// 得到指定年月工资台账信息
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <param name="Emp_Code">空则查询所有人</param>
        /// <returns></returns>
        public DataSet GetIncomeList(int iYear, int iMonth, string Emp_Code)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iYear", SqlDbType.Int),
					new SqlParameter("@iMonth", SqlDbType.Int),
                    new SqlParameter("@Emp_Code", SqlDbType.VarChar,20)
					};
            parameters[0].Value = iYear;
            parameters[1].Value = iMonth;
            parameters[2].Value = Emp_Code;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM View_IncomeList WHERE [年度]=@iYear AND [月度]=@iMonth");
            if (!string.IsNullOrEmpty(Emp_Code))
                strSql.Append(@" AND [工号]=@Emp_Code");
            strSql.Append(@";SELECT COUNT(*) FROM View_IncomeList WHERE [年度]=@iYear AND [月度]=@iMonth");
            if (!string.IsNullOrEmpty(Emp_Code))
                strSql.Append(@" AND [工号]=@Emp_Code");
            return DbHelperSQL.Query(strSql.ToString(), CommandType.Text, parameters);

        }
        #endregion  ExtensionMethod
    }
}

