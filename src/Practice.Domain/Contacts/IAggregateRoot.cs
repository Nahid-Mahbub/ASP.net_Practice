using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Contacts
{
    public interface IAggregateRoot <TKey>
    {
        TKey Id { get; set; }
    }
}
