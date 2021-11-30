using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SkillUpdateAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillUpdateAPI.Data
{
    public class SkillUpdateContext : ISkillUpdateContext
    {

        public SkillUpdateContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            AssociateSkills = database.GetCollection<AssociateSkill>(configuration.GetValue<string>("DatabaseSettings:AssociateCollectionName"));
        }

        public IMongoCollection<AssociateSkill> AssociateSkills { get; }
    }
}
