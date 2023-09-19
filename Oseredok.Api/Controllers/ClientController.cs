using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oseredok.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oseredok.Api.Controllers
{
    [Route("/client")]
    [AllowAnonymous]
    public class ClientController : ApiController
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = _clientRepository.GetById(id).Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _clientRepository.GetAll().Result;

            return result.Match(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}