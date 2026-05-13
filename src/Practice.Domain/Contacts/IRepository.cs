using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Contacts
{
    public interface IRepository <TAggregateRoot, TKey>
        where TAggregateRoot : class, IAggregateRoot<TKey> 
        where TKey : IComparable // Comparable constraint to ensure TKey can be compared for equality and ordering
    {
        void Add(TAggregateRoot entity);
        Task AddAsync(TAggregateRoot entity);

    }
}
