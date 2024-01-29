namespace TodoList.Models
{
    public class TodoTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TodoTaskStatus Status { get; set; }
    }

    public enum TodoTaskStatus
    {
        Undone,
        Done
    }
}
