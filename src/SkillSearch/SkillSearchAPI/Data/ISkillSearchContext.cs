using MongoDB.Driver;
using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Data
{
    interface ISkillSearchContext
    {
        IMongoCollection<AssociateSkill> AssociateSkills { get; }
        IMongoCollection<Skill> Skills { get; }
    }
}
