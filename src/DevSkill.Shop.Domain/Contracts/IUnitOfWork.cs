using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
