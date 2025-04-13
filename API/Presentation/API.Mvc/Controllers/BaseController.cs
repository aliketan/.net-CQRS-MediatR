using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Business.Service.Contracts;
    using Enums.ComplexTypes;
    using Utility.Results.Concrete;

    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        private readonly IValidatorService _validatorService;

        #region Constructor
        protected BaseController(
            IMediator mediator,
            IValidatorService validatorService
            )
        {
            _mediator = mediator;
            _validatorService = validatorService;
        }
        #endregion

        protected async Task<ValidationResult> GetValidationResult<T>(T command) where T : class
        {
            var validationResult = await _validatorService.GetValidator<T>().ValidateAsync(command);
            return !validationResult.IsValid
                ? new ValidationResult(validationResult.Errors)
                : new ValidationResult(null, ResultStatus.Success);
        }
    }
}
