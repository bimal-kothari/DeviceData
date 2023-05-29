using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeviceData.API.Models.Domain;
using DeviceData.API.Repositories;
using DeviceData.API.Helper;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Xml;
using DeviceData.API.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using System;
using System.Net.WebSockets;

namespace DeviceData.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceDataController : Controller
    {
        private readonly IDeviceDataRepository deviceDatarRepository;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeviceDataController(IDeviceDataRepository deviceDatarRepository, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {
            this.deviceDatarRepository = deviceDatarRepository;
            this.mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var _rootPath = _hostingEnvironment.ContentRootPath; //get the root path

            var _sampleJsonFile1Path = Path.Combine(_rootPath, "Data\\DeviceDataFoo1.json"); //combine the root path with that of our json file inside mydata directory
            var _sampleJsonFile2Path = Path.Combine(_rootPath, "Data\\DeviceDataFoo2.json"); //combine the root path with that of our json file inside mydata directory

            var _deviceData = await deviceDatarRepository.GetAllDataAsync(_sampleJsonFile1Path, _sampleJsonFile2Path);

            var deviceDataDTO = mapper.Map<List<Models.DTO.DeviceDataDTO>>(_deviceData);

            return Ok(deviceDataDTO);
        }






    }
}
