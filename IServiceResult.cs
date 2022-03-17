using BrandsService.Services;
using BrandsService.Services.Interfaces;

namespace BrandsService;

/// <summary>
/// Результат выполнения сервиса без данных
/// </summary>
public interface IServiceResult
{
    public bool IsSuccess { get; set; }
    public IReadOnlyCollection<IFailureInformation>? Failures { get; }
}

/// <summary>
/// Результат выполнения сервиса с данными
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IServiceResult<out T> : IServiceResult
{
    /// <summary>
    /// Возвращаемые данные из сервиса
    /// </summary>
    T? Data { get; }
}