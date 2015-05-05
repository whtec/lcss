using System;
namespace LCSS.Model
{
	/// <summary>
	/// CompensationItem:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CompensationItem
	{
		public CompensationItem()
		{}
		#region Model
		private long _ci_id;
		private string _ci_code;
		private string _ci_name;
		private string _ci_remarks;
		private bool _ci_builtiin;
		private bool _ci_status;
		private int? _ci_sequence;
		private string _ci_org_code;
		private string _ci_ct_code;
        private string _ci_type;
        private int _ci_nodp;
        private string _ci_formula;

        /// <summary>
        /// 类型(输入项,计算项,扣减项(所得税))
        /// </summary>
        public string CI_Type
        {
            set { _ci_type = value; }
            get { return _ci_type; }
        }
        /// <summary>
        /// 小数位数（Number of decimal places）
        /// </summary>
        public int CI_NODP
        {
            set { _ci_nodp = value; }
            get { return _ci_nodp; }
        }
        /// <summary>
        /// 计算公式（限制:CI_Type必须是计算项）
        /// </summary>
        public string CI_Formula
        {
            set { _ci_formula = value; }
            get { return _ci_formula; }
        }

		/// <summary>
		/// 流水号
		/// </summary>
		public long CI_ID
		{
			set{ _ci_id=value;}
			get{return _ci_id;}
		}
		/// <summary>
		/// 薪酬项目编码
		/// </summary>
		public string CI_Code
		{
			set{ _ci_code=value;}
			get{return _ci_code;}
		}
		/// <summary>
		/// 薪酬项目名称
		/// </summary>
		public string CI_Name
		{
			set{ _ci_name=value;}
			get{return _ci_name;}
		}
		/// <summary>
		/// 备注，说明
		/// </summary>
		public string CI_Remarks
		{
			set{ _ci_remarks=value;}
			get{return _ci_remarks;}
		}
		/// <summary>
		/// 该项是否内置固定项
		/// </summary>
		public bool CI_BuiltIin
		{
			set{ _ci_builtiin=value;}
			get{return _ci_builtiin;}
		}
		/// <summary>
		/// 状态（启用or禁用）
		/// </summary>
		public bool CI_Status
		{
			set{ _ci_status=value;}
			get{return _ci_status;}
		}
		/// <summary>
		/// 顺显示序
		/// </summary>
		public int? CI_Sequence
		{
			set{ _ci_sequence=value;}
			get{return _ci_sequence;}
		}
		/// <summary>
		/// 薪酬项目所属组织
		/// </summary>
		public string CI_Org_Code
		{
			set{ _ci_org_code=value;}
			get{return _ci_org_code;}
		}
		/// <summary>
		/// 薪酬项目类型代码
		/// </summary>
		public string CI_CT_Code
		{
			set{ _ci_ct_code=value;}
			get{return _ci_ct_code;}
		}
		#endregion Model

	}
}

