using MongoDB.Driver;
using SkillUpdateAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillUpdateAPI.Data
{
    public interface ISkillUpdateContext
    {
        IMongoCollection<AssociateSkill> AssociateSkills { get; }
    }
}
