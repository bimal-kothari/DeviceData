using DeviceData.API.Models.Domain;

namespace DeviceData.API.Repositories
{
    public interface IDeviceDataRepository
    {
        Task<IEnumerable<Models.Domain.DeviceData>> GetAllDataAsync(string file1,string file2);

      
    }
}
