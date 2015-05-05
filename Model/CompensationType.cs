using System;
namespace LCSS.Model
{
	/// <summary>
	/// CompensationType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CompensationType
	{
		public CompensationType()
		{}
		#region Model
		private long _ct_id;
		private string _ct_code;
		private string _ct_name;
		/// <summary>
		/// 
		/// </summary>
		public long CT_ID
		{
			set{ _ct_id=value;}
			get{return _ct_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CT_CODE
		{
			set{ _ct_code=value;}
			get{return _ct_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CT_NAME
		{
			set{ _ct_name=value;}
			get{return _ct_name;}
		}
		#endregion Model

	}
}

