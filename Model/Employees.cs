using System;
namespace LCSS.Model
{
	/// <summary>
	/// Employees:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Employees
	{
		public Employees()
		{}
		#region Model
		private long _emp_id;
		private string _emp_code;
		private string _emp_name;
		private string _emp_sex;
		private string _emp_org_code;
		private int? _emp_sort;
		/// <summary>
		/// 流水号
		/// </summary>
		public long Emp_ID
		{
			set{ _emp_id=value;}
			get{return _emp_id;}
		}
		/// <summary>
		/// 员工工号
		/// </summary>
		public string Emp_Code
		{
			set{ _emp_code=value;}
			get{return _emp_code;}
		}
		/// <summary>
		/// 员工名称
		/// </summary>
		public string Emp_Name
		{
			set{ _emp_name=value;}
			get{return _emp_name;}
		}
		/// <summary>
		/// 员工性别
		/// </summary>
		public string Emp_Sex
		{
			set{ _emp_sex=value;}
			get{return _emp_sex;}
		}
		/// <summary>
		/// 所属组织代码
		/// </summary>
		public string Emp_Org_Code
		{
			set{ _emp_org_code=value;}
			get{return _emp_org_code;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int? Emp_Sort
		{
			set{ _emp_sort=value;}
			get{return _emp_sort;}
		}
		#endregion Model

	}
}

