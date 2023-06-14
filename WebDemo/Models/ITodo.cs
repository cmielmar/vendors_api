namespace TodoApp.Models
{
    public interface ITodo
    {
        string Content { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        int Priority { get; set; }
        string Status { get; set; }
    }
}