using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        void Save(Usuario usuario);
        void Delete(Usuario usuario);

        void Atualizar(Usuario usuario);

        IEnumerable<Usuario> ListarTodos();

        Usuario PesquisaUsuario(int id);
        Usuario PesquisaUsuario(string nome);
    }
}
