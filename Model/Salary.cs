using System;
namespace LCSS.Model
{
    /// <summary>
    /// Salary:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Salary
    {
        public Salary()
        { }
        #region Model
        private long _sal_id;
        private int _sal_year;
        private int _sal_month;
        private string _sal_add_user;
        private DateTime _sal_add_date = DateTime.Now;
        private string _sal_org_code;

        /// <summary>
        /// 薪水台账流水号
        /// </summary>
        public long Sal_ID
        {
            set { _sal_id = value; }
            get { return _sal_id; }
        }
        /// <summary>
        /// 所属年
        /// </summary>
        public int Sal_Year
        {
            set { _sal_year = value; }
            get { return _sal_year; }
        }
        /// <summary>
        /// 所属月
        /// </summary>
        public int Sal_Month
        {
            set { _sal_month = value; }
            get { return _sal_month; }
        }
        /// <summary>
        /// 导入操作人代码
        /// </summary>
        public string Sal_Add_User
        {
            set { _sal_add_user = value; }
            get { return _sal_add_user; }
        }
        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime Sal_Add_Date
        {
            set { _sal_add_date = value; }
            get { return _sal_add_date; }
        }
        /// <summary>
        /// 导入操作人代码
        /// </summary>
        public string Sal_Org_Code
        {
            set { _sal_org_code = value; }
            get { return _sal_org_code; }
        }
        #endregion Model

    }
}

