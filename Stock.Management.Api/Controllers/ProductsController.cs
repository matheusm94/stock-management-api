using Microsoft.AspNetCore.Mvc;
using Stock.Management.Api.Models;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;
using System.Net.Mime;

namespace Stock.Management.Api.Controllers;

public class ProductsController(IProductService productService): ControllerBase
{
    private readonly IProductService _productService = productService;

    /// <summary>
    /// Busca todos os produtos do portifólio. 
    /// </summary>

    [HttpGet("get")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ServiceResult<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<ActionResult> GetAsync()
    {
        var serviceResult = await _productService.GetProductsAsync();
        if(serviceResult.Success)
            return Ok(serviceResult.Result);

        return BadRequest(serviceResult.Result);
    }
}
