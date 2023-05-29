using Microsoft.EntityFrameworkCore;
using DeviceData.API.Data;
using DeviceData.API.Models.Domain;
using DeviceData.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;
using System;

namespace DeviceData.API.Repositories
{
    public class DeviceDataRepository : IDeviceDataRepository
    {
        //private readonly DeviceDataDbContext nDeviceDataDbContext;
        List<Models.Domain.LastReadingTempDtm> lstcomputeFoo1Data = new List<Models.Domain.LastReadingTempDtm>();
        List<Models.Domain.LastReadingTempDtm> lstcomputeAverageTemperatureFoo1Data = new List<Models.Domain.LastReadingTempDtm>();
        List<Models.Domain.LastReadingTempDtm> lstcomputeAverageHumdityFoo1Data = new List<Models.Domain.LastReadingTempDtm>();

        List<Models.Domain.LastReadingTempDtm> lstcomputeFoo2Data = new List<Models.Domain.LastReadingTempDtm>();
        List<Models.Domain.LastReadingTempDtm> lstcomputeAverageTemperatureFoo2Data = new List<Models.Domain.LastReadingTempDtm>();
        List<Models.Domain.LastReadingTempDtm> lstcomputeAverageHumdityFoo2Data = new List<Models.Domain.LastReadingTempDtm>();

        double averageTemperatureData = 0.0;
        double averageHumdityData = 0.0;

        public async Task<IEnumerable<Models.Domain.DeviceData>> GetAllDataAsync(string _sampleJsonFile1Path, string _sampleJsonFile2Path)
        {
            Foo1Models file1Data;
            Foo2Models file2Data;
            List<Models.Domain.DeviceData> deviceData = new List<Models.Domain.DeviceData>();

            using (StreamReader r1 = new StreamReader(_sampleJsonFile1Path))
            {
                string json1 = r1.ReadToEnd();
                file1Data = JsonConvert.DeserializeObject<Foo1Models>(json1);
            }
            using (StreamReader r2 = new StreamReader(_sampleJsonFile2Path))
            {
                string json2 = r2.ReadToEnd();
                file2Data = JsonConvert.DeserializeObject<Foo2Models>(json2);
            }
            int cnt = 0;
            computeFoo1Data(file1Data);
            computeAverageTemperatureFoo1Data(file1Data);
            computeAverageHumdityFoo1Data(file1Data);

            computeFoo2Data(file2Data);
            computeAverageTemperatureFoo2Data(file2Data);
            computeAverageHumdityFoo2Data(file2Data);

            foreach (var i in file1Data.Trackers)
            {

                deviceData.Add(new Models.Domain.DeviceData
                {
                    CompanyName = file1Data.PartnerName,
                    DeviceId = i.Id,
                    DeviceName = i.Model,
                    FirstReadingDtm = lstcomputeFoo1Data.Min(item => item.LastReadingDtm),
                    LastReadingDtm = lstcomputeFoo1Data.Max(item => item.LastReadingDtm),
                    TemperatureCount = lstcomputeFoo1Data.FindAll(item => item.type.Contains("Temperature")).Count,
                    AverageTemperature = lstcomputeAverageTemperatureFoo1Data.Average(item => item.Value),
                    HumidityCount = lstcomputeFoo1Data.FindAll(item => item.type.Contains("Humidty")).Count,
                    AverageHumdity = lstcomputeAverageHumdityFoo1Data.Average(item => item.Value)
                });
                cnt += 1;
            }

            foreach (var i in file2Data.Devices)
            {

                deviceData.Add(new Models.Domain.DeviceData
                {
                    CompanyName = file1Data.PartnerName,
                    DeviceId = i.DeviceID,
                    DeviceName = i.Name,
                    FirstReadingDtm = lstcomputeFoo2Data.Min(item => item.LastReadingDtm),
                    LastReadingDtm = lstcomputeFoo2Data.Max(item => item.LastReadingDtm),
                    TemperatureCount = lstcomputeFoo2Data.FindAll(item => item.type.Contains("TEMP")).Count,
                    AverageTemperature = lstcomputeAverageTemperatureFoo2Data.Average(item => item.Value),
                    HumidityCount = lstcomputeFoo2Data.FindAll(item => item.type.Contains("HUM")).Count,
                    AverageHumdity = lstcomputeAverageHumdityFoo2Data.Average(item => item.Value)
                });
                cnt += 1;
            }
            return deviceData;
        }

