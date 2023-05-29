namespace DeviceData.API.Models.Domain
{
    public class DeviceData
    {
        public string CompanyName { get; set; } // Foo1: PartnerName, Foo2: Company
        public int? DeviceId { get; set; } // Foo1: Id, Foo2: DeviceID
        public string DeviceName { get; set; } // Foo1: Model, Foo2: Name
        public DateTime? FirstReadingDtm { get; set; } // Foo1: Trackers.Sensors.Crumbs, Foo2: Devices.SensorData
        public DateTime? LastReadingDtm { get; set; }
        public int? TemperatureCount { get; set; }
        public decimal? AverageTemperature { get; set; }
        public int? HumidityCount { get; set; }
        public decimal? AverageHumdity { get; set; }


    }

    public class DeviceTempData
    {
        public string CompanyName { get; set; } // Foo1: PartnerName, Foo2: Company
        public int? DeviceId { get; set; } // Foo1: Id, Foo2: DeviceID
        public string DeviceName { get; set; } // Foo1: Model, Foo2: Name
        public DateTime? FirstReadingDtm { get; set; } // Foo1: Trackers.Sensors.Crumbs, Foo2: Devices.SensorData
        public DateTime? LastReadingDtm { get; set; }
        public int? TemperatureCount { get; set; }
        public decimal? AverageTemperature { get; set; }
        public int? HumidityCount { get; set; }
        public decimal? AverageHumdity { get; set; }


    }

    public class LastReadingTempDtm
    {
        public DateTime? LastReadingDtm { get; set; } // Foo1: Trackers.Sensors.Crumbs, Foo2: Devices.SensorData
        public string type { get; set; }
        public decimal Value { get; set; }
    }
}
