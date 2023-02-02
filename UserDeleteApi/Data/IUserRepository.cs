using DeleteUser.Model;

namespace DeleteUser.Data
{
        public interface IUserRepository
        {
            Task<User> GetUserByIdAsync(Guid id);
            Task<IResult> DeleteUserByIdAsync(Guid id);
        }
}
