﻿using BrandsService.Models;

namespace BrandsService.DAL.Repositories.Interfaces;

public interface IBrandsRepository : INamedRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAllWithSizesAsync(CancellationToken cancel = default);
    Task<Brand?> GetByIdWithSizesAsync(int id, CancellationToken cancel = default);
}