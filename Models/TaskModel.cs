// Models/TaskModel.cs
public class TaskModel
{
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public int CategoryId { get; set; }
}