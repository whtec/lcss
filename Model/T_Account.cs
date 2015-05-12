/**  版本信息模板在安装目录下，可自行修改。
* T_Account.cs
*
* 功 能： N/A
* 类 名： T_Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/23 11:27:28   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace LCSS.Model
{
    /// <summary>
    /// T_Account:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Account
    {
        public T_Account()
        { }
        #region Model
        private long _acct_id;
        private string _acct_loginid;
        private string _acct_pwd;
        private string _acct_username;
        private int? _acct_deadlock = 0;
        private DateTime? _acct_expirydate;
        private bool _acct_noexpiry = true;
        private bool _acct_disable = false;
        private string _acct_us_code;
        private string _acct_org_code;
        /// <summary>
        /// 系统流水号
        /// </summary>
        public long ACCT_ID
        {
            set { _acct_id = value; }
            get { return _acct_id; }
        }
        /// <summary>
        /// 登录ID
        /// </summary>
        public string ACCT_LoginID
        {
            set { _acct_loginid = value; }
            get { return _acct_loginid; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string ACCT_Pwd
        {
            set { _acct_pwd = value; }
            get { return _acct_pwd; }
        }
        /// <summary>
        /// 显示姓名（可以不需要用户表）
        /// </summary>
        public string ACCT_UserName
        {
            set { _acct_username = value; }
            get { return _acct_username; }
        }
        /// <summary>
        /// 错误登录次数
        /// </summary>
        public int? ACCT_Deadlock
        {
            set { _acct_deadlock = value; }
            get { return _acct_deadlock; }
        }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime? ACCT_ExpiryDate
        {
            set { _acct_expirydate = value; }
            get { return _acct_expirydate; }
        }
        /// <summary>
        /// 是否从不过期
        /// </summary>
        public bool ACCT_NoExpiry
        {
            set { _acct_noexpiry = value; }
            get { return _acct_noexpiry; }
        }
        /// <summary>
        /// 是否禁用（禁止登陆）
        /// </summary>
        public bool ACCT_Disable
        {
            set { _acct_disable = value; }
            get { return _acct_disable; }
        }
        /// <summary>
        /// 关联用户代码
        /// </summary>
        public string ACCT_US_Code
        {
            set { _acct_us_code = value; }
            get { return _acct_us_code; }
        }
        /// <summary>
        /// 所属组织代码
        /// </summary>
        public string ACCT_Org_Code
        {
            set { _acct_org_code = value; }
            get { return _acct_org_code; }
        }

        private string _CurrentPwd;
        /// <summary>
        /// 当前密码
        /// </summary>
        public string CurrentPwd
        {
            set { _CurrentPwd = value; }
            get { return _CurrentPwd; }
        }
        private string _NewPwd;
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPwd
        {
            set { _NewPwd = value; }
            get { return _NewPwd; }
        }


        #endregion Model

    }
}

