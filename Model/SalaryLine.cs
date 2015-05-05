using System;
namespace LCSS.Model
{
	/// <summary>
	/// SalaryLine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SalaryLine
	{
		public SalaryLine()
		{}
		#region Model
		private long _sl_id;
        private long _sl_sal_id;
		private string _sl_ci_code;
		private string _sl_emp_code;
		private decimal _sl_pay=0M;
		/// <summary>
		/// 流水号
		/// </summary>
		public long SL_ID
		{
			set{ _sl_id=value;}
			get{return _sl_id;}
		}
		/// <summary>
		/// 薪水台账代码
		/// </summary>
        public long SL_Sal_ID
		{
			set{ _sl_sal_id=value;}
			get{return _sl_sal_id;}
		}
		/// <summary>
		/// 薪酬项目代码
		/// </summary>
		public string SL_CI_Code
		{
			set{ _sl_ci_code=value;}
			get{return _sl_ci_code;}
		}
		/// <summary>
		/// 所属用户
		/// </summary>
		public string SL_Emp_Code
		{
			set{ _sl_emp_code=value;}
			get{return _sl_emp_code;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal SL_Pay
		{
			set{ _sl_pay=value;}
			get{return _sl_pay;}
		}
		#endregion Model

	}
}

