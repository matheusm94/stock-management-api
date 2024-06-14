using Microsoft.AspNetCore.Mvc;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Controllers;
public class MainController : ControllerBase
{
    protected ActionResult CustomResponse<T>(ServiceResult requestResult, T param1, string param2 = null)
    {
        if (requestResult.Success)
            return Ok();

        return BadRequest(requestResult.ErrorMessage);
    }
}
