using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository.Interfaces
{
    public interface IProcessoRepository
    {
        public void Save(Processo processo);

        public void Atualizacao(Processo processo);

        public void Delete(Processo processo);

        public IEnumerable<Processo> ListaTudo();
    }
}
