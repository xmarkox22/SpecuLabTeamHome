using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesQuebrantaprecios.Location
{
    public class District
    {
        public Guid DistrictId { get; set; }
        public int PostalCode { get; set; }
        public string Name { get; set; }
        public List<Building> Buildings { get; set; }


        // Contructor de District con parametros

        public District()
        {
            
        }
        public District(int postalCode, string name, List<Building> buildings)
        {
            DistrictId = Guid.NewGuid();
            PostalCode = postalCode;
            Name = name;
            Buildings = buildings;
        }

        public override string ToString()
        {
            return $"District {Name} with postal code {PostalCode} and {Buildings.Count} buildings.";
        }
    }

}
