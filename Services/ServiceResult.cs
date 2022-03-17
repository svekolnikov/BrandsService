using BrandsService.Services.Interfaces;

namespace BrandsService.Services;

public class ServiceResult : IServiceResult
{
    public IReadOnlyCollection<IFailureInformation>? Failures { get; init; }
}

public class ServiceResult<T> : ServiceResult, IServiceResult<T>
{
    public T? Data { get; set; }
}