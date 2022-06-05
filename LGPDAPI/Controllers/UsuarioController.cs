
using LGPD.DTO;
using LGPD.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LGPD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioServices;
        private readonly IMensageiroService mensageiroService;

        public UsuarioController(IUsuarioService usuarioServices, IMensageiroService mensageiroService)
        {
            this.usuarioServices = usuarioServices;
            this.mensageiroService = mensageiroService;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize(Roles = "Funcionario, ADM")]
        public IEnumerable<UsuarioDTO> Get()
        {
            return this.usuarioServices.ListarTodos();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADM, Funcionario")]
        public IActionResult GetUsuer(int id)
        {
            if (id > 0)
            {
                var dto = this.usuarioServices.PesquisarUsuario(id);
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [Authorize(Roles = "Funcionario, ADM")]
        public IActionResult Post([FromBody] UsuarioDTO value)
        {
            if (value != null)
            {
                this.usuarioServices.Save(value);
                this.mensageiroService.EmailNovoUsuario(value);
                return Ok($"Usuario {value.Nome} Criado");
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ADM")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO != null && id > 0)
            {
                var usarioDB = this.usuarioServices.PesquisarUsuario(id);
                if (usarioDB.Id == usuarioDTO.Id)
                {
                    this.usuarioServices.Atualizar(usuarioDTO);
                    return Ok($"Usuario {usuarioDTO.Nome} Alterado");
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADM")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var user = this.usuarioServices.PesquisarUsuario(id);
                this.usuarioServices.Delete(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
