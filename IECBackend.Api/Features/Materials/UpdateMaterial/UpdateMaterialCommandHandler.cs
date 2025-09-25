using IECBackend.Api.Exceptions.Material;
using MediatR;

namespace IECBackend.Api.Features.Materials.UpdateMaterial;



public class UpdateMaterialCommandHandler(IMaterialRepository materialRepository) : IRequestHandler<UpdateMaterialCommand, Unit>
{

    public async Task<Unit> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
    {
        var material = await materialRepository.GetByIdAsync(request.Id);
        if (material == null)
            throw MaterialNotFoundExeption.WithSuchId(request.Id);
        material.Name =request.Material.Name??material.Name;
        material.ProjectId = request.Material.ProjectId??material.ProjectId;
        material.Volume = request.Material.Volume??material.Volume;
        material.Unit = request.Material.Unit??material.Unit;
        material.DeliveryDate = request.Material.DeliveryDate??material.DeliveryDate;

        await materialRepository.UpdateAsync(material.Id, material);
        
        return Unit.Value;
    }
}