namespace ClasesQuebrantaprecios.Properties
{
    public class Apartment
    {
        public string ApartmentLetter { get; set; }
        public int Floor { get; set; }
        public int SquareMeters { get; set; }
        public int Rooms { get; set; }

        public Apartment()
        {
            
        }

        public Apartment(string apartmentLetter, int floor, int squareMeters, int rooms)
        {
            ApartmentLetter = apartmentLetter;
            Floor = floor;
            SquareMeters = squareMeters;
            Rooms = rooms;
        }

        public override string ToString()
        {
            return $"Apartment {ApartmentLetter} on floor {Floor} with {SquareMeters} m² and {Rooms} rooms.";
        }
    }
}
