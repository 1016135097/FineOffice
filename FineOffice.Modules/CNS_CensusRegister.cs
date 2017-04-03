using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class CNS_CensusRegister : BaseModule
    {
        public int ID { set; get; }

        /// <summary>
        /// 户别  即户口类型
        /// </summary>
        public System.Nullable<int> CensusTypeID { set; get; }

        /// <summary>
        /// 户主
        /// </summary>
        public string HouseHolder { set; get; }

        /// <summary>
        /// 户号
        /// </summary>
        public string RegisterNO { set; get; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Habitation { set; get; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public System.Nullable<System.DateTime> IssuingDate { set; get; }

        /// <summary>
        /// 登记机关
        /// </summary>
        public string IssuingAuthority { set; get; }

        /// <summary>
        /// 户别
        /// </summary>
        public string CensusTypeName { set; get; }
        
        public string Remark { set; get; }
    }
}
