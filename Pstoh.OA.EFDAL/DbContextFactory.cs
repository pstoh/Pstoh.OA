using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Pstoh.OA.EFDAL
{
	public abstract class DbContextFactory
	{
		public static DbContext GetCurrentDbContext()
		{
			DbContext db = CallContext.GetData("DbContext") as DbContext;
			if (db == null)
			{
				db = new OA.Model.OAEntities();
				CallContext.SetData("DbContext", db);
			}
			return db;
		}
	}
}
