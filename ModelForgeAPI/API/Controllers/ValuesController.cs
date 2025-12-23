//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("api/[controller]")]
//public class ModelsController : ControllerBase
//{
//    private readonly IMediator _mediator;

//    public ModelsController(IMediator mediator) => _mediator = mediator;

//    [HttpGet]
//    public async Task<IActionResult> GetModels()
//        => Ok(await _mediator.Send(new GetModelsQuery()));

//    [HttpGet("{id}/params")]
//    public async Task<IActionResult> GetModelParams(int id)
//        => Ok(await _mediator.Send(new GetModelParamsQuery { Id = id }));
//}