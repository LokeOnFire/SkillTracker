using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillSearchAPI.Entities;
using SkillSearchAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SkillSearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]/api/v1/admin/")]
    public class SkillSearchController : ControllerBase
    {
        private readonly ISkillSearchRepository _repository;
        private readonly ILogger<SkillSearchController> _logger;

        public SkillSearchController(ISkillSearchRepository repository, ILogger<SkillSearchController> logger )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("name/{name}")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAssociateByName(string name)
        {
            var result = await _repository.SearchAssociateByName(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("Id/{id}")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAssociateById(string Id)
        {
            var result = await _repository.SearchAssociateById(Id);
            return Ok(result);
        }

        [HttpGet]
        [Route("Skill/{skill}")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAssociateBySkill(string skill)
        {
            var result = await _repository.SearchAssociateBySkill(skill);
            return Ok(result);
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAllData()
        {
            var result = await _repository.GetAllDetails();
            return Ok(result);
        }


    }
}
