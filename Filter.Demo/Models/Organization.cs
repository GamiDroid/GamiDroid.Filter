
namespace Filter.Demo.Models;
internal class Organization
{
    public int OrganizationId { get; set; }
    public string? Name { get; set; }
    public string? ShortName { get; set; }
    public int? ParentId { get; set; }
    public string? RequestEmailProject { get; set; }
    public string? RequestEmailTechnicalTemplate { get; set; }
}
