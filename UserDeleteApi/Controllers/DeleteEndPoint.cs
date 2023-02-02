
using DeleteUser.Mediatr;
using DeleteUser.Model;


namespace DeleteUser.Controllers
{
    public class DeleteEndPoint
    {    
        public static async Task<User> GetUser(Guid id, IMediator mediator)
        {
            return await mediator.Send(new GetUserByIdQuery.Query { Id = id }); 
        }

        public static async Task<IResult> DeleteUser(Guid id, IMediator mediator)
        {
            var user = await GetUser(id, mediator);
           
            if (user == null)
            {
                return Results.StatusCode(StatusCodes.Status404NotFound);
            }
            return await mediator.Send(new DeleteUserbyIdCommand.Command { Id = id });
            
        }
    }
}
