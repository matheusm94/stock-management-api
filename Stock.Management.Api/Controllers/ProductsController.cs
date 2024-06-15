using Microsoft.AspNetCore.Mvc;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;
using System.Net.Mime;

namespace Stock.Management.Api.Controllers;

public class ProductsController(IProductService productService) : MainController
{
    private readonly IProductService _productService = productService;

    /// <summary>
    /// Busca todos os produtos do portifólio. 
    /// </summary>
    [HttpGet("Products/Get")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ServiceResult<ProductGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<ActionResult> GetAsync()
    {
        var serviceResult = await _productService.GetProductsAsync();
        if (serviceResult.Success)
            return Ok(serviceResult.Result);

        return BadRequest(serviceResult.Result);
    }

    /// <summary>
    /// Busca um produto do portifólio pelo Id. 
    /// </summary>
    [HttpGet("Products/Get/id")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ServiceResult<ProductGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<ActionResult> GetByAsync(int Id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var serviceResult = await _productService.GetProductByIdAsync(Id);
        if (serviceResult.Success)
            return Ok(serviceResult.Result);

        return BadRequest(serviceResult.Result);
    }

    /// <summary>
    /// Cria um produto no portifólio
    /// </summary>
    /// <param name="productDto">
    /// Dados do produto.
    /// </param>
    [HttpPost("Products/Post")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<ActionResult> PostAsync([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var serviceResult = await _productService.CreateProductAsync(productDto);

        return CustomResponse(serviceResult, productDto);
    }

    /// <summary>
    /// Atualiza um produto no portifólio
    /// </summary>
    /// <param name="productDto">
    /// Dados do produto.
    /// </param>
    /// <param name="productId">
    /// </param>
    [HttpPut("Products/Put")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async ValueTask<ActionResult> UpdateAsync(int productId, [FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var serviceResult = await _productService.UpdateProductAsync(productId, productDto);

        return CustomResponse(serviceResult, productDto);
    }
}
