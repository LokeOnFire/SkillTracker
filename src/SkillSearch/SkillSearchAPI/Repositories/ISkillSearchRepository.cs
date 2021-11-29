using SkillSearchAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillSearchAPI.Repositories
{
    public interface ISkillSearchRepository
    {
        Task<IEnumerable<AssociateSkill>> SearchAssociateByName(string name);
        Task<IEnumerable<AssociateSkill>> SearchAssociateById(string associteid);
        Task<IEnumerable<AssociateSkill>> SearchAssociateBySkill(string skill);

    }
}
