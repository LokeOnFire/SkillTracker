using MongoDB.Bson;
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
                    Id= ObjectId.GenerateNewId().ToString(),
                    Name = "HTMLCSSJavascrpt",
                    Ranking = "18"
                },
                new Skill()
                {
                    Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Angular",
                    Ranking = "18"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "React",
                    Ranking = "15"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Spring",
                    Ranking = "15"
                },
                new Skill()
                {
                     Id= ObjectId.GenerateNewId().ToString(),
                    Name = "RestFul",
                    Ranking = "12"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Hibernate",
                    Ranking = "11"
                }
                ,
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "GIT",
                    Ranking = "11"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Docker",
                    Ranking = "8"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Jenkins",
                    Ranking = "7"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "AWS",
                    Ranking = "5"
                },
                new Skill()
                {
                      Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Spoken",
                    Ranking = "18"
                },
                new Skill()
                {
                       Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Communication",
                    Ranking = "18"
                },
                new Skill()
                {
                      Id= ObjectId.GenerateNewId().ToString(),
                    Name = "Aptitude",
                    Ranking = "15"
                }

            };
        }

        private static IEnumerable<AssociateSkill> GetPreconfiguredAssociateSkills()
        {
            return new List<AssociateSkill>()
           {
               new AssociateSkill()
               {
                      Id= ObjectId.GenerateNewId().ToString(),
                   Name="Lokesh",
                   AssociateID="209656",
                   SkillID="1",
                   MobileNumber="9606035543",
                   email="lokesh@gmail.com"

               },
               new AssociateSkill()
               {
                     Id= ObjectId.GenerateNewId().ToString(),
                   Name="Amru",
                   AssociateID="209655",
                   SkillID="1",
                   MobileNumber="9606035542",
                   email="Amru@gmail.com"

               },
               new AssociateSkill()
               {
                     Id= ObjectId.GenerateNewId().ToString(),
                   Name="Loke1",
                   AssociateID="209654",
                   SkillID="1",
                   MobileNumber="9606035541",
                   email="Lok1@gmail.com"

               },
               new AssociateSkill()
               {
                     Id= ObjectId.GenerateNewId().ToString(),
                   Name="Loke3",
                   AssociateID="209651",
                   SkillID="1",
                   MobileNumber="9606035549",
                   email="Lok3@gmail.com"

               },
               new AssociateSkill()
               {
                     Id= ObjectId.GenerateNewId().ToString(),
                   Name="Loke2",
                   AssociateID="209653",
                   SkillID="1",
                   MobileNumber="9606035540",
                   email="Lok2@gmail.com"

               },
           };
        }
    }
}