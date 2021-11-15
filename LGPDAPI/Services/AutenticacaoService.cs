using Autenticacao.Modal;
using Autenticacao.Service.Interfaces;
using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services
{
    public class AutenticacaoService : IAutenticacao
    {
        private readonly ITokenService autenticacaoService;
        private readonly IUsuarioRepository usuarioRepository;
        public AutenticacaoService(ITokenService autenticacaoService, IUsuarioRepository usuarioRepository)
        {
            this.autenticacaoService = autenticacaoService;
            this.usuarioRepository = usuarioRepository;
        }
        public string Autenticar(UsuarioDTO usuario)
        {
            try
            {
                var usu = this.usuarioRepository.PesquisaUsuario(usuario.Nome);
                if (usu.Nome == usuario.Nome && usu.Senha == usuario.Senha)
                {
                    var user = this.ParseUsuario(usu);
                    return this.autenticacaoService.CriarToken(user);
                }

                return "Nome ou Senha Invalidos";
            }
            catch (Exception)
            {
                return null;
            }

        }

        private UsuarioAutentic ParseUsuario(Usuario usuario)
        {
            return new UsuarioAutentic
            {
                Nome = usuario.Nome,
                Role = usuario.Role,
                Senha = usuario.Senha
            };
        }
    }
}
