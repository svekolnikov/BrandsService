using BrandsService.Services.Interfaces;

namespace BrandsService.Services
{
    /// <summary>
    /// Информация об ошибке
    /// </summary>
    public class FailureInformation : IFailureInformation
    {
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string Description { get; init; } = null!;
    }
}
