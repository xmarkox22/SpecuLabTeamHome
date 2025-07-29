using PrototipoApi.Entities;
using System.Text.Json;

public static class RequestStore
{
    private static readonly string filePath = "requests.json";

    public static List<Request> Requests { get; private set; } =
        JsonSerializer.Deserialize<List<Request>>(File.ReadAllText(filePath)) ?? new List<Request>();
}
