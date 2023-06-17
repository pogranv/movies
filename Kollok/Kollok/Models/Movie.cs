namespace Kollok.Models;

public class Movie
{
    public string Name { get; set; } = null!;
    
    public string? Genre { get; set; }
    
    public int Duration { get; set; }
    
    public int Rate { get; set; }
}