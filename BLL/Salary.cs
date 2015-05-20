using System;
using System.Data;
using System.Collections.Generic;
using PC.Common;
using LCSS.Model;
namespace LCSS.BLL
{
    /// <summary>
    /// Salary
    /// </summary>
    public partial class Salary
    {
        private readonly LCSS.DAL.Salary dal = new LCSS.DAL.Salary();
        public Salary()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long Sal_ID)
        {
            return dal.Exists(Sal_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(LCSS.Model.Salary model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(LCSS.Model.Salary model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long Sal_ID)
        {

            return dal.Delete(Sal_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Sal_IDlist)
        {
            return dal.DeleteList(Sal_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCSS.Model.Salary GetModel(long Sal_ID)
        {

            return dal.GetModel(Sal_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public LCSS.Model.Salary GetModelByCache(long Sal_ID)
        {

            string CacheKey = "SalaryModel-" + Sal_ID;
            object objModel = PC.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Sal_ID);
                    if (objModel != null)
                    {
                        int ModelCache = PC.Common.ConfigHelper.GetConfigInt("ModelCache");
                        PC.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (LCSS.Model.Salary)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LCSS.Model.Salary> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LCSS.Model.Salary> DataTableToList(DataTable dt)
        {
            List<LCSS.Model.Salary> modelList = new List<LCSS.Model.Salary>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LCSS.Model.Salary model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        public DataSet GetSalaryDateList(int PageSize, int PageIndex,string Emp_Code)
        {
            return dal.GetSalaryDateList(PageSize, PageIndex, Emp_Code);
        }
        /// <summary>
        /// 查询导入历史列表（分页）
        /// </summary>
        /// <param name="PageSize">每页显示数量</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="strWhere">条件</param>
        /// <param name="Org_Code">组织编号</param>
        /// <returns></returns>
        public DataSet GetList_Salary(int PageSize, int PageIndex, string OrderBy, string strWhere)
        {
            return dal.GetList_Salary(PageSize, PageIndex, OrderBy, strWhere);
        }
        public DataSet GetSalaryList(int year, int month, string Emp_Code)
        {
            return dal.GetSalaryList(year, month, Emp_Code);
        }
        #endregion  ExtensionMethod
    }
}

