using Pstoh.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.EFDAL
{
	/// <summary>
	/// 本类用于封装所有dal增删改查方法
	/// </summary>
	public class BaseDal <T> : IBaseDal<T> where T : class, new()
	{
		public DbContext Db { get { return DbContextFactory.GetCurrentDbContext(); } }
		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="whereLambda"></param>
		/// <returns></returns>
		public IQueryable<T> GetEntities(Expression<Func<T,bool>> whereLambda)
		{
			return Db.Set<T>().Where(whereLambda).AsQueryable();
		}
		/// <summary>
		/// 分页查询
		/// </summary>
		/// <param name="total"></param>
		/// <param name="pageSize"></param>
		/// <param name="pageIndex"></param>
		/// <param name="whereLambda"></param>
		/// <param name="orderLambda"></param>
		/// <param name="isAsc"></param>
		/// <returns></returns>
		public IQueryable<T> GetPageEntities<S>(out  int total,int pageSize,int pageIndex,
			Expression<Func<T,bool>> whereLambda,
			Expression<Func<T, int>> orderLambda,
			bool isAsc)
		{
			total = Db.Set<T>().Where(whereLambda).Count();
			IQueryable<T> tmp = Db.Set<T>().Where(whereLambda);
			if (isAsc)
			{
				tmp = tmp.OrderBy(orderLambda);
			}
			else
			{
				tmp = tmp.OrderByDescending(orderLambda);
			}
			tmp.Skip(pageSize * (pageIndex - 1))
				.Take(pageSize)
				.AsQueryable();
			return tmp;
		}
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool Add(T entity)
		{
			Db.Set<T>().Add(entity);
			//return Db.SaveChanges() > 0;
			return true;
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool Update(T entity)
		{
			Db.Entry<T>(entity).State = EntityState.Modified;
			//return Db.SaveChanges() > 0;
			return true;
		}
		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public bool Delete(T entity)
		{
			//Db.Entry<T>(entity).State = EntityState.Deleted;
			//return Db.SaveChanges() > 0;
			Db.Entry<T>(entity).Property("DelFlag").OriginalValue = (short)OA.Model.Enum.DelFlagEnum.Deleted;
			Db.Entry<T>(entity).Property("DelFlag").IsModified = true;
			return true;
		}

		public bool Delete(int id)
		{
			var entity = Db.Set<T>().Find(id);
			Db.Entry<T>(entity).Property("DelFlag").OriginalValue = (short)OA.Model.Enum.DelFlagEnum.Deleted;
			Db.Entry<T>(entity).Property("DelFlag").IsModified = true;
			return true;
		}

		public int DeleteListByIds(List<int> idList)
		{
			foreach (var item in idList)
			{
				Delete(item);
			}
			return idList.Count();
		}
	}
}
