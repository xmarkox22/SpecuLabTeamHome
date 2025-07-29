using Buildings;

Console.WriteLine("Hello, SpecuLabConsola!");
Console.WriteLine("Lista de edificios en propiedad");
Console.WriteLine("================================");
Console.WriteLine("Leidos desde lista:");

// crea una lista de edificios de la clase Building con datos ficticios
var buildingsFromList = new List<Building>
{
    new Building("Edificio A", 1, 5, true, 4, 150000),
    new Building("Edificio B", 2, 10, false, 6, 250000),
    new Building("Edificio C", 3, 8, true, 3, 200000),
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


// recorre la lista de edificios e imprime sus datos desde el JSON remoto
Console.WriteLine("================================");
Console.WriteLine("Leidos desde JSON remoto:");
var buildingsFromRemoteJson = Building.FromJsonFile("https://api.jsonbin.io/v3/b/68876421ae596e708fbcfb79/latestn");
foreach (var building in (List<Building>)buildingsFromRemoteJson)
{
    Console.WriteLine(building);
}
// espera a que el usuario pulse una tecla para finalizar
Console.WriteLine("================================");
Console.WriteLine("Pulse una tecla para finalizar...");
Console.ReadKey();

// fin del programa


