using SkillAddAPI.Data;
using SkillAddAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillAddAPI.Repositories
{
    public class SkillAddRepository : ISkillAddRepository
    {
        private readonly ISkillAddContext _context;

        public SkillAddRepository(ISkillAddContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddSkill(AssociateSkill associateskill)
        {
            await _context.AssociateSkills.InsertOneAsync(associateskill);
        }
    }
}
