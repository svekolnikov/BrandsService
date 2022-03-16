using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace BrandsService.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly ILogger<BrandsController> _logger;

    public BrandsController(ILogger<BrandsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Получить все бренды
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public IActionResult GetAll()
    {
        return Ok();
    }

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <returns></returns>
    [HttpPost("")]
    public IActionResult Create()
    {
        return Ok();
    }

    /// <summary>
    /// Обновить бренд
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Update(long id)
    {
        return Ok();
    }

    /// <summary>
    /// Удалить бренд
    /// </summary>
    /// <param name="ind"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(long ind)
    {
        return Ok();
    }


    private void LogError(Exception e, [CallerMemberName] string methodName = null!)
    {
        _logger.LogError(e, "Error at {0}", methodName);
    }
}