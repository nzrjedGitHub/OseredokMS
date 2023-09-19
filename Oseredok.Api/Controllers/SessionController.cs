using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oseredok.Application.Common.Interfaces.Persistence;
using Oseredok.Shared.DTOs.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Api.Controllers
{
    [Route("/session")]
    [AllowAnonymous]
    public class SessionController : ApiController
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = _sessionRepository.GetById(id).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("GetAllByCoach/{coachId}")]
        public async Task<IActionResult> GetAllByCoach(Guid coachId)
        {
            var result = _sessionRepository.GetAllByCoach(coachId).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _sessionRepository.GetAll().Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPost("createSession")]
        public async Task<IActionResult> CreateSession(SessionCreateDto request)
        {
            var result = _sessionRepository.Add(request).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPost("updateSessionStatus")]
        public async Task<IActionResult> UpdateSessionStatus(SessionStatusUpdateDto request)
        {
            var result = _sessionRepository.UpdateSessionStatus(request).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpPost("updateSession")]
        public async Task<IActionResult> Update(SessionUpdateDto request)
        {
            var result = _sessionRepository.Update(request).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _sessionRepository.Delete(id).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}