using MediatR;

namespace IECBackend.Api.Features.Materials.CreateMaterial;

public record CreateMaterialCommand(CreateMaterialRequestDto Material) 
    : IRequest<Unit>;