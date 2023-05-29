namespace DeviceData.API.Models
{
    public class Foo2Models
    {
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public List<Devices> Devices { get; set; }
    }
    public class Devices
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }
        public List<SensorData> SensorData { get; set; }
    }
    public class SensorData
    {
        public string SensorType { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Value { get; set; }
    }


}
