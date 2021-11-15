using LGPD.DTO;
using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services.Interfaces
{
    public interface IAutenticacao
    {
        public string Autenticar(UsuarioDTO usuario);
    }
}
