using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.Register;
using TaskManager.Communication.Request;
using TaskManager.Communication.Response;

namespace TaskManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly RequestTaskRepository Task;

    public TaskController()
    {
        Task = new RequestTaskRepository();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    
    public IActionResult CreateTask([FromBody] RequestTaskJson request)
    {
        var task = new RequestTaskJson
        {
            Name = request.Name,
            Description = request.Description,
            Type = request.Type,
            DateLimit = request.DateLimit,
            Status = request.Status,
        };
        Task.AddTask(task);
        var response = new RegisterTaskUseCase().Execute(request);
        
        return Created(string.Empty, response);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = Task.GetAllTasks();

        if (response == null)
        {
            return NoContent(); 
        }
        return Ok(response);

    }
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var response = Task.GetTasksById(id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateTask(int id,[FromBody] RequestTaskJson request)
    {
        var response = Task.GetTasksById(id);

        if (response == null)
        {
            return NotFound();
        }
        response.Name = request.Name;
        response.Description = request.Description;
        response.Type = request.Type;
        response.DateLimit = request.DateLimit;
        response.Status = request.Status;

        return Ok(response);
    }
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var existingBook = Task.GetTasksById(id);
        if (existingBook == null)
        {
            return NotFound();
        }
        Task.RemoveTask(id);
        return NoContent();
    }
}

