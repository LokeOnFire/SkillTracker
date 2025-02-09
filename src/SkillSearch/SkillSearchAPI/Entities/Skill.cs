﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Entities
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
            
        [BsonElement("Name")]
        public string Name { get; set; }

 
        public string Ranking { get; set; }
    }
}
