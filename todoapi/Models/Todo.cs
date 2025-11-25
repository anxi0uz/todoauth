namespace todoapi.Models;

public class Todo
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public virtual User User { get; set; }
    public int  UserId { get; set; }
}