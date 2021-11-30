using MongoDB.Driver;
using SkillUpdateAPI.Data;
using SkillUpdateAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillUpdateAPI.Repositories
{
    public class SkillUpdateRepository : ISkillUpdateRepository
    {
        private readonly ISkillUpdateContext _context;
        public SkillUpdateRepository(ISkillUpdateContext  context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> SkillUpdate(AssociateSkill associateskill)
        {
            var updateResult = await _context
                .AssociateSkills
                .ReplaceOneAsync(filter: g => g.Id == associateskill.Id, replacement: associateskill);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
