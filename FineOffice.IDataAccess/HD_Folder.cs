using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.IDataAccess.Helper;

namespace FineOffice.IDataAccess
{
    public interface HD_Folder : IBaseDataAccess<FineOffice.Entity.HD_Folder>
    {
        /// <summary>
        /// 返回其所有子对象的数组包括其本身
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        List<Entity.HD_Folder> GetSubList(Entity.HD_Folder e);
    }
}
