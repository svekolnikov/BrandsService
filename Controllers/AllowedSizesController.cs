using System.Runtime.CompilerServices;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrandsService.Controllers
{
    [Route("api/allowed-sizes")]
    [ApiController]
    public class AllowedSizesController : ControllerBase
    {
        private readonly ILogger<AllowedSizesController> _logger;
        private readonly IAllowedSizesService _allowedSizesService;

        public AllowedSizesController(ILogger<AllowedSizesController> logger, IAllowedSizesService allowedSizesService)
        {
            _logger = logger;
            _allowedSizesService = allowedSizesService;
        }

        /// <summary>
        /// Получить все размеры
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var serviceResult = await _allowedSizesService.GetAllAsync();
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
        /// Создать размер
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CreateSizeRequest createSizeRequest)
        {
            try
            {
                var serviceResult = await _allowedSizesService.CreateAsync(createSizeRequest);
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
        /// Обновить размер
        /// </summary>
        /// <param name="updateBrandRequest"></param>
        /// <returns></returns>
        [HttpPut("")]
        public async Task<IActionResult> UpdateAsync(UpdateSizeRequest updateSizeRequest)
        {
            try
            {
                var serviceResult = await _allowedSizesService.UpdateAsync(updateSizeRequest);
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
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            try
            {
                var serviceResult = await _allowedSizesService.SoftDeleteAsync(id);
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
}
