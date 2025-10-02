using MediatR;

namespace IECBackend.Api.Features.Materials.GetByIdMaterial;

public record GetByIdMaterialCommand(int Id) : IRequest<DbMaterial>;