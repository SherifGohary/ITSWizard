using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ITS.Wizard.Repositories
{
    public class BaseRepository<TEntity, TEntityIdentity> where TEntity : class
    {
        private DbContext _context;
        public BaseRepository(DbContext context)
        {
			this.Context = context;
		}

		public long GetCount()
		{
			var result = this.Entities.LongCount();
			return result;
		}
		public long GetCount(Expression<Func<TEntity, bool>> expression)
		{
			var result = this.Entities.LongCount(expression);
			return result;
		}

		public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition = null)
		{
			var result = this.Entities.AsQueryable();

			if (condition != null)
			{
				result = result.Where(condition);
			}

			return result;
		}
		public TEntity Get(TEntityIdentity id)
		{
			var result = this.Entities.Find(id);
			return result;
		}

		public virtual TEntity Add(TEntity entity)
		{
			if (entity != null)
			{
				this.Context.Entry<TEntity>(entity).State = EntityState.Added;
			}
			return entity;
		}

		public TEntity Update(TEntity entity)
		{
			if (entity != null)
			{
				this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
			}
			return entity;
		}

		public void Delete(TEntity entity)
		{
			if (entity != null)
			{
				this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
			}
		}

		public int Delete(TEntityIdentity id)
		{
			var entity = this.Entities.Find(id);

			if (entity == null)
				return 0;

			this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;

			return 1;
		}

		protected DbContext Context
		{
			get { return this._context; }
			private set
			{
				this._context = value;
				this.Entities = this._context.Set<TEntity>();
			}
		}
		protected DbSet<TEntity> Entities { get; private set; }
	}
}

