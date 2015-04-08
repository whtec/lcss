using System;
using System.Data;
using System.Collections.Generic;
using PC.Common;
using LCSS.Model;
namespace LCSS.BLL
{
	/// <summary>
	/// Organization
	/// </summary>
	public partial class Organization
	{
		private readonly LCSS.DAL.Organization dal=new LCSS.DAL.Organization();
		public Organization()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Org_Code)
		{
			return dal.Exists(Org_Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.Organization model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.Organization model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long Org_ID)
		{
			
			return dal.Delete(Org_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Org_Code)
		{
			
			return dal.Delete(Org_Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Org_IDlist )
		{
			return dal.DeleteList(Org_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.Organization GetModel(long Org_ID)
		{
			
			return dal.GetModel(Org_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public LCSS.Model.Organization GetModelByCache(long Org_ID)
		{
			
			string CacheKey = "OrganizationModel-" + Org_ID;
			object objModel = PC.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Org_ID);
					if (objModel != null)
					{
						int ModelCache = PC.Common.ConfigHelper.GetConfigInt("ModelCache");
						PC.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LCSS.Model.Organization)objModel;
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
		public List<LCSS.Model.Organization> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.Organization> DataTableToList(DataTable dt)
		{
			List<LCSS.Model.Organization> modelList = new List<LCSS.Model.Organization>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LCSS.Model.Organization model;
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

