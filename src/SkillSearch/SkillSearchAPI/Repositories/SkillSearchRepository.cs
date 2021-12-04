using MongoDB.Bson;
using MongoDB.Driver;
using SkillSearchAPI.Data;
using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Repositories
{
    public class SkillSearchRepository : ISkillSearchRepository
    {
        private readonly ISkillSearchContext _context;
        public SkillSearchRepository(ISkillSearchContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<AssociateSkill>> SearchAssociateByName(string name)
        {
            int len = name.Length;

            FilterDefinition<AssociateSkill> filter = Builders<AssociateSkill>.Filter.Eq(p => p.Name, name);

            var result = _context
                    .AssociateSkills
                    .Find(filter)
                    .ToListAsync();

            return await result;
        }

        public async Task<IEnumerable<AssociateSkill>> SearchAssociateById(string associteid)
        {
            FilterDefinition<AssociateSkill> filter = Builders<AssociateSkill>.Filter.Eq(p => p.AssociateID, associteid);

            return await _context
                    .AssociateSkills
                    .Find(filter)
                    .ToListAsync();
        }

        public async Task<IEnumerable<AssociateSkill>> SearchAssociateBySkill(string skill)
        {
            FilterDefinition<AssociateSkill> filter = Builders<AssociateSkill>.Filter.Eq(p => p.SkillID, skill);

            return await _context
                    .AssociateSkills
                    .Find(filter)
                    .ToListAsync();
        }

        public async Task<IEnumerable<AssociateSkill>> GetAllDetails()
        {
            return await _context
                    .AssociateSkills
                    .Find(p => true)
                    .ToListAsync();
                    
                    
        }

        public async Task<AssociateSkill> SearchAssociateByPrimaryId(string id)
        {
            FilterDefinition<AssociateSkill> filter = Builders<AssociateSkill>.Filter.Eq(p => p.Id, id);

            return await _context
                    .AssociateSkills
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        //public Task<bool> upate(AssociateSkill associateskill)
        // {
        //     var updateResult = await _context.AssociateSkills.ReplaceOneAsync(filter: g => g.AssociateID, replacement: associateskill);
        //     return updateResult.IsAcknowledged && updateResult.modifiedCount > 0;
        // }
    }
}
