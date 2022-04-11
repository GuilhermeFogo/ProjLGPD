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
    public class RelatorioControler : ControllerBase
    {
        private readonly IRelatorioService relatorio;

        public RelatorioControler(IRelatorioService relatorio)
        {
            this.relatorio = relatorio;
        }
        
        [HttpGet("Usuario")]
        public string Get()
        {
            var arquivo =relatorio.GerarRelatorioUser();
            var a2 =File(arquivo.Name, "text/csv");
            a2.FileDownloadName = a2.FileName;
            return a2.FileDownloadName;
        }
    }
}
