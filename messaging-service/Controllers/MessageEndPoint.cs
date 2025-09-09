using MediatR;
using MessagingService.Mediatr;
using MessagingService.Model;

namespace MessagingService.Controllers
{
    public class MessageEndPoint
    {    
        public static async Task<Message?> GetMessage(Guid id, IMediator mediator)
        {
            return await mediator.Send(new GetMessageByIdQuery.Query { Id = id }); 
        }

        public static async Task<IResult> DeleteMessage(Guid id, IMediator mediator)
        {
            var message = await GetMessage(id, mediator);
           
            if (message == null)
            {
                return Results.StatusCode(StatusCodes.Status404NotFound);
            }
            return await mediator.Send(new DeleteMessageByIdCommand.Command { Id = id });
        }

        public static async Task<IResult> SendMessage(SendMessageCommand.Command command, IMediator mediator)
        {
            return await mediator.Send(command);
        }
    }
}