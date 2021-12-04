using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillUpdateAPI.Entity;
using SkillUpdateAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkillUpdateAPI.Controllers
{
    [ApiController]
    [Route("[controller]/api/vi/engineer/update-profile")]
    public class SkillUpdateController : ControllerBase
    {

        private readonly ISkillUpdateRepository _repository;
        private readonly ILogger<SkillUpdateController> _logger;

        public SkillUpdateController(ISkillUpdateRepository repository, ILogger<SkillUpdateController> logger) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPut]
        [ProducesResponseType(typeof(AssociateSkill), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> UpdateSkill([FromBody] AssociateSkill associateskill)
        {
            await _repository.SkillUpdate(associateskill);
            return Ok();
        }

    }
}
