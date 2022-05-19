using Volo.Abp.Domain.Entities;

namespace abpGuidVsLongTest.Entities;

public class ProductGuid : Entity<Guid>
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public Guid? CategoryId { get; set; }
    public CategoryGuid Category { get; set; }
}

public class ProductLong : Entity<long>
{
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public long? CategoryId { get; set; }
    public CategoryLong Category { get; set; }
}