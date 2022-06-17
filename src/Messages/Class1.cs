namespace Messages;
public record Message1
{
    public int Id { get; set; } = new Random().Next(1, 100);
    public string Name { get; set; } = $"Message {new Random().Next(1, 100)}";	
}
