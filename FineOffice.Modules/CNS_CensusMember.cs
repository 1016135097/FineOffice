using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class CNS_CensusMember : BaseModule
    {   
        public int ID { set; get; }

        /// <summary>
        /// 户号
        /// </summary>
        public string RegisterNO { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { set; get; }

        /// <summary>
        /// 与户主关系
        /// </summary>
        public string Relation { set; get; }

        /// <summary>
        /// 曾用名
        /// </summary>
        public string OtherName { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public System.Nullable<short> Sex { set; get; }

        /// <summary>
        /// 出生地
        /// </summary>
        public string PlaceOfBirth { set; get; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nationalilty { set; get; }

        /// <summary>
        /// 祖籍
        /// </summary>
        public string PlaceOfAncestral { set; get; }
        
        /// <summary>
        /// 出生日期
        /// </summary>
        public System.Nullable<System.DateTime> Brithday { set; get; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 宗教信养
        /// </summary>
        public string Religion { set; get; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { set; get; }

        /// <summary>
        /// 身高
        /// </summary>
        public string Height { set; get; }

        /// <summary>
        /// 血型
        /// </summary>
        public string TypeOfBlood { set; get; }

        /// <summary>
        /// 文化程度
        /// </summary>
        public System.Nullable<int> EducationID { set; get; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marriage { set; get; }

        /// <summary>
        /// 兵役状况
        /// </summary>
        public string MilitaryService { set; get; }

        /// <summary>
        /// 服务处所
        /// </summary>
        public string Company { set; get; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { set; get; }

        /// <summary>
        /// 政治面目
        /// </summary>
        public System.Nullable<int> PoliticalID { set; get; }

        /// <summary>
        /// 迁入日期
        /// </summary>
        public System.Nullable<System.DateTime> IngoingDate { set; get; }

        /// <summary>
        /// 原住地
        /// </summary>
        public string PreviousAddress { set; get; }

        /// <summary>
        /// 迁入原因
        /// </summary>
        public string IngoingReason { set; get; }

        /// <summary>
        /// 迁出日期
        /// </summary>
        public System.Nullable<System.DateTime> MoveOutDate { set; get; }

        /// <summary>
        /// 迁出到
        /// </summary>
        public string MoveToAddress { set; get; }

        /// <summary>
        /// 是否注销
        /// </summary>
        public System.Nullable<bool> IsCanceled { set; get; }

        /// <summary>
        /// 注销日期
        /// </summary>
        public System.Nullable<System.DateTime> CancelDate { set; get; }

        /// <summary>
        /// 注销原因
        /// </summary>
        public string CancelReason { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

        /// <summary>
        /// 文化程度
        /// </summary>
        public string Education { set; get; }

        /// <summary>
        /// 户别
        /// </summary>
        public string CensusTypeName { set; get; }

        /// <summary>
        /// 政治面目
        /// </summary>
        public string Political { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { set; get; }

        /// <summary>
        /// 户主
        /// </summary>
        public string HouseHolder { set; get; }

        /// <summary>
        /// 年龄
        /// </summary>
        public System.Nullable<int> Age { set; get; }
    }
}
