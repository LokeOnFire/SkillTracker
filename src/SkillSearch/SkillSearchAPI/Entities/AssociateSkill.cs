using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Entities
{
    public class AssociateSkill
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }


        public string AssociateID { get; set; }

 
        public string SkillID { get; set; }

  
        public string MobileNumber { get; set; }

 
        public string email { get; set; }
    }
}
