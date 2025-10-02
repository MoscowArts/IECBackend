using MediatR;

namespace IECBackend.Api.Features.Materials.UpdateMaterial;

public record UpdateMaterialCommand(int Id,UpdateMaterialRequest Material) : IRequest<Unit>;