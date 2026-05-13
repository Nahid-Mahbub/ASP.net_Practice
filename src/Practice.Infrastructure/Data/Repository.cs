using Microsoft.EntityFrameworkCore;
using Practice.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Practice.Infrastructure.Data
{
    public class Repository<TAggregateRoot, Tkey> : IRepository<TAggregateRoot, Tkey>, IDisposable
        where TAggregateRoot : class, IAggregateRoot<Tkey>
        where Tkey : IComparable
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TAggregateRoot> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TAggregateRoot>();
        }
        public void Add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TAggregateRoot entity)
        {
            await _dbSet.AddAsync(entity);
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
