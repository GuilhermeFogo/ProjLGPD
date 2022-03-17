using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Role { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
