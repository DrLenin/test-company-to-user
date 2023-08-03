namespace TestApp.Store.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("notificationConfiguration", Constants.DbSchema);
    }
}