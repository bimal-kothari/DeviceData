using AutoMapper;

namespace DeviceData.API.Profiles
{
    public class DeviceDataProfile: Profile
    {
        public DeviceDataProfile()
        {
            CreateMap<Models.Domain.DeviceData, Models.DTO.DeviceDataDTO>()
                .ReverseMap();
        }
    }
}
