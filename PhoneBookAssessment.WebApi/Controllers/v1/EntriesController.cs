using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookAssessment.Application.Interfaces.Repositories;
using PhoneBookAssessment.WebApi.Models.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookAssessment.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IEntryRepositoryAsync _entryRepositoryAsync;
        private readonly ILogger<EntriesController> _logger;
        public EntriesController(IEntryRepositoryAsync entryRepositoryAsync,
            ILogger<EntriesController> logger)
        {
            _entryRepositoryAsync = entryRepositoryAsync;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateEntryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var results = await _entryRepositoryAsync.CreateEntry(request.Name, request.PhoneNumber, request.PhoneBookId);
                return StatusCode(201,results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
