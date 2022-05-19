using abpGuidVsLongTest.Entities;
using System.Diagnostics;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace abpGuidVsLongTest.Services;

public class ProductlongService : ApplicationService
{
    private readonly IRepository<ProductLong, long> repository;

    public ProductlongService(IRepository<ProductLong, long> repository)
    {
        this.repository = repository;
    }

    public async Task<string> GetProductAsync(long id)
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

        List<ProductLong> prods = new List<ProductLong>();
        for (int i = 0; i < count; i++)
        {
            prods.Add(new ProductLong
            {
                ProductName = $"produc {i}",
                ProductPrice = new Random().Next(1000, 5000),
                Category = new CategoryLong
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

        List<ProductLong> prods = new List<ProductLong>();
        for (int i = 0; i < count; i++)
        {
            prods.Add(new ProductLong
            {
                ProductName = $"produc {i}",
                ProductPrice = new Random().Next(1000, 5000),
            });
        }
        await repository.InsertManyAsync(prods, true);

        watch.Stop();
        return $"wating time: {watch.ElapsedMilliseconds}ms";
    }
}
