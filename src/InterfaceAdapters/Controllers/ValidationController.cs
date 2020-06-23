using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EnterpriseBusinessRules.Entities;
using ApplicationBusinessRules.Interfaces;
using Microsoft.Extensions.Logging;

namespace InterfaceAdapters.Controllers
{
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IValidationService _validationService;       

        public ValidationController(ILoggerFactory logFactory, IValidationService validationService)
        {
            this._logger = logFactory.CreateLogger<ValidationController>();
            this._validationService = validationService;            
        }

        [HttpPost]
        [Route("v1/validations/password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "v1")]
        public IActionResult ValidatePassword([FromBody] PasswordEntity password)
        {       
            var response = this
                ._validationService
                .ValidatePassword(password);
            if (response.HasErrors()) {
                return UnprocessableEntity(response);
            }
            return Ok(response); 
        }
    }
}
