using IECBackend.Api.Exceptions.Material;
using MediatR;

namespace IECBackend.Api.Features.Materials.DeleteMaterial;



public class DeleteMaterialCommandHandler(IMaterialRepository materialRepository) : IRequestHandler<DeleteMaterialCommand, Unit>
{
    
    public async Task<Unit> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
    {
        if(!await materialRepository.ExistsAsync(request.Id))
            throw MaterialNotFoundExeption.WithSuchId(request.Id);
        
        await materialRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}