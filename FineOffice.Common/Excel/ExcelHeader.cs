using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FineOffice.Common.Excel
{
    /// <summary>
    /// 作者冯胜德
    /// 用于导出导入Excel时数据的映射
    /// </summary>
    [Serializable]
    public class ExcelHeader
    {
        private List<Mapping> _Mapping = new List<Mapping>();

        /// <summary>
        /// 映射值的转换
        /// </summary>
        public List<Mapping> Mapping
        {
            get { return _Mapping; }
            set { _Mapping = value; }
        }

        public string MappingTo { set; get; }
        public int Width { set; get; }
        public string HeaderText { set; get; }
        public string PropertyName { set; get; }
        public string DataType { set; get; }
        public string StringFormat { set; get; }

        public ExcelHeader()
        {

        }

        public ExcelHeader(string headerText, string propertyName, int width)
        {
            this.HeaderText = headerText;
            this.Width = width;
            this.PropertyName = propertyName;
        }
    }
}
