using SkillAddAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillAddAPI.Repositories
{
    public interface ISkillAddRepository
    {
        public Task AddSkill(AssociateSkill associateskill);
    }
}
