using FluentValidation;

namespace DeviceData.API.Validators
{
    public class DeviceDataValidator: AbstractValidator<Models.DTO.DeviceDataDTO>
    {
        public DeviceDataValidator()
        {
            RuleFor(x => x.DeviceName).NotEmpty();
            RuleFor(x => x.DeviceId).NotEmpty();
            RuleFor(x => x.HumidityCount).GreaterThan(0);
            RuleFor(x => x.FirstReadingDtm).NotNull();
            RuleFor(x => x.LastReadingDtm).NotNull();
        }
    }
}
