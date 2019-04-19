using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.IBLL
{
	public interface IBaseService<T> where T:class,new()
	{


		bool Add(T entity);
		bool Delete(T entity);
		IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);
		IQueryable<T> GetPageEntities<S>(out int total, int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, int>> orderLambda, bool isAsc);
		bool Update(T entity);
	}
}
