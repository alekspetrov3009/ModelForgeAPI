using GenerationApi.Application.Models.DTOs;
using MediatR;

namespace GenerationApi.Application.Models.Queries;

public record GetModelParametersQuery(int ModelId) : IRequest<ModelParametersResponseDto>;