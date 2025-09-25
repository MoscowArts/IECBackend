using IECBackend.Api.Exceptions.Material;
using MediatR;

namespace IECBackend.Api.Features.Materials.GetByIdMaterial;



public class GetByIdMaterialCommandHandler(IMaterialRepository materialRepository) : IRequestHandler<GetByIdMaterialCommand, DbMaterial>
{

    public async Task<DbMaterial> Handle(GetByIdMaterialCommand request, CancellationToken cancellationToken)
    {
        var issue = await materialRepository.GetByIdAsync(request.Id);
        return issue ?? throw MaterialNotFoundExeption.WithSuchId(request.Id);
    }
}