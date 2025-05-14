using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Business.Features.CQRS.Queries.Category;
    using Business.Features.CQRS.Commands.Category;
    using Business.Service.Contracts;

    public class CategoryController : BaseController
    {
        #region Constructor
        public CategoryController(
            IMediator mediator,
            IValidatorService validatorService
        ):base(mediator, validatorService)
        {
            
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
