using MultiShop.Data;
using Sieve.Services;

namespace MultiShop.Presentation
{
    public class SieveCustomSortMethods : ISieveCustomSortMethods
    {
        //public IQueryable<Product> Popularity(IQueryable<Product> source, bool useThenBy, bool desc) // The method is given an indicator of whether to use ThenBy(), and if the query is descending 
        //{
        //    var result = useThenBy ?
        //        ((IOrderedQueryable<Product>)source).ThenBy(p => p.LikeCount) : // ThenBy only works on IOrderedQueryable<TEntity>
        //        source.OrderBy(p => p.LikeCount)
        //        .ThenBy(p => p.CommentCount)
        //        .ThenBy(p => p.DateCreated);

        //    return result; // Must return modified IQueryable<TEntity>
        //}

        //public IQueryable<T> Oldest<T>(IQueryable<T> source, bool useThenBy, bool desc) where T : BaseEntity // Generic functions are allowed too
        //{
        //    var result = useThenBy ?
        //        ((IOrderedQueryable<T>)source).ThenByDescending(p => p.DateCreated) :
        //        source.OrderByDescending(p => p.DateCreated);

        //    return result;
        //}
    }

    public class SieveCustomFilterMethods : ISieveCustomFilterMethods
    {
        public IQueryable<Product> IsNew(IQueryable<Product> source, string op, string[] values) // The method is given the {Operator} & {Value}
        {
            var result = source;

            return result; // Must return modified IQueryable<TEntity>
        }

        public IQueryable<T> Latest<T>(IQueryable<T> source, string op, string[] values) where T : BaseEntity // Generic functions are allowed too
        {
            var result = source.Where(c => c.CrationDate > DateTimeOffset.UtcNow.AddDays(-14));
            return result;
        }
    }
}
