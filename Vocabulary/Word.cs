namespace Vocabulary;

public record Word
{
    public Guid Id { get; } = Guid.NewGuid();
    public required string English { get; set; }
    public required string Russian { get; set; }
    public string? Description { get; set; } 
}
