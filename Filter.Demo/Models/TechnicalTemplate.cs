
namespace Filter.Demo.Models;
internal class TechnicalTemplate
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
    public string LocalTechnicalTemplateNumber { get; set; } = string.Empty;
    public int PrimPack { get; set; }
    public int PrimPackSpec { get; set; }
    public int PrimPackVol { get; set; }
    public int ReqNewPack { get; set; }
    public int ReqNewPackGrp { get; set; }
    public int ReqNewPackPos { get; set; }
    public int Supplier { get; set; }
    public string? ProductionLine { get; set; }
    public string? Requestor { get; set; }
    public DateTime DateCreated { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public double? Length { get; set; }
    public double? Width { get; set; }
    public string? StandSquareNekPlugDia { get; set; }
    public string? TypeOfInk { get; set; }
    public string? MaterialThickness { get; set; }
    public string? Construction { get; set; }
    public string? Diameter { get; set; }
    public double? InternalLength { get; set; }
    public double? InternalWidth { get; set; }
    public double? InternalHeight { get; set; }
    public string? MaterialType { get; set; }
    public string? Color { get; set; }
    public double? ShoulderHeight { get; set; }
    public int State { get; set; }
    public string? PalletLoad { get; set; }
    public string? TechnicalDescription { get; set; }

    public Organization? Organization { get; set; }
    public LookupValue? PrimPackNavigation { get; set; }
    public LookupValue? PrimPackSpecNavigation { get; set; }
    public LookupValue? PrimPackVolNavigation { get; set; }
    public LookupValue? ReqNewPackGrpNavigation { get; set; }
    public LookupValue? ReqNewPackNavigation { get; set; }
    public LookupValue? ReqNewPackPosNavigation { get; set; }
    public LookupValue? SupplierNavigation { get; set; }
    public ICollection<Project> Project { get; set; } = [];
}
