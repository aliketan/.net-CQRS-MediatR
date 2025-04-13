using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Mvc.Controllers
{
    using Business.Features.CQRS.Queries.Product;
    using Business.Features.CQRS.Commands.Product;
    using Business.Service.Contracts;

    public class ProductController : BaseController
    {
        #region Constructor
        public ProductController(
            IMediator mediator,
            IValidatorService validatorService
        ):base(mediator, validatorService)
        {
            
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            var validationResult = await GetValidationResult(command);
            if (!string.IsNullOrEmpty(validationResult.Response))
                return Ok(validationResult);

            bool result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
