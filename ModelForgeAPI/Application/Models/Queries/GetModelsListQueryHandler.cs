using GenerationApi.Application.Models.Data;
using GenerationApi.Application.Models.DTOs;
using MediatR;

namespace GenerationApi.Application.Models.Queries;

public class GetModelsListQueryHandler
    : IRequestHandler<GetModelsListQuery, ModelListResponseDto>
{
    public Task<ModelListResponseDto> Handle(GetModelsListQuery request, CancellationToken cancellationToken)
    {
        var allModels = InMemoryModelCatalog.GetAllModels();

        // Пагинация (в будущем можно добавить skip/take)
        var models = allModels
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var response = new ModelListResponseDto(
            Models: models,
            TotalCount: allModels.Count);

        return Task.FromResult(response);
    }
}