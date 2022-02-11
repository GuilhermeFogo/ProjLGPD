using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
using LGPD.Transformar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAPI.Mensagero;

namespace LGPD.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void Atualizar(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Atualizar(usu);
        }

        public void Delete(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Delete(usu);
        }

        public IEnumerable<UsuarioDTO> ListarTodos()
        {
            var lista = new List<UsuarioDTO>();
            var usu = this.usuarioRepository.ListarTodos();
            foreach (var item in usu)
            {
                var dto = Parsers.ParseUsuario(item);
                lista.Add(dto);
            }
            return lista;
        }

        public UsuarioDTO PesquisarUsuario(int id)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(id);
            return Parsers.ParseUsuario(usu);
        }

        public void Save(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Save(usu);
        }

        public UsuarioDTO PesquisarUsuario(string nome)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(nome);
            return Parsers.ParseUsuario(usu);
        }
    }
}
