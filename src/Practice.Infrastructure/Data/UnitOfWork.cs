using Microsoft.EntityFrameworkCore;
using Practice.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Infrastructure.Data
{
    public class UnitOfWork : IUnitofWork, IDisposable
    {
        private readonly DbContext _dbcontext;
        public UnitOfWork(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public void Save()
        {
             _dbcontext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
