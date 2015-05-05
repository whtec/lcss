using System;
namespace LCSS.Model
{
	/// <summary>
	/// Organization:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Organization
	{
		public Organization()
		{}
		#region Model
		private long _org_id;
		private string _org_code;
		private string _org_name;
		private string _org_parent_code;
		private bool _org_status;
		private string _org_layer;
		/// <summary>
		/// 流水号
		/// </summary>
		public long Org_ID
		{
			set{ _org_id=value;}
			get{return _org_id;}
		}
		/// <summary>
		/// 组织代码
		/// </summary>
		public string Org_Code
		{
			set{ _org_code=value;}
			get{return _org_code;}
		}
		/// <summary>
		/// 组织名称
		/// </summary>
		public string Org_Name
		{
			set{ _org_name=value;}
			get{return _org_name;}
		}
		/// <summary>
		/// 上级组织代码
		/// </summary>
		public string Org_Parent_Code
		{
			set{ _org_parent_code=value;}
			get{return _org_parent_code;}
		}
		/// <summary>
		/// 状态（启用or禁用）
		/// </summary>
		public bool Org_Status
		{
			set{ _org_status=value;}
			get{return _org_status;}
		}
		/// <summary>
		/// 组织层级（集团、公司、部门、片区）
		/// </summary>
		public string Org_Layer
		{
			set{ _org_layer=value;}
			get{return _org_layer;}
		}
		#endregion Model

	}
}

