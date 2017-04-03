using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using FineOffice.Common.Tool;
using System.Xml;

namespace FineOffice.Common.Excel
{
    public class ExcelHelper
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { set; get; }

        /// <summary>
        /// 应用程序名
        /// </summary>
        public string ApplicationName { set; get; }

        /// <summary>
        /// 介绍、简介
        /// </summary>
        public string Comments { set; get; }

        /// <summary>
        /// NPOI简单Demo，快速入门代码
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName"></param>
        /// <remarks>NPOI认为Excel的第一个单元格是：(0，0)</remarks>   
        public void ExportEasy(DataTable dtSource, string strFileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet();

            //填充表头
            HSSFRow dataRow = sheet.CreateRow(0);
            foreach (DataColumn column in dtSource.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }

            //填充内容
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dataRow = sheet.CreateRow(i + 1);
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                }
            }

            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
            sheet.Dispose();
            workbook.Dispose();
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param> 
        public MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = this.Author;
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle();
            HSSFDataFormat format = workbook.CreateDataFormat();

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];

            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }

            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 列头及样式
                    {
                        HSSFRow headerRow = sheet.CreateRow(0);
                        HSSFCellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        headerRow.Dispose();
                    }
                    #endregion
                    rowIndex = 1;
                }
                #endregion

                #region 填充内容
                HSSFRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(string.Format("{0:yyyy-MM-dd}", dateV));
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet.Dispose();
                workbook.Dispose();

                return ms;
            }
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param> 
        public MemoryStream Export(DataTable dtSource, string strHeaderText, List<ExcelHeader> list)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = this.Author;
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = Author;
                si.ApplicationName = ApplicationName;

                si.Comments = Comments;
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle();
            HSSFDataFormat format = workbook.CreateDataFormat();

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];

            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 1;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 列头及样式
                    {
                        HSSFRow headerRow = sheet.CreateRow(0);
                        HSSFCellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dtSource.Columns)
                        {
                            string columnName = string.Empty;
                            foreach (ExcelHeader eh in list)
                            {
                                if (column.ColumnName == eh.PropertyName)
                                {
                                    columnName = eh.HeaderText;
                                    break;
                                }
                            }
                            headerRow.CreateCell(column.Ordinal).SetCellValue(columnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion

                #region 填充内容
                HSSFRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(string.Format("{0:yyyy-MM-dd}", dateV));
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion
                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet.Dispose();
                workbook.Dispose();

                return ms;
            }
        }

        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>  
        public void Export(DataTable dtSource, string strHeaderText, List<ExcelHeader> list, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText, list))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            HSSFRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                HSSFCell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        public DataTable Import(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            HSSFRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        public DataTable Import(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            HSSFRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        private short GetXLColour(HSSFWorkbook workbook, System.Drawing.Color SystemColour)
        {
            short s = 0;
            HSSFPalette XlPalette = workbook.GetCustomPalette();
            HSSFColor XlColour = XlPalette.FindColor(SystemColour.R, SystemColour.G, SystemColour.B);
            if (XlColour == null)
            {
                if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 255)
                {
                    if (NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE < 64)
                    {
                        NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE = 64; NPOI.HSSF.Record.PaletteRecord.STANDARD_PALETTE_SIZE += 1;
                        XlColour = XlPalette.AddColor(SystemColour.R, SystemColour.G, SystemColour.B);
                    }
                    else { XlColour = XlPalette.FindSimilarColor(SystemColour.R, SystemColour.G, SystemColour.B); }
                    s = XlColour.GetIndex();
                }
            }
            else
                s = XlColour.GetIndex();
            return s;
        }

        #region FineOffice用到的操作

        /// <summary>
        /// ListToExcel
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="strFileName">文件保存路径</param>
        /// <param name="nameList">列头信息</param>
        public void ListToExcel<T>(List<T> list, string strHeaderText, string strFileName, List<ExcelHeader> hearderList)
        {
            //保存
            using (MemoryStream ms = this.Export<T>(list, strHeaderText, hearderList))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    ms.Flush();
                    ms.Position = 0;
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// BindingListToExcel
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="strFileName">文件保存路径</param>
        /// <param name="nameList">列头信息</param>
        public void ListToExcel<T>(BindingList<T> list, string strHeaderText, string strFileName, List<ExcelHeader> hearderList)
        {
            using (MemoryStream ms = this.Export<T>(list, strHeaderText, hearderList))
            {

                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    ms.Flush();
                    ms.Position = 0;
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// ListToMemoryStream
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="nameList">列头信息</param>
        public MemoryStream Export<T>(List<T> list, string strHeaderText, List<ExcelHeader> hearderList)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet(strHeaderText);

            #region 文件属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = this.Author;
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = Author;
                si.ApplicationName = ApplicationName;

                si.Comments = Comments;
                si.Title = strHeaderText;
                si.Subject = strHeaderText;
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion


            #region 列头及样式
            {
                HSSFRow headerRow = sheet.CreateRow(0);
                HSSFCellStyle headStyle = workbook.CreateCellStyle();
                headStyle.Alignment = CellHorizontalAlignment.CENTER;
                HSSFFont font = workbook.CreateFont();
                font.FontHeightInPoints = 10;
                font.Boldweight = 600;
                headStyle.SetFont(font);
                headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_GREEN.index;
                headStyle.FillPattern = CellFillPattern.SOLID_FOREGROUND;
                headStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_TURQUOISE.index;
                headStyle.BorderBottom = CellBorderType.THIN;
                headStyle.BorderLeft = CellBorderType.THIN;
                headStyle.BorderRight = CellBorderType.THIN;
                headStyle.BorderTop = CellBorderType.THIN;
                for (int i = 0; i < hearderList.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(hearderList[i].HeaderText);
                    headerRow.GetCell(i).CellStyle = headStyle;
                    sheet.SetColumnWidth(i, hearderList[i].Width * 40);//设置列宽
                }
                headerRow.Dispose();
            }
            #endregion

            int rowIndex = 1;
            HSSFRow dataRow;
            HSSFCellStyle style = workbook.CreateCellStyle();
            style.BorderBottom = CellBorderType.THIN;
            style.BorderLeft = CellBorderType.THIN;
            style.BorderRight = CellBorderType.THIN;
            style.BorderTop = CellBorderType.THIN;
            foreach (Object obj in list)
            {
                dataRow = sheet.CreateRow(rowIndex);
                PropertyInfo[] pis = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);//就是这个对象所有属性的集合
                if (pis != null)
                {
                    for (int j = 0; j < hearderList.Count; j++)
                    {
                        HSSFCell newCell = dataRow.CreateCell(j);
                        ExcelHeader eh = hearderList[j];
                        newCell.CellStyle = style;
                        foreach (PropertyInfo pi in pis)//针对每一个属性进行循环
                        {
                            if (eh.PropertyName.Equals(pi.Name))
                            {
                                object PropertyValue = pi.GetValue(obj, null);
                                if (PropertyValue != null)
                                {
                                    string drValue = PropertyValue.ToString();
                                    switch (PropertyValue.GetType().ToString())
                                    {
                                        case "System.String"://字符串类型
                                            newCell.SetCellValue(drValue);
                                            break;
                                        case "System.DateTime"://日期类型
                                            DateTime dateV;
                                            DateTime.TryParse(drValue, out dateV);
                                            if (eh.StringFormat != null)
                                                newCell.SetCellValue(string.Format(eh.StringFormat, dateV));
                                            else
                                                newCell.SetCellValue(string.Format("{0:yyyy-MM-dd}", dateV));
                                            break;
                                        case "System.Boolean"://布尔型
                                            bool boolV = false;
                                            bool.TryParse(drValue, out boolV);
                                            newCell.SetCellValue(boolV);
                                            break;
                                        case "System.Int16"://整型
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Byte":
                                            int intV = 0;
                                            int.TryParse(drValue, out intV);
                                            newCell.SetCellValue(intV);
                                            break;
                                        case "System.Decimal"://浮点型
                                        case "System.Double":
                                            double doubV = 0;
                                            double.TryParse(drValue, out doubV);
                                            newCell.SetCellValue(doubV);
                                            break;
                                        case "System.DBNull"://空值处理
                                            newCell.SetCellValue("");
                                            break;
                                        default:
                                            newCell.SetCellValue("");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                rowIndex++;
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet.Dispose();
            workbook.Dispose();
            return ms;
        }

        /// <summary>
        /// ListToMemoryStream
        /// </summary>
        /// <param name="list">数据源</param>
        /// <param name="nameList">列头信息</param>
        public MemoryStream Export<T>(BindingList<T> list, string strHeaderText, List<ExcelHeader> hearderList)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet(strHeaderText);

            #region 文件属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = this.Author;
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = Author;
                si.ApplicationName = ApplicationName;

                si.Comments = Comments;
                si.Title = strHeaderText;
                si.Subject = strHeaderText;
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion


            #region 列头及样式
            {
                HSSFRow headerRow = sheet.CreateRow(0);
                HSSFCellStyle headStyle = workbook.CreateCellStyle();
                headStyle.Alignment = CellHorizontalAlignment.CENTER;
                HSSFFont font = workbook.CreateFont();
                font.FontHeightInPoints = 10;
                font.Boldweight = 600;
                headStyle.SetFont(font);
                headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_GREEN.index;
                headStyle.FillPattern = CellFillPattern.SOLID_FOREGROUND;
                headStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_TURQUOISE.index;
                headStyle.BorderBottom = CellBorderType.THIN;
                headStyle.BorderLeft = CellBorderType.THIN;
                headStyle.BorderRight = CellBorderType.THIN;
                headStyle.BorderTop = CellBorderType.THIN;
                for (int i = 0; i < hearderList.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(hearderList[i].HeaderText);
                    headerRow.GetCell(i).CellStyle = headStyle;
                    sheet.SetColumnWidth(i, hearderList[i].Width * 40);//设置列宽
                }
                headerRow.Dispose();
            }
            #endregion

            int rowIndex = 1;
            HSSFRow dataRow;
            HSSFCellStyle style = workbook.CreateCellStyle();
            style.BorderBottom = CellBorderType.THIN;
            style.BorderLeft = CellBorderType.THIN;
            style.BorderRight = CellBorderType.THIN;
            style.BorderTop = CellBorderType.THIN;
            foreach (Object obj in list)
            {
                dataRow = sheet.CreateRow(rowIndex);
                PropertyInfo[] pis = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);//就是这个对象所有属性的集合
                if (pis != null)
                {
                    for (int j = 0; j < hearderList.Count; j++)
                    {
                        HSSFCell newCell = dataRow.CreateCell(j);
                        ExcelHeader eh = hearderList[j];
                        newCell.CellStyle = style;
                        foreach (PropertyInfo pi in pis)//针对每一个属性进行循环
                        {
                            if (eh.PropertyName.Equals(pi.Name))
                            {
                                object PropertyValue = pi.GetValue(obj, null);
                                if (PropertyValue != null)
                                {
                                    string drValue = PropertyValue.ToString();
                                    switch (PropertyValue.GetType().ToString())
                                    {
                                        case "System.String"://字符串类型
                                            newCell.SetCellValue(drValue);
                                            break;
                                        case "System.DateTime"://日期类型
                                            DateTime dateV;
                                            DateTime.TryParse(drValue, out dateV);
                                            if (eh.StringFormat != null)
                                                newCell.SetCellValue(string.Format(eh.StringFormat, dateV));
                                            else
                                                newCell.SetCellValue(string.Format("{0:yyyy-MM-dd}", dateV));
                                            break;
                                        case "System.Boolean"://布尔型
                                            bool boolV = false;
                                            bool.TryParse(drValue, out boolV);
                                            newCell.SetCellValue(boolV);
                                            break;
                                        case "System.Int16"://整型
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Byte":
                                            int intV = 0;
                                            int.TryParse(drValue, out intV);
                                            newCell.SetCellValue(intV);
                                            break;
                                        case "System.Decimal"://浮点型
                                        case "System.Double":
                                            double doubV = 0;
                                            double.TryParse(drValue, out doubV);
                                            newCell.SetCellValue(doubV);
                                            break;
                                        case "System.DBNull"://空值处理
                                            newCell.SetCellValue("");
                                            break;
                                        default:
                                            newCell.SetCellValue("");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                rowIndex++;
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            sheet.Dispose();
            workbook.Dispose();
            return ms;
        }

        /// <summary>
        /// 返回列头
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public List<ExcelHeader> GetHeaderList(string template)
        {
            XmlTextReader reader = new XmlTextReader(template);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            List<ExcelHeader> headerList = new List<ExcelHeader>();
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                ExcelHeader header = new ExcelHeader();
                if (node.Attributes["HeaderText"] != null)
                    header.HeaderText = node.Attributes["HeaderText"].Value;
                if (node.Attributes["PropertyName"] != null)
                    header.PropertyName = node.Attributes["PropertyName"].Value;
                if (node.Attributes["DataType"] != null)
                    header.DataType = node.Attributes["DataType"].Value;
                if (node.Attributes["StringFormat"] != null)
                    header.StringFormat = node.Attributes["StringFormat"].Value;
                if (node.Attributes["MappingTo"] != null)
                    header.MappingTo = node.Attributes["MappingTo"].Value;
                if (node.Attributes["Width"] != null)
                {
                    string width = node.Attributes["Width"].Value;
                    if (Regexlib.MatchInt(width))
                        header.Width = int.Parse(width);
                }
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    header.Mapping.Add(new Mapping
                    {
                        Original = subNode.Attributes["Original"].Value,
                        Target = subNode.Attributes["Target"].Value
                    });
                }
                headerList.Add(header);
            }
            return headerList;
        }

        /// <summary>
        /// 从excel导入数据到数组
        /// </summary>
        public List<T> Import<T>(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex, List<ExcelHeader> list)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = workbook.GetSheetAt(SheetIndex);
            List<T> resultList = new List<T>();
            HSSFRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                dict.Add(i, headerRow.GetCell(i).StringCellValue);
            }
            int rowCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i);
                Dictionary<string, object> valueMap = new Dictionary<string, object>();
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    ExcelHeader header = list.Find(f => f.HeaderText == dict[j]);
                    string value = row.GetCell(j) == null ? "" : row.GetCell(j).ToString();
                    if (header != null)
                    {
                        valueMap.Add(header.PropertyName, value);
                    }
                }
                resultList.Add(this.Create<T>(list, valueMap));
            }
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return resultList;
        }

        public T Create<T>(List<ExcelHeader> list, Dictionary<string, object> mapping)
        {
            T model = default(T);
            model = Activator.CreateInstance<T>();//产生一个新的泛型对象
            foreach (ExcelHeader header in list)
            {
                string value = "";
                if (mapping.ContainsKey(header.PropertyName))
                    value = mapping[header.PropertyName].ToString();
                string property = header.PropertyName;

                if (header.Mapping.Count > 0)
                {
                    value = header.Mapping.Find(s => s.Original == value).Target;
                    property = header.MappingTo;
                }
                PropertyInfo prop = model.GetType().GetProperty(property);
                try
                {
                    if (prop == null)
                        continue;

                    switch (header.DataType)
                    {
                        case "System.Decimal":
                            if (Regexlib.MatchDecimal(value))
                                prop.SetValue(model, Convert.ToDecimal(value), null);
                            break;
                        case "System.Int16":
                            if (Regexlib.MatchInt(value))
                                prop.SetValue(model, Convert.ToInt16(value), null);
                            break;
                        case "System.Int32":
                            if (Regexlib.MatchInt(value))
                                prop.SetValue(model, Convert.ToInt32(value), null);
                            break;
                        case "System.Boolean":
                            if (value != null && value.Length > 0)
                                prop.SetValue(model, Convert.ToBoolean(value), null);
                            break;
                        case "System.DateTime":
                            if (Regexlib.MatchDateTime(value))
                                prop.SetValue(model, Convert.ToDateTime(value), null);
                            break;
                        default:
                            prop.SetValue(model, value, null);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return model;
        }
        #endregion
    }
}