using TaskManager.Communication.Enums;
using TaskStatus = TaskManager.Communication.Enums.TaskStatus;


namespace TaskManager.Communication.Response;

public class ResponseRegisteredTaskJson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskType Type { get; set; }
    public DateTime DateLimit { get; set; }
    public TaskStatus Status { get; set; }
}
