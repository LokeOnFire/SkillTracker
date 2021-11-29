using MongoDB.Driver;
using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;

namespace SkillSearchAPI.Data
{
    public class SeedInitialData
    {
        public static void SeedData(IMongoCollection<AssociateSkill> associateSkills, IMongoCollection<Skill> skills)
        {

            bool existSkills = skills.Find(s => true).Any();

            if (!existSkills)
            {
                skills.InsertManyAsync(GetPreconfiguredSkills());
            }

            bool existAssociateSkills = associateSkills.Find(s => true).Any();

            if(!existAssociateSkills)
            {
                associateSkills.InsertManyAsync(GetPreconfiguredAssociateSkills());
            }

        }

        private static IEnumerable<Skill> GetPreconfiguredSkills()
        {
            return new List<Skill>()
            {
                new Skill()
                {
                    Id="1",
                    Name = "HTML",
                    Ranking = "25"
                },
                new Skill()
                {
                    Id="2",
                    Name = "Reactjs",
                    Ranking = "35"
                }
            };
        }

        private static IEnumerable<AssociateSkill> GetPreconfiguredAssociateSkills()
        {
            return new List<AssociateSkill>()
           {
               new AssociateSkill()
               {
                   Id = "1",
                   Name="Lokesh",
                   AssociateID="209656",
                   SkillID="1",
                   MobileNumber="9606035543",
                   email="lokesh@gmail.com"

               },
               new AssociateSkill()
               {
                   Id = "2",
                   Name="Lokesh",
                   AssociateID="209656",
                   SkillID="2",
                   MobileNumber="9606035543",
                   email="lokesh@gmail.com"

               }
           };
        }
    }
}