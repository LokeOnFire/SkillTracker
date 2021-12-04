using MongoDB.Bson;
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

            try
            {
                //var updateResult = await _context
                //.AssociateSkills
                //.ReplaceOneAsync(filter: g => g.Id == associateskill.Id, replacement: associateskill);
                await _context.AssociateSkills.DeleteOneAsync(f => f.Id == associateskill.Id);


                await _context.AssociateSkills.InsertOneAsync(associateskill);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }


    }
}
