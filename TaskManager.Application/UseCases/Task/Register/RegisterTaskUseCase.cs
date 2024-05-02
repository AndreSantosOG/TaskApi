using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisteredTaskJson Execute(RequestTaskJson request)
    {
       
        return new ResponseRegisteredTaskJson 
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Type = request.Type,
            DateLimit = request.DateLimit,
            Status = request.Status,

        };
    }
}
