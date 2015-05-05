using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace PC.Common
{
    public class ExcelHelper
    {
        public static System.Data.DataTable ExcelToDataTableByOLEDB(string sheetName, string fileName, bool isFirstRowColumn)
        {
            //针对Excel不同版本请参考下表使用不同的OLE DB接口参数
            //Office Version	  Provider	                Provider_String
            //Office 97 ~2005	  Microsoft.Jet.OLEDB.4.0	Excel 5.0
            //Office 2007	  Microsoft.ACE.OLEDB.12.0	Excel 12.0[需安装组件或打ServicePack 1.0]
            //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。
            //      "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
            string strSql = "SELECT * FROM [Sheet1$]";
            string strConn = string.Empty;

            //系统和OFFICE和项目输出X86和X64问题，死活无法读取xlsx文件（必须打开文件在读取）
            if (fileName.ToLower().IndexOf(".xlsx") > 0) // 2007版本
                //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
            else if (fileName.ToLower().IndexOf(".xls") > 0) // 2003版本
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            else
                return null;
            DataSet ds = new DataSet();
            using (OleDbDataAdapter da = new OleDbDataAdapter(strSql, strConn))
            {
                try
                {
                    da.Fill(ds);
                    return ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
        }


        public static System.Data.DataTable ExcelToDataTableByNPOI(string sheetName, string fileName, bool isFirstRowColumn)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            DataTable data = new DataTable("Table");
            int startRow = 0;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    sheet.ForceFormulaRecalculation = true;
                    //IRow firstRow = sheet.GetRow(2);
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue.Trim();
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null

                        DataRow dr = data.NewRow();
                        foreach (ICell item in row.Cells)
                        {
                            switch (item.CellType)
                            {
                                case CellType.Boolean:
                                    dr[item.ColumnIndex] = item.BooleanCellValue;
                                    break;
                                //case CellType.Error:
                                //    dr[item.ColumnIndex] = ErrorEval.GetText(item.ErrorCellValue);
                                //    break;
                                case CellType.Formula:
                                    switch (item.CachedFormulaResultType)
                                    {
                                        case CellType.Boolean:
                                            dr[item.ColumnIndex] = item.BooleanCellValue;
                                            break;
                                        //case CellType.Error:
                                        //    dr[item.ColumnIndex] = ErrorEval.GetText(item.ErrorCellValue);
                                        //    break;
                                        case CellType.Numeric:
                                            if (DateUtil.IsCellDateFormatted(item))
                                            {
                                                dr[item.ColumnIndex] = item.DateCellValue.ToString("yyyy-MM-dd hh:MM:ss");
                                            }
                                            else
                                            {
                                                dr[item.ColumnIndex] = item.NumericCellValue;
                                            }
                                            break;
                                        case CellType.String:
                                            string str = item.StringCellValue;
                                            if (!string.IsNullOrEmpty(str))
                                            {
                                                dr[item.ColumnIndex] = str.ToString();
                                            }
                                            else
                                            {
                                                dr[item.ColumnIndex] = null;
                                            }
                                            break;
                                        case CellType.Unknown:
                                        case CellType.Blank:
                                        default:
                                            dr[item.ColumnIndex] = string.Empty;
                                            break;
                                    }
                                    break;
                                case CellType.Numeric:
                                    if (DateUtil.IsCellDateFormatted(item))
                                    {
                                        dr[item.ColumnIndex] = item.DateCellValue.ToString("yyyy-MM-dd hh:MM:ss");
                                    }
                                    else
                                    {
                                        dr[item.ColumnIndex] = item.NumericCellValue;
                                    }
                                    break;
                                case CellType.String:
                                    string strValue = item.StringCellValue;
                                    if (!string.IsNullOrEmpty(strValue))
                                    {
                                        dr[item.ColumnIndex] = strValue.ToString();
                                    }
                                    else
                                    {
                                        dr[item.ColumnIndex] = null;
                                    }
                                    break;
                                case CellType.Unknown:
                                case CellType.Blank:
                                default:
                                    dr[item.ColumnIndex] = string.Empty;
                                    break;
                            }
                        }
                        data.Rows.Add(dr);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;//Console.WriteLine("Exception: " + ex.Message);
                //return null;
            }
        }
    }
}
