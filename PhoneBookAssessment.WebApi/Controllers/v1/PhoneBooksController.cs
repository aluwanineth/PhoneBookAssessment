using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookAssessment.Application.Dtos;
using PhoneBookAssessment.Application.Interfaces.Repositories;
using PhoneBookAssessment.WebApi.Models.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PhoneBookAssessment.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PhoneBooksController : ControllerBase
    {
        private readonly IPhoneBookRepositoryAsync _phoneBookRepositoryAsync;
        private readonly ILogger<PhoneBooksController> _logger;
        public PhoneBooksController(IPhoneBookRepositoryAsync phoneBookRepositoryAsync,
            ILogger<PhoneBooksController> logger)
        {
            _phoneBookRepositoryAsync = phoneBookRepositoryAsync;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<ActionResult<PhoneBookViewModel>> Get()
        {
            try
            {
                var results = await _phoneBookRepositoryAsync.GetPhoneBooks();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception Message: {0}, StackTrace: {1} InnerException: {2}",
                    ex.Message, ex.StackTrace, ex.InnerException));
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("SearchPhoneBookEntry")]
        public async Task<ActionResult<PhoneBookViewModel>> Get(int phoneBookId, string name)
        {
            try
            {
                var results = await _phoneBookRepositoryAsync.SearchPhoneBookEntry(name, phoneBookId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception Message: {0}, StackTrace: {1} InnerException: {2}",
                    ex.Message, ex.StackTrace, ex.InnerException));
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePhoneBookRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var results = await _phoneBookRepositoryAsync.CreatePhone(request.Name);
                return StatusCode((int)HttpStatusCode.Created,results);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception Message: {0}, StackTrace: {1} InnerException: {2}",
                    ex.Message, ex.StackTrace, ex.InnerException));
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal server error");
            }
        }
    }
}
