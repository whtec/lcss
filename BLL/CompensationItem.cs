using System;
using System.Data;
using System.Collections.Generic;
using PC.Common;
using LCSS.Model;
namespace LCSS.BLL
{
	/// <summary>
	/// CompensationItem
	/// </summary>
	public partial class CompensationItem
	{
		private readonly LCSS.DAL.CompensationItem dal=new LCSS.DAL.CompensationItem();
		public CompensationItem()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CI_Code)
		{
			return dal.Exists(CI_Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.CompensationItem model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.CompensationItem model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long CI_ID)
		{
			
			return dal.Delete(CI_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CI_Code)
		{
			
			return dal.Delete(CI_Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CI_IDlist )
		{
			return dal.DeleteList(CI_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.CompensationItem GetModel(long CI_ID)
		{
			
			return dal.GetModel(CI_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public LCSS.Model.CompensationItem GetModelByCache(long CI_ID)
		{
			
			string CacheKey = "CompensationItemModel-" + CI_ID;
			object objModel = PC.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CI_ID);
					if (objModel != null)
					{
						int ModelCache = PC.Common.ConfigHelper.GetConfigInt("ModelCache");
						PC.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LCSS.Model.CompensationItem)objModel;
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
		public List<LCSS.Model.CompensationItem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.CompensationItem> DataTableToList(DataTable dt)
		{
			List<LCSS.Model.CompensationItem> modelList = new List<LCSS.Model.CompensationItem>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LCSS.Model.CompensationItem model;
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

