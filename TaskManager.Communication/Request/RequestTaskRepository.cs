namespace TaskManager.Communication.Request;

public class RequestTaskRepository
{
    private static List<RequestTaskJson> Task = new List<RequestTaskJson>();

    public void AddTask(RequestTaskJson works)
    {
        works.Id = Task.Count + 1;
        Task.Add(works);
    }
    public List<RequestTaskJson> GetAllTasks()
    {
        return Task;
    }
    public RequestTaskJson GetTasksById(int id)
    {
        return Task.FirstOrDefault(works => works.Id == id);
    }
    public void RemoveTask(int id)
    {
        var taskToRemove = Task.FirstOrDefault(works => works.Id == id);
        if (taskToRemove != null)
        {
            Task.Remove(taskToRemove);
        }
    }
}
