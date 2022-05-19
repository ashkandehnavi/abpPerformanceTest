using abpGuidVsLongTest.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace abpGuidVsLongTest.Data;

public class abpGuidVsLongTestDbContext : AbpDbContext<abpGuidVsLongTestDbContext>
{
    public DbSet<ProductGuid> GProducts { get; set; }
    public DbSet<CategoryGuid> GCategories { get; set; }
    public DbSet<ProductLong> LProducts { get; set; }
    public DbSet<CategoryLong> LCategories { get; set; }
    public abpGuidVsLongTestDbContext(DbContextOptions<abpGuidVsLongTestDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
    }
}
