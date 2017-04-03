using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using FineOffice.IDataAccess.Helper;

namespace FineOffice.DataAccess.Helper
{
    /// <summary>
    /// 操作单个表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDataAccess<T> : IBaseDataAccess<T>, IQueryable<T> where T : class
    {
        private DataContext _context;//Linq 上下文
        private bool _submit = false;//是否执行提交

        #region IRepository<T> 成员
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            _context.GetTable<T>().InsertOnSubmit(entity);
            _submit = true;
            return entity;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        public virtual void Add(List<T> TEntities)
        {
            _context.GetTable<T>().InsertAllOnSubmit(TEntities);
            _submit = true;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="TEntities"></param>
        /// <returns></returns>
        public IQueryable<T> Add(IQueryable<T> TEntities)
        {
            _context.GetTable<T>().InsertAllOnSubmit(TEntities);
            _submit = true;
            return TEntities;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual T Update(T entity)
        {
            _context.GetTable<T>().Attach(entity, true);
            _submit = true;
            return entity;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual List<T> Update(List<T> list)
        {
            _context.GetTable<T>().AttachAll(list, true);
            _submit = true;
            return list;
        }

        /// <summary>     
        /// 按表达式获取一个数据     
        /// </summary>     
        /// <returns></returns>     
        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _context.GetTable<T>().Where<T>(expression).FirstOrDefault<T>();
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetListAll()
        {
            Table<T> list = _context.GetTable<T>();
            return list;
        }

        /// <summary>
        /// 获取table
        /// </summary>
        /// <returns></returns>
        public Table<T> GetTable()
        {
            Table<T> table = _context.GetTable<T>();
            return table;
        }

        /// <summary>     
        /// 按表达式获取数据     
        /// </summary>     
        /// <returns></returns>  
        public IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _context.GetTable<T>().Where<T>(expression);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> expression,
            System.Linq.Expressions.Expression<Func<T, bool>> selectKey, bool isAscending, int pgIndex, int pgSize, out int total)
        {
            total = 0;
            IQueryable<T> query = GetList(expression);
            if (isAscending)
                query = query.OrderBy(selectKey);
            //分页查询         
            if (pgSize > 0)
            {
                total = query.Count();//记录总数             
                query = query.Skip(pgIndex * pgSize).Take(pgSize);
            }
            return query;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            _context.GetTable<T>().Attach(entity, true);
            _context.GetTable<T>().DeleteOnSubmit(entity);
            _submit = true;
        }

        /// <summary>
        /// 按表达式删除
        /// </summary>
        /// <param name="expression"></param>
        public virtual void Delete(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            _context.GetTable<T>().DeleteAllOnSubmit<T>(GetList(expression));
            _submit = true;
        }

        /// <summary>
        /// 初始化类
        /// </summary>
        public void Initialization()
        {
            _context = ContextFactory.CreateContext();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_context == null) return;
            if (_submit) _context.SubmitChanges();

            _context.Dispose();
            _context = null;
        }

        #endregion

        /// <summary>
        /// IQueryable成员
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IQueryable成员
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// IQueryable成员
        /// </summary>
        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// IQueryable成员
        /// </summary>
        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }
}
