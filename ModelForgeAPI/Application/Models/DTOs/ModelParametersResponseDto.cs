public record ModelParameterDto(
    int ParamId,
    string Name,
    IReadOnlyList<int> Values); // пока значения только int, потом можно расширить

public record ModelParametersResponseDto(
    int Id,
    string Name,
    IReadOnlyList<ModelParameterDto> Parameters);