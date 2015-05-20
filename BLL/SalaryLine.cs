using System;
using System.Data;
using System.Collections.Generic;
using PC.Common;
using LCSS.Model;
namespace LCSS.BLL
{
	/// <summary>
	/// SalaryLine
	/// </summary>
	public partial class SalaryLine
	{
		private readonly LCSS.DAL.SalaryLine dal=new LCSS.DAL.SalaryLine();
		public SalaryLine()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SL_Sal_ID,string SL_CI_Code)
		{
			return dal.Exists(SL_Sal_ID,SL_CI_Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LCSS.Model.SalaryLine model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.SalaryLine model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SL_Sal_ID,string SL_CI_Code)
		{
			
			return dal.Delete(SL_Sal_ID,SL_CI_Code);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.SalaryLine GetModel(string SL_Sal_ID,string SL_CI_Code)
		{
			
			return dal.GetModel(SL_Sal_ID,SL_CI_Code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public LCSS.Model.SalaryLine GetModelByCache(string SL_Sal_ID,string SL_CI_Code)
		{
			
			string CacheKey = "SalaryLineModel-" + SL_Sal_ID+SL_CI_Code;
			object objModel = PC.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SL_Sal_ID,SL_CI_Code);
					if (objModel != null)
					{
						int ModelCache = PC.Common.ConfigHelper.GetConfigInt("ModelCache");
						PC.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LCSS.Model.SalaryLine)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.SalaryLine> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.SalaryLine> DataTableToList(DataTable dt)
		{
			List<LCSS.Model.SalaryLine> modelList = new List<LCSS.Model.SalaryLine>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LCSS.Model.SalaryLine model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 增加多条数据
        /// </summary>
        public bool AddMul(IList<LCSS.Model.SalaryLine> ilModel)
        {
            return dal.AddMul(ilModel);
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
            return dal.GetSalaryLineByMonth(PageSize, PageIndex, OrderBy, strWhere, Org_Code);
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
            return dal.GetList_SalaryLineBySalary(PageSize, PageIndex, OrderBy, strWhere, Org_Code);
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
            return dal.GetList_SalaryLineByEmployees(PageSize, PageIndex, OrderBy, strWhere, Emp_Code);
        }
        public DataSet GetList_SalaryLineByEmployees2(string Sal_ID, string Emp_Code)
        {
            return dal.GetList_SalaryLineByEmployees2(Sal_ID,Emp_Code);
        }
        public DataSet GetList_SalaryLineByEmployees3(string Emp_Code, string Sal_Year, string Sal_Month)
        {
            return dal.GetList_SalaryLineByEmployees3(Emp_Code, Sal_Year, Sal_Month);
        }
        public DataSet GetMyGongzitiao(int iYear,int iMonth,string Emp_Code)
        {
            return dal.GetMyGongzitiao(iYear, iMonth, Emp_Code);
        }
		#endregion  ExtensionMethod
	}
}

