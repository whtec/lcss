/**  版本信息模板在安装目录下，可自行修改。
* T_Account.cs
*
* 功 能： N/A
* 类 名： T_Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/23 11:02:34   N/A    初版
*
* Copyright (c) 2012 PC Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using PC.Common;
using LCSS.Model;
namespace LCSS.BLL
{
	/// <summary>
	/// T_Account
	/// </summary>
	public partial class T_Account
	{
        private readonly LCSS.DAL.T_Account dal = new LCSS.DAL.T_Account();
		public T_Account()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ACCT_LoginID)
		{
			return dal.Exists(ACCT_LoginID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(LCSS.Model.T_Account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(LCSS.Model.T_Account model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ACCT_ID)
		{
			
			return dal.Delete(ACCT_ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ACCT_LoginID)
		{
			
			return dal.Delete(ACCT_LoginID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ACCT_IDlist )
		{
			return dal.DeleteList(ACCT_IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LCSS.Model.T_Account GetModel(long ACCT_ID)
		{			
			return dal.GetModel(ACCT_ID);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCSS.Model.T_Account GetLoginInfo(string ACCT_LoginID, string ACCT_Pwd)
        {
            return dal.GetLoginInfo(ACCT_LoginID, ACCT_Pwd);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public LCSS.Model.T_Account GetModelByCache(long ACCT_ID)
		{
			
			string CacheKey = "T_AccountModel-" + ACCT_ID;
			object objModel = PC.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ACCT_ID);
					if (objModel != null)
					{
						int ModelCache = PC.Common.ConfigHelper.GetConfigInt("ModelCache");
						PC.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (LCSS.Model.T_Account)objModel;
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
		public List<LCSS.Model.T_Account> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LCSS.Model.T_Account> DataTableToList(DataTable dt)
		{
			List<LCSS.Model.T_Account> modelList = new List<LCSS.Model.T_Account>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LCSS.Model.T_Account model;
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

