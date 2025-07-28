namespace PrototipoApi.ModelsDto
{
    public class CreateRequestDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Type { get; set; }

    }
}
