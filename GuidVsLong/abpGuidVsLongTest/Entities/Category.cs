using Volo.Abp.Domain.Entities;

namespace abpGuidVsLongTest.Entities;

public class CategoryGuid : Entity<Guid>
{
    public string CategoryName { get; set; }
}

public class CategoryLong : Entity<long>
{
    public string CategoryName { get; set; }
}