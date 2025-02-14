namespace Project.Models;

public class Barber
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Bio { get; set; } = string.Empty;
    public List<string> Portfolio { get; set; } = new();
}
