using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services.Interfaces
{
    public interface IRelatorioService
    {
        public FileStream GerarRelatorioUser();
    }
}
