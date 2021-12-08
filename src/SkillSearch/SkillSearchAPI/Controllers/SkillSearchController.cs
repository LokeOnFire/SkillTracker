using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SkillSearchAPI.Entities;
using SkillSearchAPI.Repositories;
using SkillSearchAPI.Services;
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
        private readonly ISQSService _ISQSService;

        public SkillSearchController(ISkillSearchRepository repository, ILogger<SkillSearchController> logger, ISQSService ISQSService )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ISQSService = ISQSService ?? throw new ArgumentNullException(nameof(ISQSService));
        }

        [HttpGet]
        [Route("name/{name}")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAssociateByName(string name)
        {
            var result = await _repository.SearchAssociateByName(name);

            if(result !=null)
            {

                try
                {
                    var response = _ISQSService.SendMessageToSQSQueue(new MessageRequest() { Id = new Guid(), message = result });
                }
                catch(Exception ex)
                {
                    
                }
                
            }
           

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
        [Route("Primary/{id}")]
        [ProducesResponseType(typeof(IEnumerable<AssociateSkill>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AssociateSkill>>> GetAssociateByPrimaryId(string id)
        {
            var result = await _repository.SearchAssociateByPrimaryId(id);
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
