using GenerationApi.Application.Models.Data;
using GenerationApi.Application.Models.DTOs;
using MediatR;

namespace GenerationApi.Application.Models.Queries;

public class GetModelParametersQueryHandler
    : IRequestHandler<GetModelParametersQuery, ModelParametersResponseDto>
{
    public Task<ModelParametersResponseDto> Handle(GetModelParametersQuery request, CancellationToken cancellationToken)
    {
        var parameters = InMemoryModelCatalog.GetParametersByModelId(request.ModelId);

        if (parameters == null)
            throw new KeyNotFoundException($"Модель с ID {request.ModelId} не найдена");

        return Task.FromResult(parameters);
    }
}