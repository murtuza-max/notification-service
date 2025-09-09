using DeleteUser.Model;
using DeleteUser.Validation;
using System.Data.Common;

namespace DeleteUser.Data
{
        public class UserRepository : IUserRepository
        {
            private readonly PostgreSqlContext _context;          

            public UserRepository(PostgreSqlContext context)
            {
                _context = context;
            }

            public async Task<User> GetUserByIdAsync(Guid id)
            {
                return await _context.UserDemoExtra.FirstOrDefaultAsync(e => e.UserId.Equals(id));
            }

            public async Task<IResult> DeleteUserByIdAsync(Guid id)
            {

                var User = await _context.UserDemoExtra.FirstOrDefaultAsync(e => e.UserId.Equals(id));
                var validator = new UserValidator();
                var validationResult = await validator.ValidateAsync(User);

                if (!validationResult.IsValid)
                {
                     return Results.StatusCode(StatusCodes.Status401Unauthorized);
                }
                if (User != null)
                {
                    try
                    {
                        User.IsDeleted = true;
                        await _context.SaveChangesAsync();
                        
                    }
                    catch (Exception ex)
                    {
                        if (ex is DbException || ex is TimeoutException)
                        {
                            return Results.StatusCode(StatusCodes.Status503ServiceUnavailable);
                        }
                        else
                        {
                            return Results.StatusCode(StatusCodes.Status500InternalServerError);
                        }
                    }
                }
            return Results.StatusCode(StatusCodes.Status204NoContent);
        }
         }
    }
