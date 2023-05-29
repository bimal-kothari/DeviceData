using Microsoft.EntityFrameworkCore;
using DeviceData.API.Models.Domain;

namespace DeviceData.API.Data
{
    public class DeviceDataDbContext: DbContext
    {
        public DeviceDataDbContext(DbContextOptions<DeviceDataDbContext> options): base(options)
        {

        }

        

        public DbSet<Models.Domain.DeviceData> DeviceData { get; set; }
    }
}
