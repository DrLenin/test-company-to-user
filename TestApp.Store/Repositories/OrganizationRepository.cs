namespace TestApp.Store.Repositories;

public interface IOrganizationRepository : IBaseRepository
{
    Task<Organization> GetCompanyByIdAsync(Guid companyId);
}

public class OrganizationRepository : BaseRepository, IOrganizationRepository
{
    public OrganizationRepository(TestAppContext dbContext) : base(dbContext) {}
    
    public async Task<Organization> GetCompanyByIdAsync(Guid companyId)
    {
        return await DbContext.Organizations.FirstAsync(d => d.Id == companyId);
    }
}