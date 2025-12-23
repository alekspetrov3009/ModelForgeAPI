using GenerationApi.Application.Models.DTOs;
using MediatR;

namespace GenerationApi.Application.Models.Queries;

public record GetModelsListQuery(
    int Page = 1,
    int PageSize = 20) : IRequest<ModelListResponseDto>;