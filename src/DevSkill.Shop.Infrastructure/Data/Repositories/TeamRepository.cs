using DevSkill.Shop.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Application.Features.Teams;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class TeamRepository : Repository<Team, int>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
