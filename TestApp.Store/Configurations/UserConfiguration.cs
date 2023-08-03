namespace TestApp.Store.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(x => x.Organization)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.Organization);
        
        builder.ToTable("user", Constants.DbSchema);
    }
}