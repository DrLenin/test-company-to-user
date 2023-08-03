namespace TestApp.Store;

public class TestAppContext : DbContext
{
    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<User> Users => Set<User>();


    public TestAppContext(DbContextOptions<TestAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        UpdateDate(ChangeTracker);

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateDate(ChangeTracker);

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        UpdateDate(ChangeTracker);

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override int SaveChanges()
    {
        UpdateDate(ChangeTracker);

        return base.SaveChanges();
    }

    private static void UpdateDate(ChangeTracker changeTracker)
    {
        var dateTimeNow = DateTime.UtcNow;

        foreach (var entityEntry in changeTracker.Entries())
        {
            if (entityEntry.Entity is not BaseEntity entity) continue;
            
            if (entityEntry.State == EntityState.Deleted)
            {
                entity.IsDeleted = true;
                entityEntry.State = EntityState.Modified;
            }

            if (entityEntry.State is EntityState.Modified or EntityState.Added)
                entity.UpdatedDate = dateTimeNow;

            if (entityEntry.State == EntityState.Added && entity.CreatedDate == default)
                entity.CreatedDate = dateTimeNow;
        }
    }
}