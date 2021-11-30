using MongoDB.Driver;
using SkillAddAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillAddAPI.Data
{
    public interface ISkillAddContext
    {
        IMongoCollection<AssociateSkill> AssociateSkills { get; }

    }
}
