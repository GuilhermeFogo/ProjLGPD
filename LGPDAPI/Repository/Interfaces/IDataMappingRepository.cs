using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository.Interfaces
{
    public interface IDataMappingRepository
    {
        public void Save(DataMapping dataMapping);

        public void Atualizacao(DataMapping dataMapping);

        public void Delete(DataMapping dataMapping);

        public IEnumerable<DataMapping> Pesquisa_PorEmpresa(string empresa);
        public IEnumerable<DataMapping> Pesquisa_PorArea(string area);
        public IEnumerable<DataMapping> Pesquisa_PorEmpresa_e_Area(string empresa, string area);

    }
}
