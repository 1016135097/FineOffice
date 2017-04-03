using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.IDataAccess.Helper;

namespace FineOffice.IDataAccess
{
    public interface CRM_Area : IBaseDataAccess<FineOffice.Entity.CRM_Area>
    {
        /// <summary>
        /// 返回其所有子对象的数组包括其本身
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        List<Entity.CRM_Area> GetSubList(Entity.CRM_Area e);
    }
}
