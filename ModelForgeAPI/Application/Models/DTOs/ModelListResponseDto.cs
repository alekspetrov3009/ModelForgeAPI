using GenerationApi.Application.Models.DTOs;

public record ModelListResponseDto(
    IReadOnlyList<ModelListItemDto> Models,
    int TotalCount);