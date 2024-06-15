using Microsoft.AspNetCore.Mvc;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;
using System.Net.Mime;

namespace Stock.Management.Api.Controllers
{
    public class CustomerInvestmentController(ICustomerInvestmentService customerInvestmentService) : MainController
    {
        private readonly ICustomerInvestmentService _customerInvestmentService = customerInvestmentService;

        [HttpPost("CustomerInvestment/Post")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async ValueTask<ActionResult> PostAsync([FromBody] CustomerInvestmentDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var serviceResult = await _customerInvestmentService.CreateCustomerInvestmentAsync(productDto);

            return CustomResponse(serviceResult, productDto);
        }


        /// <summary>
        /// Busca os investimentos de um usuário. 
        /// </summary>
        [HttpGet("CustomerInvestment/Get/id")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ServiceResult<CustomerInvestmentGetDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async ValueTask<ActionResult> GetByAsync(int customerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var serviceResult = await _customerInvestmentService.GetInvestmentByCustomerIdAsync(customerId);
            if (serviceResult.Success)
                return Ok(serviceResult.Result);

            return BadRequest(serviceResult.Result);
        }
    }
}
