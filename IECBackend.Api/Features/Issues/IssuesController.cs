using IECBackend.Api.Features.Issues.CreateIssue;
using IECBackend.Api.Features.Issues.DeleteIssue;
using IECBackend.Api.Features.Issues.GetByIdIssue;
using IECBackend.Api.Features.Issues.UpdateIssue;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Issues;
/// <summary>
/// Контроллер для управления заявками (issues)
/// </summary>
[Route("issues/")]
public class IssuesController(IMediator mediator) : Controller
{
    /// <summary>
    /// Получить заявку по идентификатору
    /// </summary>
    /// <param name="issueId">Идентификатор заявки (от 1 до 100000)</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Данные заявки</returns>
    /// <response code="200">Заявка успешно найдена</response>
    /// <response code="404">Заявка с указанным ID не найдена</response>
    [HttpGet("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int issueId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdIssueCommand(issueId), cancellationToken);
        return Ok(user);
    }
    
    /// <summary>
    /// Удалить заявку
    /// </summary>
    /// <param name="issueId">Идентификатор заявки для удаления (от 1 до 100000)</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Заявка успешно удалена</response>
    /// <response code="404">Заявка с указанным ID не найдена</response>
    [HttpDelete("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int issueId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteIssueCommand(issueId), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Создать новую заявку
    /// </summary>
    /// <param name="issueRequestDto">Данные для создания заявки</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат создания</returns>
    /// <response code="200">Заявка успешно создана</response>
    /// <response code="400">Некорректные данные заявки</response>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     POST /issues
    ///     {
    ///         "description": "Провалившийся асфальт на проезжей части глубиной около 15 см. Требуется срочный ремонт.",
    ///         "coordinates": "55.7558,37.6173",
    ///         "termOfElimination": "2024-12-31T23:59:59Z",
    ///         "image": "base64_encoded_image_data"
    ///     }
    /// </remarks>
    // [HttpPost]
    // [AllowAnonymous]
    // public async Task<IActionResult> Create(IssueRequestDto issueRequestDto, CancellationToken cancellationToken)
    // {
    //     await mediator.Send(new CreateIssueCommand(issueRequestDto), cancellationToken);
    //     return Ok();
    // }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(string Description, string Coordinates,
        DateTime TermOfElimination,byte[] Image, CancellationToken cancellationToken)
    {
        var tmp = new IssueRequestDto
        {
            Description = Description,
            Coordinates = Coordinates,
            TermOfElimination = TermOfElimination,
            Image = Image
        };
        await mediator.Send(new CreateIssueCommand(tmp), cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Обновить данные заявки
    /// </summary>
    /// <param name="issueId">Идентификатор заявки (от 1 до 100000)</param>
    /// <param name="request">Данные для обновления</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат обновления</returns>
    /// <response code="200">Заявка успешно обновлена</response>
    /// <response code="400">Некорректные данные заявки</response>
    /// <response code="404">Заявка с указанным ID не найдена</response>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     PATCH /issues/123
    ///     {
    ///         "description": "Обновленное описание проблемы с асфальтом",
    ///         "coordinates": "55.7558,37.6173",
    ///         "termOfElimination": "2024-12-31T23:59:59Z",
    ///         "image": "base64_encoded_image_data"
    ///     }
    /// </remarks>
    [HttpPatch("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Update(int issueId, IssueRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateIssueCommand(issueId, request), cancellationToken);
        return Ok();
    }
}