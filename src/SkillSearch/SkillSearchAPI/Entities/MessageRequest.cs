using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SkillSearchAPI.Entities
{
    public class MessageRequest
    {
        public Guid Id { get; set; }
        public IEnumerable<AssociateSkill> message { get; set; }

        public string Serialize(MessageRequest value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(value, options);
        }


    }
}
