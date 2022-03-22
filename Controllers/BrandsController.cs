using System.Runtime.CompilerServices;
using BrandsService.Requests;
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
    public async Task<IActionResult> GetAllBrandsAsync()
    {
        try
        {
            var serviceResult = await _brandsService.GetAllBrandsAsync();
            if (serviceResult.IsSuccess)
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
    /// Получить бренд по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandByIdAsync(int id)
    {
        try
        {
            var serviceResult = await _brandsService.GetBrandByIdAsync(id);
            if (serviceResult.IsSuccess)
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
    public async Task<IActionResult> CreateBrandAsync(CreateBrandRequest createBrandRequest)
    {
        try
        {
            var serviceResult = await _brandsService.CreateBrandAsync(createBrandRequest);
            if (serviceResult.IsSuccess)
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
    /// <param name="updateBrandRequest"></param>
    /// <returns></returns>
    [HttpPut("")]
    public async Task<IActionResult> UpdateBrandAsync(UpdateBrandRequest updateBrandRequest)
    {
        try
        {
            var serviceResult = await _brandsService.UpdateBrandAsync(updateBrandRequest);
            if (serviceResult.IsSuccess)
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
    /// Soft delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteBrandAsync(int id)
    {
        try
        {
            var serviceResult = await _brandsService.SoftDeleteBrandAsync(id);
            if (serviceResult.IsSuccess)
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
    /// Получить все размеры по бренду
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/allowed-sizes")]
    public async Task<IActionResult> GetAllSizesAsync(int id)
    {
        try
        {
            var serviceResult = await _brandsService.GetAllSizesByBrandIdAsync(id);
            if (serviceResult.IsSuccess)
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
    /// Создать размер в бренде
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="createSizeRequest"></param>
    /// <returns></returns>
    [HttpPost("{brandId}/allowed-sizes")]
    public async Task<IActionResult> CreateSizeAsync([FromQuery]int brandId, CreateSizeRequest createSizeRequest)
    {
        try
        {
            var serviceResult = await _brandsService.CreateSizeAsync(brandId, createSizeRequest);
            if (serviceResult.IsSuccess)
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
    /// Обновить размер в бренде
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="sizeId"></param>
    /// <param name="updateSizeRequest"></param>
    /// <returns></returns>
    [HttpPut("{brandId}/allowed-sizes/{sizeId}")]
    public async Task<IActionResult> UpdateSizeAsync([FromQuery] int brandId, int sizeId, UpdateSizeRequest updateSizeRequest)
    {
        try
        {
            var serviceResult = await _brandsService.UpdateSizeAsync(brandId, sizeId, updateSizeRequest);
            if (serviceResult.IsSuccess)
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
    /// Обновить список размеров в бренде
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="updateSizesInBrandRequest"></param>
    /// <returns></returns>
    [HttpPut("{brandId}/allowed-sizes")]
    public async Task<IActionResult> UpdateSizesInBrandAsync([FromQuery] int brandId, UpdateSizesInBrandRequest updateSizesInBrandRequest)
    {
        try
        {
            var serviceResult = await _brandsService.UpdateSizesInBrandAsync(brandId, updateSizesInBrandRequest);
            if (serviceResult.IsSuccess)
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
    /// Soft delete
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="sizeId"></param>
    /// <returns></returns>
    [HttpDelete("{brandId}/allowed-sizes/{sizeId}")]
    public async Task<IActionResult> SoftDeleteSizeAsync(int brandId, int sizeId)
    {
        try
        {
            var serviceResult = await _brandsService.SoftDeleteSizeAsync(brandId, sizeId);
            if (serviceResult.IsSuccess)
                return Ok(serviceResult);

            return BadRequest(serviceResult);
        }
        catch (Exception e)
        {
            LogError(e);
            return StatusCode(500);
        }
    }

    private void LogError(Exception e, [CallerMemberName] string methodName = null!)
    {
        _logger.LogError(e, "Error at {0}", methodName);
    }
}