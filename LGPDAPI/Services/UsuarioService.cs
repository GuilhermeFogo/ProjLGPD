using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
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
        private readonly IMensageiro mensageiro;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMensageiro mensageiro)
        {
            this.usuarioRepository = usuarioRepository;
            this.mensageiro = mensageiro;
        }

        public void Atualizar(UsuarioDTO user)
        {
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Atualizar(usu);
        }

        public void Delete(UsuarioDTO user)
        {
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Delete(usu);
        }

        public IEnumerable<UsuarioDTO> ListarTodos()
        {
            var lista = new List<UsuarioDTO>();
            var usu = this.usuarioRepository.ListarTodos();
            foreach (var item in usu)
            {
                var dto = ParseUsuario(item);
                lista.Add(dto);
            }
            lista.Sort();
            return lista;
        }

        public UsuarioDTO PesquisarUsuario(int id)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(id);
            return ParseUsuario(usu);
        }

        public void Save(UsuarioDTO user)
        {
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Save(usu);
            string assunto = "Boas Vindas";
            string mensagem = $"Seja Bem Vindo(a) {usu.Nome} ao programa de LGPD Suas credenciais de acesso são: Nome:{usu.Nome} e Senha:{usu.Senha}";

            this.mensageiro.EnviarEmail(usu.Email, assunto, mensagem);
        }


        private Usuario ParseUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome,
                Role = usuarioDTO.Role,
                Senha = usuarioDTO.Senha,
                Email = usuarioDTO.Email
            };
        }

        private UsuarioDTO ParseUsuario(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id, 
                Nome = usuario.Nome, 
                Role = usuario.Role,
                Senha = usuario.Senha,
                Email = usuario.Email
            };
        }

        public UsuarioDTO PesquisarUsuario(string nome)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(nome);
            return this.ParseUsuario(usu);
        }
    }
}
