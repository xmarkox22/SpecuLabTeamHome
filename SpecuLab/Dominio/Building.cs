
using System.Collections.Generic;
using System.Text.Json;

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
}
