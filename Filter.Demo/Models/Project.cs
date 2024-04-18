namespace Filter.Demo.Models;
internal class Project
{
    public int Id { get; set; }
    public string? LocalMatId { get; set; }
    public string? ProjectNr { get; set; }
    public string? ProjectType { get; set; }
    public string? Cluster { get; set; }
    public string? ProjectInitiator { get; set; }
    public string? OldLocalMatId { get; set; }
    public string? PrimPack { get; set; }
    public string? PrimPackSpec { get; set; }
    public string? ReqPackCat { get; set; }
    public string? ReqPackType { get; set; }
    public string? Brand { get; set; }
    public string? RequestionOrganisation { get; set; }
    public int? TechnicalTemplateId { get; set; }
    public string? BarcodeType { get; set; }
    public string? Barcode { get; set; }
    public string? BarcodeItf { get; set; }
    public string? Pma { get; set; }
    public string? Supplier { get; set; }
    public DateTime? GiveClearance { get; set; }
    public DateTime? LastSelected { get; set; }
    public int State { get; set; }
    public string? PromotionalCodes { get; set; }
    public string? NewColors { get; set; }
    public string? TotalColors { get; set; }
    public string? GlobalMatId { get; set; }
    public int OrganizationId { get; set; }
    public string? PrimPackVol { get; set; }
    public string? AddDesSpec { get; set; }
    public string? AddMatSpec { get; set; }
    public string? AddTechSpec { get; set; }
    public string? ReqPackConf { get; set; }
    public string? GlobalMatDesc { get; set; }
    public string? OldGlobalMatId { get; set; }
    public string? TechnicalTemplateNr { get; set; }
    public string? ColorSpecification { get; set; }
    public string? PrintingTechnique { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? LocalLangGlobalMatDesc { get; set; }
    public string? ProductionLine { get; set; }
    public string? BarcodeCurrentSccItf { get; set; }
    public string? BarcodeNewSccItf { get; set; }
    public string? FertSku { get; set; }
    public string? FertSkuNew { get; set; }
    public bool? LabelPolicyCompliant { get; set; }
    public string? AlcoholPercentage { get; set; }
}
