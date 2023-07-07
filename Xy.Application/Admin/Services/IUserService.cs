namespace Xy.Application.Admin;

public interface IUserService 
{
    Task<PagedResult<UserListOutput>> GetUserListByLayer(UserQuery searchQuery);
}