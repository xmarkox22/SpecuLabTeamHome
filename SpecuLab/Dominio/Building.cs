using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Buildings;

public class Building
{
    public Building(string name, int id, int floors, bool hasLift, int apartmentsPerFloor, int price)
    {
        Name = name;
        Id = id;
        Floors = floors;
        HasLift = hasLift;
        ApartmentsPerFloor = apartmentsPerFloor;
        Price = price;
    }

    
    public string Name { get; set; }
    public int Id { get; set; }
    public int Floors { get; set; }
    public bool HasLift { get; set; }
    public int ApartmentsPerFloor { get; set; }
    public int Price { get; private set; }

    public Building()
    {

    }

    public override string ToString()
    {
        return $"Edificio: {Name}, ID: {Id}, Pisos: {Floors}, Tiene Ascensor: {HasLift}, Apartamentos por piso: {ApartmentsPerFloor}, Precio: {Price}";
    }

    public static List<Building> FromJsonFile(string v)
    {
        var json = File.ReadAllText(v, System.Text.Encoding.UTF8);
        List<Building> list = JsonSerializer.Deserialize<List<Building>>(json);
        return list;
    }

    public static async Task<List<Building>> FromJsonUrlAsync(string url)
    {
        using var client = new HttpClient();
        var json = await client.GetStringAsync(url);
        // Si el JSON remoto tiene un wrapper, ajusta aquí el deserializado
        // Por ejemplo, si el JSON está en data: { ... }
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        if (root.TryGetProperty("record", out var record))
        {
            return JsonSerializer.Deserialize<List<Building>>(record.GetRawText());
        }
        return JsonSerializer.Deserialize<List<Building>>(json);
    }
}
