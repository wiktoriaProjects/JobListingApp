using System.Linq.Expressions;

namespace JobListingApp.Domain.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count();
        void Delete(TEntity entity);
        IList<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity Get(int id);
        IList<TEntity> GetAll();
        void Insert(TEntity entity);
    }
}