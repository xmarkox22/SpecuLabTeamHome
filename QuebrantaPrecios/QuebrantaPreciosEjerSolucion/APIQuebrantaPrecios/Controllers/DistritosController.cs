using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIQuebrantaPrecios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        // Devolver hola mundo
        [HttpGet]
        public IActionResult Get()
        {
            // Distrito 

            var district = new District();

            district.PostalCode = 31014;
            district.Name = "La Rotxa";



            // Apartamentos

            var apartment1 = new Apartment();

            apartment1.ApartmentLetter = "A";
            apartment1.Floor = 1;
            apartment1.SquareMeters = 100;
            apartment1.Rooms = 3;

            var apartment2 = new Apartment();

            apartment2.ApartmentLetter = "B";
            apartment2.Floor = 2;
            apartment2.SquareMeters = 100;
            apartment2.Rooms = 4;

            var apartment3 = new Apartment(rooms: 2, apartmentLetter: "C", squareMeters: 100, floor: 4);
            var apartment4 = new Apartment(rooms: 5, apartmentLetter: "D", squareMeters: 120, floor: 15);


            // Edificios

            var building1 = new Building()
            {
                Name = "Edificio Central",
                Floors = 10,
                Apartments = new List<Apartment> { apartment1, apartment2, apartment3 },
                District = district
            };

            var building2 = new Building("Edificio Norte", 20, new List<Apartment> { apartment4 }, district);

            // Asignar edificios al distrito

            district.Buildings = new List<Building> { building1, building2 };

            return Ok(building2);
        }
    }
}
