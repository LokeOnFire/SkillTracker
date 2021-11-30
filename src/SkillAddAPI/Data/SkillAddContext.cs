using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SkillAddAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillAddAPI.Data
{
    public class SkillAddContext : ISkillAddContext
    {
        public IMongoCollection<AssociateSkill> AssociateSkills { get; }

        public SkillAddContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            AssociateSkills = database.GetCollection<AssociateSkill>(configuration.GetValue<string>("DatabaseSettings:AssociateCollectionName"));
        }
    }
}
