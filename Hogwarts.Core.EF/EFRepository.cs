namespace Hogwarts.Core.EF
{
    using System;
    using System.Linq;
    using Model;
    using Repositories;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class EFRepository<TEntity, TKey> : BaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private AuditableContext _dbContext;

        public EFRepository(AuditableContext dbContext, ILogger logger)
            : base(logger)
        {
            this._dbContext = dbContext;
        }

        protected override void InternalAdd(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        protected override void InternalAttach(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Attach(entity);
        }

        protected override void InternalModify(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        protected override void InternalRemove(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        protected override IQueryable<TEntity> Query()
        {
            return this._dbContext.Set<TEntity>();
        }

        protected override TEntity Load(TKey id)
        {
            return this._dbContext.Set<TEntity>().Find(id);

        }
        protected async override Task<TEntity> LoadAsync(TKey id)
        {
            return await this._dbContext.Set<TEntity>().FindAsync(id);

        }
    }
}
