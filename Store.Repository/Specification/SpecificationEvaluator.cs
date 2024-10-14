using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Data.Entities;
using System.Linq;

namespace Store.Repository.Specification
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity:BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> specs)
        {
            var query = inputQuery;
            if (specs.Criteria is not null)
                query=query.Where(specs.Criteria);
            if (specs.OrderBy is not null)
                query=query.OrderBy(specs.OrderBy);
            if (specs.OrderByDescending is not null)
                query = query.OrderByDescending(specs.OrderByDescending);
            if (specs.IsPaginated)
                query = query.Skip(specs.Skip).Take(specs.Take);

            query = specs.Includes.Aggregate(query,(current,IncludeExpression)=>current.Include(IncludeExpression));
            return query;
        }
    }
}
