using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Pstoh.OA.IDAL
{
	public interface IBaseDal<T> where T : class, new()
	{

		bool Add(T entity);
		bool Delete(T entity);
		bool Delete(int id);
		//删除
		int DeleteListByIds(List<int> idList);
		IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
		IQueryable<T> GetPageEntities<S>(out int total, int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, int>> orderLambda, bool isAsc);
		bool Update(T entity);
	}
}