using abpGuidVsLongTest.Entities;
using System.Diagnostics;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace abpGuidVsLongTest.Services;

public class ProductGuidService : ApplicationService
{
    private readonly IRepository<ProductGuid, Guid> repository;

    public ProductGuidService(IRepository<ProductGuid, Guid> repository)
    {
        this.repository = repository;
    }

    public async Task<string> GetProductAsync(Guid id)
    {
        var watch = Stopwatch.StartNew();
        watch.Start();

        var prod = await repository.GetAsync(m => m.Id == id);

        return $"wating time: {watch.ElapsedMilliseconds}ms";
    }

    public async Task<string> GetProductsAsync()
    {
        var watch = Stopwatch.StartNew();
        watch.Start();

        var prods = await repository.GetListAsync(true);

        return $"wating time: {watch.ElapsedMilliseconds}ms";
    }

    public async Task<string> CreateWithRelationAsync(long count)
    {
        var watch = Stopwatch.StartNew();
        watch.Start();

        List<ProductGuid> prods = new List<ProductGuid>();
        for (int i = 0; i < count; i++)
        {
            prods.Add(new ProductGuid
            {
                ProductName = $"produc {i}",
                ProductPrice = new Random().Next(1000, 5000),
                Category = new CategoryGuid
                {
                    CategoryName = $"category item {i}"
                }
            });
        }
        await repository.InsertManyAsync(prods, true);

        watch.Stop();
        return $"wating time: {watch.ElapsedMilliseconds}ms";
    }

    public async Task<string> CreateNoneRelationAsync(long count)
    {
        var watch = Stopwatch.StartNew();
        watch.Start();

        List<ProductGuid> prods = new List<ProductGuid>();
        for (int i = 0; i < count; i++)
        {
            prods.Add(new ProductGuid
            {
                ProductName = $"produc {i}",
                ProductPrice = new Random().Next(1000, 5000)
            });
        }
        await repository.InsertManyAsync(prods, true);

        watch.Stop();
        return $"wating time: {watch.ElapsedMilliseconds}ms";
    }
}
