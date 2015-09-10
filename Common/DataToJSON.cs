/**
* DataJson.cs
*
* 功 能： 得到表格所需要的分页JSON（后续按需扩展）
* 类 名： DataJson
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/1/25            彭聪    初版
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;

namespace PC.Common
{
    public static class DataToJSON
    {
        /// <summary>
        /// 得到表格所需要的分页JSON
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGridJson(DataSet ds)
        {
            string row = string.Empty;
            string total = string.Empty;

            if (ds != null && ds.Tables.Count == 2)
            {
                row = JSONHelper.TableToJson(ds.Tables[0]);
                total = ds.Tables[1].Rows[0][0].ToString();
            }
            string json = "{\"Rows\":" + row + ",\"Total\":\"" + total + "\"}";
            return json;
        }
        /// <summary>
        /// 得到表格所需要的JSON
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetGridJson(DataTable dt)
        {
            string row = string.Empty;
            string total = string.Empty;

            if (dt != null)
            {
                row = JSONHelper.TableToJson(dt);
                total = dt.Rows[0][0].ToString();
            }
            string json = "{\"Rows\":" + row + ",\"Total\":\"" + total + "\"}";
            return json;
        }

        /// <summary>
        /// 得到表格所需要的JSON
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetTableJson(DataTable dt)
        {
            string json = string.Empty;
            if (dt != null)
            {
                json = JSONHelper.TableToJson(dt);
            }
            return json;
        }
    }
}
