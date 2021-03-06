namespace Hogwarts.Core.Repositories
{
    using System;
    using System.Collections.Generic;


    public class PagedElements<TEntity>
        where TEntity : class
    {
        public PagedElements(IEnumerable<TEntity> elements, int totalElements)
        {
            this.Elements = elements;
            this.TotalElements = totalElements;
        }

        public IEnumerable<TEntity> Elements
        {
            get;
            private set;
        }

        public int TotalElements
        {
            get;
            private set;
        }

        public int TotalPages(int pageSize)
        {
            return (int)Math.Ceiling(Convert.ToDouble(this.TotalElements) / pageSize);
        }
    }
}
