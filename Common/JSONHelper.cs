/** 
* JSONHelper.cs
*
* 功 能： Json操作类
* 类 名： JSONHelper
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/1/23 16:00:00   彭聪    初版
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;

namespace OMS.Common
{
    public static class JSONHelper
    {
        /// <summary>
        /// DataTable对象转换成json格式([])
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <returns>json格式字符串</returns>
        public static string TableToJson(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            { return "[]"; }
            StringBuilder strJson = new StringBuilder();
            StringBuilder strCol = new StringBuilder();
            StringBuilder strRow = new StringBuilder();
            strJson.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                strRow.Append(",{");
                foreach (DataColumn col in dt.Columns)
                {
                    //if (col.ColumnName == "goodsname" || col.ColumnName == "record" || col.ColumnName == "remarks")
                    //{
                    //    StringBuilder strName = new StringBuilder();
                    //    if (string.IsNullOrEmpty(dr[col.ColumnName].ToString()))
                    //        strName.Append(dr[col.ColumnName]);
                    //    else
                    //        strName.AppendFormat("<span title='{0}'>{0}</span>",dr[col.ColumnName]);
                    //    strCol.AppendFormat(",\"{0}\":{1}", col.ColumnName, new JavaScriptSerializer().Serialize(strName.ToString()));
                    //}
                    //else
                        strCol.AppendFormat(",\"{0}\":{1}", col.ColumnName, new JavaScriptSerializer().Serialize(dr[col.ColumnName]));//后续，值需做处理，使能在JS中正常被使用@PC
                }
                strRow.Append(strCol.Remove(0, 1));
                strRow.Append("}");
                strCol.Clear();
            }
            strJson.Append(strRow.Remove(0, 1));
            strJson.Append("]");
            return strJson.ToString();
        }
        /// <summary>
        /// 返回转义处理后组合JSON格式的字符串
        /// </summary>
        /// <param name="sKey">Key</param>
        /// <param name="sValue">对应的值</param>
        /// <returns>返回组合JSON格式后的字符串</returns>
        internal static string StringJSON(string sKey, string sValue)
        {
            sValue = sValue.Replace("\r\n", "");
            sValue = sValue.Replace("\r", "");
            sValue = sValue.Replace("\n", "");
            sValue = sValue.Replace("\t", "");
            sValue = sValue.Replace(" ", "%20");
            sValue = sValue.Replace("\"", "%22");
            sValue = sValue.Replace("<", "%3C");
            sValue = sValue.Replace(">", "%3E");
            
            return "\"" + sKey + "\":\"" + sValue + "\"";
        }
        /// <summary>
        /// 转义处理字符串
        /// </summary>
        /// <param name="sValue">对应的值</param>
        /// <returns>返回返回处理后的字符串</returns>
        internal static string StringJSON(string sValue)
        {
            sValue = sValue.Replace("\r\n", "");
            sValue = sValue.Replace("\r", "");
            sValue = sValue.Replace("\n", "");
            sValue = sValue.Replace("\t", "");
            sValue = sValue.Replace(" ", "%20");
            sValue = sValue.Replace("\"", "%22");
            sValue = sValue.Replace("<", "%3C");
            sValue = sValue.Replace(">", "%3E");
            sValue = sValue.Replace("\\", "\\\\");

            return sValue;
        }

        
    }
}
