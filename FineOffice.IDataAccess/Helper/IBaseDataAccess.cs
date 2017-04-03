using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;

namespace FineOffice.IDataAccess.Helper
{
    public interface IBaseDataAccess<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>     
        /// 新增      
        /// </summary>     
        /// <param name="entity"></param>      
        TEntity Add(TEntity entity);

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="TEntities"></param>
        /// <returns></returns>
        void Add(List<TEntity> TEntities);

        /// <summary>     
        /// 修改      
        /// </summary>     
        /// <param name="entity"></param> 
        TEntity Update(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="where"></param>
        void Delete(Expression<Func<TEntity, bool>> where);

        /// <summary>     
        /// 按表达式获取一个数据     
        /// </summary>     
        /// <returns></returns>     
        TEntity Get(Expression<Func<TEntity, bool>> expression);

        /// <summary>     
        /// 获取所有数据     
        /// </summary>     
        /// <returns></returns>     
        IQueryable<TEntity> GetListAll();
        
        /// <summary>     
        /// 获取Table
        /// </summary>     
        /// <returns></returns>     
        Table<TEntity> GetTable();

        /// <summary>     
        /// 根据指定的查询条件     
        /// </summary>     
        /// <param name="expression">查询条件</param>     
        /// <returns></returns>     
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression);

        /// <summary>     
        /// 根据指定条件查询分页数据     
        /// </summary>    
        /// /// <typeparam name="TOrderType">排序类型</typeparam>     
        /// <param name="expression">查询条件</param>     
        /// <param name="orderPropertyName">排序字段</param>     
        /// <param name="isAscOrder">是否是升序查询</param>    
        /// <param name="pgIndex"></param>     
        /// <param name="pgSize"></param>     
        /// <param name="total">总记录数</param>     
        /// <returns></returns> 
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> expression,
            System.Linq.Expressions.Expression<Func<TEntity, bool>> selectKey, bool isAscending, int pgIndex, int pgSize, out int total);

        /// <summary>
        /// 初始化类
        /// </summary>
        void Initialization();

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<TEntity> Update(List<TEntity> list);

        /// <summary>
        /// 释放资源
        /// </summary>
        new void Dispose();
    }
}
