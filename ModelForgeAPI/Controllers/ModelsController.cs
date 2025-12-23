using GenerationApi.Application.Models.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenerationApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModelsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить список всех моделей
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(ModelListResponseDto), 200)]
    public async Task<IActionResult> GetModels(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20)
    {
        var query = new GetModelsListQuery(page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Получить параметры конкретной модели
    /// </summary>
    [HttpGet("{id}/parameters")]
    [ProducesResponseType(typeof(ModelParametersResponseDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetModelParameters(int id)
    {
        try
        {
            var query = new GetModelParametersQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Модель с ID {id} не найдена");
        }
    }
}