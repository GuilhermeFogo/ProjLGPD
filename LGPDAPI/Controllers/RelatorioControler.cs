using LGPD.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LGPD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RelatorioControler : ControllerBase
    {
        private readonly IRelatorioService relatorio;

        public RelatorioControler(IRelatorioService relatorio)
        {
            this.relatorio = relatorio;
        }
        
        [HttpGet("Usuario")]
        [Authorize(Roles ="ADM, Gerente")]
        public IActionResult Get()
        {
            var arquivo =relatorio.GerarRelatorioUser();
            return Ok(arquivo);
        }
    }
}
