using LGPD.DTO;
using LGPD.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataMappingController : ControllerBase
    {
        public IDataMappingService DataMappingService;
        public DataMappingController(IDataMappingService dataMappingService)
        {
            this.DataMappingService = dataMappingService;
        }

        [Route("[controller]/Pesquisa")]
        [HttpPost]
        [Authorize(Roles = "Funcionario, ADM")]
        public DatamappingDTO PesquisaTeste([FromBody]DatamappingDTO area)
        {
            return this.DataMappingService.PesquisarPorArea(area.Area);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, ADM")]
        public IActionResult Save([FromBody] DatamappingDTO datamappingDTO)
        {
            this.DataMappingService.Save(datamappingDTO);
            return Ok();
        }

    }
}
