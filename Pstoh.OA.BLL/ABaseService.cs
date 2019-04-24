using Pstoh.OA.DALFactory;
using Pstoh.OA.IBLL;
using Pstoh.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.BLL
{
	public abstract class ABaseService<T> : IBaseService<T> where T : class, new()
	{
		protected IBaseDal<T> CurrentDal { get; set; }
		public IDbSession DbSession { get { return DbSessionFactory.GetCurrentDbSession(); } }

		public ABaseService()
		{
			SetCurrentDal();
		}
		/// <summary>
		/// 设置DbSession
		/// </summary>
		protected abstract void SetCurrentDal();

		public bool Add(T entity)
		{
			 CurrentDal.Add(entity);
			return DbSession.SaveChange() > 0;
		}

		public bool Delete(T entity)
		{
		 CurrentDal.Delete(entity);
			return DbSession.SaveChange() > 0;
		}

		public IQueryable<T> GetEntities(Expression<Func<T,bool>> whereLambda)
		{
			return CurrentDal.GetEntities(whereLambda);
		}

		public IQueryable<T> GetPageEntities<S>(out int total, int pageSize, int pageIndex, Expression<Func<T,bool>> whereLambda, Expression<Func<T,int>> orderLambda, bool isAsc)
		{
			return CurrentDal.GetPageEntities<T>(out total, pageSize, pageIndex, whereLambda, orderLambda, isAsc);
		}

		public bool Update(T entity)
		{
			CurrentDal.Update(entity);
			 return DbSession.SaveChange() > 0;
		}

		public bool Delete(int id)
		{
			CurrentDal.Delete(id);
			return DbSession.SaveChange()>0;
		}

		public int DeleteListByIds(List<int> idList)
		{
			CurrentDal.DeleteListByIds(idList);
			return DbSession.SaveChange();
		}
	}
}
