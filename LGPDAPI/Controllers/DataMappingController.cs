using LGPD.DTO;
using LGPD.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente")]
        public DatamappingDTO PesquisaTeste(string area)
        {
            return this.DataMappingService.PesquisarPorArea(area);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, Gerente")]
        public IActionResult Save(DatamappingDTO datamappingDTO)
        {
            this.DataMappingService.Save(datamappingDTO);
            return Ok();
        }

    }
}
