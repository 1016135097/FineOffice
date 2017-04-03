using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class ADM_LetterChannel
    {
        FineOffice.IDataAccess.ADM_LetterChannel dal = new FineOffice.DataAccess.ADM_LetterChannel();
        /// <summary>
        /// 增加表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.ADM_LetterChannel Add(FineOffice.Modules.ADM_LetterChannel model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterChannel entity = new Entity.ADM_LetterChannel
            {
                ID = model.ID,
                Channel = model.Channel,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.ADM_LetterChannel Update(FineOffice.Modules.ADM_LetterChannel model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterChannel entity = new Entity.ADM_LetterChannel
            {
                ID = model.ID,
                Channel = model.Channel,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return GetModel(d => d.ID == model.ID);
        }

        /// <summary>
        /// 返回所有表单
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.ADM_LetterChannel> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_LetterChannel> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.ADM_LetterChannel
                 {
                     ID = entity.ID,
                     Channel = entity.Channel,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.ADM_LetterChannel GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_LetterChannel, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.ADM_LetterChannel model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.ADM_LetterChannel
                   {
                       ID = entity.ID,
                       Channel = entity.Channel,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.ADM_LetterChannel model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterChannel entity = new Entity.ADM_LetterChannel
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }


        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        /// <summary>
        /// 按表达查找表单的数组
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.ADM_LetterChannel> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_LetterChannel, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_LetterChannel> list = new List<Modules.ADM_LetterChannel>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.ADM_LetterChannel
                    {
                        ID = entity.ID,
                        Channel = entity.Channel,
                        Remark = entity.Remark
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }
    }
}
