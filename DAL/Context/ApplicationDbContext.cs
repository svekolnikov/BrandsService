using BrandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsService.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    { }

    /// <summary>
    /// Бренды
    /// </summary>
    public DbSet<Brand> Brands { get; set; } = null!;

    public DbSet<Size> Sizes { get; set; } = null!;
}