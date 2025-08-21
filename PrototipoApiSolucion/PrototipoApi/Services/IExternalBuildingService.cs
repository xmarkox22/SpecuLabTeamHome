using System.Threading.Tasks;
using PrototipoApi.Entities;

namespace PrototipoApi.Services
{
    public interface IExternalBuildingService
    {
        Task<Building?> GetBuildingByCodeAsync(string buildingCode);
    }
}
