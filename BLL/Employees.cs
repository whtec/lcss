using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using LCSS.Model;
namespace LCSS.BLL
{
	/// <summary>
	/// Employees
	/// </summary>
	public partial class Employees
	{
		private readonly LCSS.DAL.Employees dal=new LCSS.DAL.Employees();
		public Employees()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Emp_Code)
		{
			return dal.Exists(Emp_Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.Employees model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.Employees model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Emp_ID)
		{
			
			return dal.Delete(Emp_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Emp_Code)
		{
			
			return dal.Delete(Emp_Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Emp_IDlist )
		{
			return dal.DeleteList(Emp_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.Employees GetModel(long Emp_ID)
		{
			
			return dal.GetModel(Emp_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public LCSS.Model.Employees GetModelByCache(long Emp_ID)
		{
			
			string CacheKey = "EmployeesModel-" + Emp_ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Emp_ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LCSS.Model.Employees)objModel;
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
		public List<LCSS.Model.Employees> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.Employees> DataTableToList(DataTable dt)
		{
			List<LCSS.Model.Employees> modelList = new List<LCSS.Model.Employees>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LCSS.Model.Employees model;
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

		#endregion  ExtensionMethod
	}
}

