using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;

namespace DeviceData.API.Models
{
    public class Foo1Models
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }

        public List<Trackers> Trackers { get; set; }
    }
    public class Trackers
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public DateTime ShipmentStartDtm { get; set; }

        public List<Sensors> Sensors { get; set; }
    }
    public class Sensors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Crumbs> Crumbs { get; set; }

    }
    public class Crumbs
    {

        public DateTime CreatedDtm { get; set; }
        public decimal Value { get; set; }
    }

}
