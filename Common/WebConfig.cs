namespace PC.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    /// <summary>
    /// 获取固定配置类
    /// dd by PC at 2012.12.4
    /// </summary>
    public sealed class Config
    {
        private Config() { }
        public static readonly Config objConfig = new Config();

        #region 从web.config中获取配置返回字符串
        /// <summary>
        /// 从web.config中获取AppSettings配置
        /// </summary>
        /// <param name="strKey">配置标识</param>
        /// <returns>配置内容</returns>
        public string getStringAppSetings(string strKey)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[strKey]))
            {
                throw new ConfigurationErrorsException(string.Format("AppSettings配置丢失：KEY=\"{0}\"", strKey));
            }
            return ConfigurationManager.AppSettings[strKey].ToString();
        }
        /// <summary>
        /// 从web.config中获取connectionStrings配置
        /// </summary>
        /// <param name="strKey">配置标识</param>
        /// <returns>配置内容</returns>
        public string getConnStrings(string strKey)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[strKey].ConnectionString))
            {
                throw new ConfigurationErrorsException(string.Format("connectionStrings配置丢失：KEY=\"{0}\"", strKey));
            }
            return ConfigurationManager.ConnectionStrings[strKey].ConnectionString;
        }
        #endregion

        #region 从web.config中获取配置返回数值
        /// <summary>
        /// 从web.config中获取配置
        /// </summary>
        /// <param name="strKey">配置标识</param>
        /// <returns>配置内容(数值)</returns>
        private int getIntAppSetings(string strKey)
        {
            string value = getStringAppSetings(strKey);
            int result = 0;
            if (!Int32.TryParse(value, out result))
            {
                throw new ConfigurationErrorsException(string.Format("配置中数值无效： \"{0}\"", strKey));
            }
            return result;
        }
        #endregion

    }
}
