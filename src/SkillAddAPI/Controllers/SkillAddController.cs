using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillAddAPI.Entities;
using SkillAddAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkillAddAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]/api/vi/engineer/add-profile")]
    public class SkillAddController : ControllerBase
    {
        private readonly ISkillAddRepository _repository;
        private readonly ILogger<SkillAddController> _logger;

        public SkillAddController(ISkillAddRepository repository, ILogger<SkillAddController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost]
        [ProducesResponseType(typeof(AssociateSkill),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> AddSkill([FromBody] AssociateSkill associateskill)
        {
            await _repository.AddSkill(associateskill);
            return Ok();
        }
    }
}
