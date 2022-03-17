namespace BrandsService.Services;

/// <summary>
/// Информация об ошибке
/// </summary>
public interface IFailureInformation
{
    /// <summary>
    /// Описание ошибки
    /// </summary>
    public string Description { get; }
}