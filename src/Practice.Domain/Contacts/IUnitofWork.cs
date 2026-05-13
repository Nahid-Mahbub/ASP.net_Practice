using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Contacts
{
    public interface IUnitofWork
    {
        void Save();
        Task SaveAsync();
    }
}
