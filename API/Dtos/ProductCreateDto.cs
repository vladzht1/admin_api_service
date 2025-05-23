namespace API.Dtos;

public record ProductCreateDto(
    string Name,
    string Description,
    Guid CreatorId
);
