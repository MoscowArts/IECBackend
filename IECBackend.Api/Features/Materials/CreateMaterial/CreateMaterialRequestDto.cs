namespace IECBackend.Api.Features.Materials.CreateMaterial;

public class CreateMaterialRequestDto
{
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public float Volume { get; set; }
    public string Unit { get; set; }
    public DateTime DeliveryDate { get; set; }
}