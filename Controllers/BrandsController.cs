using System.Runtime.CompilerServices;
using BrandsService.Requests;
using BrandsService.Services;
using BrandsService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrandsService.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly ILogger<BrandsController> _logger;
    private readonly IBrandsService _brandsService;

    public BrandsController(
        ILogger<BrandsController> logger, 
        IBrandsService brandsService)
    {
        _logger = logger;
        _brandsService = brandsService;
    }

    /// <summary>
    /// Получить все бренды
    /// </summary>
    /// <returns></returns>
    [HttpGet("")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var serviceResult = await _brandsService.GetBrands();
            if (serviceResult.Failures?.Count == 0)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<IActionResult> Create(CreateBrandRequest createBrandRequest)
    {
        try
        {
            var serviceResult = await _brandsService.CreateBrand(createBrandRequest);
            if (serviceResult.Failures?.Count == 0)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
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