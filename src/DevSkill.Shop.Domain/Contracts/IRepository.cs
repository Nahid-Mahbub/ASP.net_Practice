using System.Linq.Expressions;

namespace DevSkill.Shop.Domain.Contracts
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        TEntity? GetById(TKey id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}