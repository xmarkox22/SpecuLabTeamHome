namespace ClasesQuebrantaprecios.Properties
{
    public class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Floors { get; set; }
        public List<Apartment> Apartments { get; set; }
        public District District { get; set; }

        public Building()
        {
            
        }
      public Building(string name, int floors, List<Apartment> apartments, District district)
        {
            Id = Guid.NewGuid();
            Name = name;
            Floors = floors;
            Apartments = apartments;
            District = district;
        }

        public override string ToString()
        {
            return $"Building {Name} with {Floors} floors, located in district {District.Name}.";
        }
    }

}
