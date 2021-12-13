using System.Threading.Tasks;
using Application.Common.Responses;
using Application.Common.Responses.SampleSwaggerResponses;
using Application.Payment.Commands;
using Application.Payment.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.V0.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v0.0")]
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Create Payment
        /// </summary>
        [HttpPost]
        [Route("create")]
        [Consumes("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Create Payment", typeof(PaymentResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ValidationResultResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePaymentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        ///     Get Payment with related order
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get")]
        [Consumes("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Payment", typeof(PaymentResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(ValidationResultResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<object> Get(GetPaymentQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}