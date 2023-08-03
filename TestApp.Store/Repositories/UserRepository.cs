namespace TestApp.Store.Repositories;

public interface IUserRepository : IBaseRepository
{
    Task<User[]> GetUsersByCompanyIdTakeAndSkipAsync(Guid companyId, int take, int skip);

    Task<User> GetUserByIdAsync(Guid userId);
}

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(TestAppContext dbContext) : base(dbContext) {}

    public async Task<User[]> GetUsersByCompanyIdTakeAndSkipAsync(Guid companyId, int take, int skip)
    {
        return await DbContext.Users.Where(d => d.OrganizationId == companyId).Take(take).Skip(skip).ToArrayAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        return await DbContext.Users.FirstAsync(d => d.Id == userId);
    }
}