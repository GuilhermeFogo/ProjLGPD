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

        [Route("[controller]/Listar")]
        [HttpGet]
        [Authorize(Roles = "Funcionario, ADM, Gerente")]
        public IActionResult ListaTodos()
        {

            return Ok(this.DataMappingService.ListarTudo());
        }

        [Route("[controller]/PesquisaEmpresaeArea")]
        [HttpPost]
        [Authorize(Roles = "Funcionario, ADM, Gerente")]
        public IActionResult PesquisaTeste([FromBody] DatamappingDTO area)
        {
            var dados = this.DataMappingService.PesquisarPorEmpresaeArea(area);
            return Ok(dados);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, ADM, Gerente")]
        public IActionResult Save([FromBody] DatamappingDTO datamappingDTO)
        {
            if (!string.IsNullOrEmpty(datamappingDTO.Area) && !string.IsNullOrEmpty(datamappingDTO.Empresa) && !string.IsNullOrEmpty(datamappingDTO.Descricao_processo) &&
                !string.IsNullOrEmpty(datamappingDTO.Dados_regulares) && !string.IsNullOrEmpty(datamappingDTO.Dados_Senssiveis))
            {
                this.DataMappingService.Save(datamappingDTO);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
