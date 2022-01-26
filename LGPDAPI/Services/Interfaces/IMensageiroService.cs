using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services.Interfaces
{
    public interface IMensageiroService
    {
        public void EmailPadrao(string para);
        public void EmailContato(string para, string assunto, string menagem);
    }
}
