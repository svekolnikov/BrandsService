using System.Runtime.CompilerServices;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrandsService.Controllers
{
    [Route("api/sizes")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ILogger<SizesController> _logger;
        private readonly ISizesService _sizesService;

        public SizesController(ILogger<SizesController> logger, ISizesService sizesService)
        {
            _logger = logger;
            _sizesService = sizesService;
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
                var serviceResult = await _sizesService.GetAllAsync();
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
                var serviceResult = await _sizesService.CreateAsync(createSizeRequest);
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
                var serviceResult = await _sizesService.UpdateAsync(updateSizeRequest);
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
                var serviceResult = await _sizesService.SoftDeleteAsync(id);
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
