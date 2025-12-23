using GenerationApi.Application.Models.DTOs;

namespace GenerationApi.Application.Models.Data;

public static class InMemoryModelCatalog
{
    private static readonly List<ModelListItemDto> Models = new()
    {
        new ModelListItemDto(1, "model1", "Первая модель"),
        new ModelListItemDto(2, "model2", "Вторая модель"),
        // легко добавлять новые: new ModelListItemDto(3, "model3", "Третья модель")
    };

    private static readonly Dictionary<int, ModelParametersResponseDto> ModelParameters = new()
    {
        {
            1, new ModelParametersResponseDto(
                Id: 1,
                Name: "model1",
                Parameters: new List<ModelParameterDto>
                {
                    new(123, "Высота", new[] { 100, 110, 120 }),
                    new(124, "Ширина", new[] { 200, 220 }),
                    new(125, "Глубина", new[] { 150, 160, 170 })
                })
        },
        {
            2, new ModelParametersResponseDto(
                Id: 2,
                Name: "model2",
                Parameters: new List<ModelParameterDto>
                {
                    new(201, "Диаметр", new[] { 300, 350, 400 }),
                    new(202, "Мощность", new[] { 5, 10, 15 })
                })
        }
    };

    public static IReadOnlyList<ModelListItemDto> GetAllModels() => Models;

    public static ModelParametersResponseDto? GetParametersByModelId(int modelId)
        => ModelParameters.GetValueOrDefault(modelId);
}