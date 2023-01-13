using AppEnvironment;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Repository
{
    public interface IBaseRepositoryService<T> where T : BaseEntity
    {
        Result<T> Add(T entity);
        Result<T> Update(T entity);
        Result Delete(T entity);
        Result<T> GetFirst(Expression<Func<T, bool>> whereCondition, Expression<Func<DbSet<T>, IQueryable<T>>>? makeJoins = null);
        IQueryable<T> Get(Expression<Func<T, bool>> whereCondition, Expression<Func<DbSet<T>, IQueryable<T>>>? makeJoins = null, bool pullFromDb = false);
    }
}
