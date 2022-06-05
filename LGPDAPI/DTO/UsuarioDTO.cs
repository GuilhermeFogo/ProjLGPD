﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.DTO
{
    public class UsuarioDTO: IComparable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Role { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public bool Ativado { get; set; }

        public int CompareTo(object obj)
        {
           var usuario2 = (UsuarioDTO) obj;
            if (this.Id == usuario2.Id)
            {
                return 1;
            }
            return 0;
        }
    }
}
