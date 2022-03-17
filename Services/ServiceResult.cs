using BrandsService.Services.Interfaces;

namespace BrandsService.Services;

public class ServiceResult : IServiceResult
{
    public bool IsSuccess { get; set; }
    public IReadOnlyCollection<IFailureInformation>? Failures { get; init; }
}

public class ServiceResult<T> : ServiceResult, IServiceResult<T>
{
    public T? Data { get; set; }
}