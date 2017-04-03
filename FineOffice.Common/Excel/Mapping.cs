using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Common.Excel
{
    /// <summary>
    /// 作者冯胜德
    /// 用于导出导入Excel时数据的映射
    /// </summary>
    [Serializable]
    public class Mapping
    {
        public string Original { set; get; }
        public string Target { set; get; }
    }
}
