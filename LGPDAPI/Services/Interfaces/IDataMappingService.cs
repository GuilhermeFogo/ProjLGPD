using LGPD.DTO;
using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services.Interfaces
{
    public interface IDataMappingService
    {
        public void Save(DatamappingDTO dataMapping);

        public IEnumerable<DatamappingDTO> PesquisarPorEmpresaeArea(DatamappingDTO datamappingDTO);
        public IEnumerable<DatamappingDTO> PesquisarPorArea(DatamappingDTO datamappingDTO);
        public IEnumerable<DatamappingDTO> ListarTudo();

    }
}
