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

        [BsonElement("AssociateID")]
        public string AssociateID { get; set; }

        [BsonElement("SkillID")]
        public string SkillID { get; set; }

        [BsonElement("MobileNumber")]
        public string MobileNumber { get; set; }

        [BsonElement("email")]
        public string email { get; set; }
    }
}
