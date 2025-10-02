using MediatR;

namespace IECBackend.Api.Features.Materials.CreateMaterial;



public class CreateMaterialCommandHandler(IMaterialRepository materialRepository) : IRequestHandler<CreateMaterialCommand, Unit>
{
    
    public async Task<Unit> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
    {

        var material = new DbMaterial() { 
            Name = request.Material.Name,
            ProjectId = request.Material.ProjectId,
            Volume = request.Material.Volume,
            Unit = request.Material.Unit,
            DeliveryDate = request.Material.DeliveryDate,
            CreatedAt = DateTime.UtcNow,
        };
        
        await materialRepository.AddAsync(material);
        
        return Unit.Value;
    }
}