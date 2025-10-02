using MediatR;

namespace IECBackend.Api.Features.Materials.DeleteMaterial;

public record DeleteMaterialCommand(int Id) : IRequest<Unit>;