        public void computeFoo1Data(Foo1Models file1Data)
        {
                        
            foreach (var x in file1Data.Trackers)
            {
               
                foreach (var y in x.Sensors)
                {
                    int cnt = 0;
                    string type = y.Name;
                    foreach (var z in y.Crumbs)
                    {

                        lstcomputeFoo1Data.Add(new Models.Domain.LastReadingTempDtm
                        {
                            LastReadingDtm = z.CreatedDtm,
                            type = type,
                            Value = z.Value
                        });                  

                    }
                    
                    cnt += 1;

                }

            }           

            return;
        }

        public void computeAverageTemperatureFoo1Data(Foo1Models file1Data)
        {

            foreach (var x in file1Data.Trackers)
            {

                foreach (var y in x.Sensors)
                {
                    int cnt = 0;
                    string type = y.Name;
                    
                    foreach (var z in y.Crumbs)
                    {
                        if (type.Contains("Temperature") || type.Contains("TEMP"))
                        {
                            lstcomputeAverageTemperatureFoo1Data.Add(new Models.Domain.LastReadingTempDtm
                            {
                                LastReadingDtm = z.CreatedDtm,
                                type = type,
                                Value = z.Value
                            });
                        }                       

                    }

                    cnt += 1;

                }

            }

            return;
        }

        public void computeAverageHumdityFoo1Data(Foo1Models file1Data)
        {

            foreach (var x in file1Data.Trackers)
            {

                foreach (var y in x.Sensors)
                {
                    int cnt = 0;
                    string type = y.Name;
                    foreach (var z in y.Crumbs)
                    {
                        if (type.Contains("Humidty") || type.Contains("HUM"))
                        {
                            lstcomputeAverageHumdityFoo1Data.Add(new Models.Domain.LastReadingTempDtm
                            {
                                LastReadingDtm = z.CreatedDtm,
                                type = type,
                                Value = z.Value
                            });
                        }
                    }

                    cnt += 1;

                }

            }

            return;
        }

        public void computeFoo2Data(Foo2Models file2Data)
        {
            foreach (var x in file2Data.Devices)
            {

                foreach (var y in x.SensorData)
                {
                    int cnt = 0;
                    string type = y.SensorType;
                    lstcomputeFoo2Data.Add(new Models.Domain.LastReadingTempDtm
                    {
                        LastReadingDtm = y.DateTime,
                        type = type,
                        Value = y.Value
                    });

                    cnt += 1;

                }

            }

            return;
        }

        public void computeAverageTemperatureFoo2Data(Foo2Models file2Data)
        {

            foreach (var x in file2Data.Devices)
            {

                foreach (var y in x.SensorData)
                {
                    int cnt = 0;
                    string type = y.SensorType;
                    if (type.Contains("Temperature") || type.Contains("TEMP"))
                    {
                        lstcomputeAverageTemperatureFoo2Data.Add(new Models.Domain.LastReadingTempDtm
                        {
                            LastReadingDtm = y.DateTime,
                            type = type,
                            Value = y.Value
                        });
                    }

                    cnt += 1;

                }

            }

            return;
        }

        public void computeAverageHumdityFoo2Data(Foo2Models file2Data)
        {

            foreach (var x in file2Data.Devices)
            {

                foreach (var y in x.SensorData)
                {
                    int cnt = 0;
                    string type = y.SensorType;
                    if (type.Contains("Humidty") || type.Contains("HUM"))
                    {
                        lstcomputeAverageHumdityFoo2Data.Add(new Models.Domain.LastReadingTempDtm
                        {
                            LastReadingDtm = y.DateTime,
                            type = type,
                            Value = y.Value
                        });
                    }

                    cnt += 1;

                }

            }

            return;
        }
    }
}
