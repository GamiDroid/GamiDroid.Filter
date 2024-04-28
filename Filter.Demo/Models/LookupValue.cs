namespace Filter.Demo.Models;

public class LookupValue
{
    public int Id { get; set; }
    public int LookupType { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}