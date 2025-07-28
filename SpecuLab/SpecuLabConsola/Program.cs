using Buildings;

Console.WriteLine("Hello, SpecuLabConsola!");
Console.WriteLine("Lista de edificios en propiedad");
Console.WriteLine("================================");
Console.WriteLine("Leidos desde lista:");

// crea una lista de edificios de la clase Building con datos ficticios
var buildingsFromList = new List<Building>
{
    new Building("Edificio Gardens", 1, 5, true, 100000),
    new Building("Edificio Waterfall", 2, 10, false, 200000),
    new Building("Edificio Towers", 3, 8, true, 150000)
};

// recorre la lista de edificios e imprime sus datos   
foreach (var building in buildingsFromList)
{
    Console.WriteLine(building);
}


// recorre la lista de edificios e imprime sus datos desde el JSON local
Console.WriteLine("================================");
Console.WriteLine("Leidos desde JSON local:");
var buildingsFromJson = Building.FromJsonFile("Buildings.json");
foreach (var building in (List<Building>)buildingsFromJson)
{
    Console.WriteLine(building);
}

