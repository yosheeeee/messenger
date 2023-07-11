using backend.Models;

namespace backend;

public static class Extensions
{
    public static UserAsDto AsDto(this User user)
    {
        return new UserAsDto() { Id = user.Id, UserName = user.UserName, Password = user.Password };
    }
}