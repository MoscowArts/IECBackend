using IECBackend.Api.Features.Projects;
using MediatR;

namespace IECBackend.Api.Features.WorkTask.CreateWorkTask;

public record CreateWorkTaskCommand(CreateWorkTaskRequestDto CreateWorkTaskRequestDto) 
    : IRequest<Unit>;