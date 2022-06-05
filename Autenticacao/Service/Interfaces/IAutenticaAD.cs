using Autenticacao.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Service.Interfaces
{
    public interface IAutenticaAD
    {
        public string Autenticar(UsuarioAutentic usuarioAutentic);
        public string AutenticarWindows(UsuarioAutentic usuarioAutentic);


    }
}
