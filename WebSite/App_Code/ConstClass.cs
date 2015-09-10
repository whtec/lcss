using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Const 的摘要说明
/// </summary>
public class ConstClass
{
    public ConstClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 是否匹配
    /// </summary>
    public const string colMatch = "是否匹配";
    /// <summary>
    /// 固定列名-工号
    /// </summary>
    public const string colEmpCode = "工号";
    /// <summary>
    /// 固定列名-姓名
    /// </summary>
    public const string colEmpName = "姓名";
    /// <summary>
    /// 固定列名-序号
    /// </summary>
    public const string colRowNum = "序号";
    /// <summary>
    /// 固定列名-无效列
    /// </summary>
    public const string colInvalid = "无效列";
    /// <summary>
    /// 代码和显示名分隔符
    /// </summary>
    public const char colCutOff = '|';
    /// <summary>
    /// 应扣项标签
    /// </summary>
    public const string minusLabel = "CUT";
    /// <summary>
    /// 应扣项包含类型：扣减项,所得税
    /// </summary>
    public const string minusType = "扣减项,所得税";
    /// <summary>
    /// 应发颜色标签
    /// </summary>
    public const string greenLabel = "ADD";
    /// <summary>
    /// 应扣颜色标签
    /// </summary>
    public const string redLabel = "CUT";

}