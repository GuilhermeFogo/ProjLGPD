using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
using LGPD.Transformar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Services
{
    public class DataMappingService : IDataMappingService
    {
        private IDataMappingRepository dataMappingRepository;

        public DataMappingService(IDataMappingRepository dataMappingRepository)
        {
            this.dataMappingRepository = dataMappingRepository;
        }

        public IEnumerable<DatamappingDTO> ListarTudo()
        {
            var todos = this.dataMappingRepository.ListarTodos();
            return Parsers.ParseClass2DTO(todos);
        }

        public IEnumerable<DatamappingDTO> PesquisarPorArea(DatamappingDTO datamappingDTO)
        {
            var pesquisaDatamapping = this.dataMappingRepository.Pesquisa_PorArea(datamappingDTO.Area);
            if (pesquisaDatamapping == null)
            {
                return null;
            }
            return Parsers.ParseClass2DTO(pesquisaDatamapping);
        }

        public IEnumerable<DatamappingDTO> PesquisarPorEmpresaeArea(DatamappingDTO datamappingDTO)
        {
            var pesquisa = this.dataMappingRepository.Pesquisa_PorEmpresa_e_Area(datamappingDTO.Empresa, datamappingDTO.Area);
            if (pesquisa == null)
            {
                return null;
            }
            return Parsers.ParseClass2DTO(pesquisa);
        }

        public void Save(DatamappingDTO dataMapping)
        {

            this.dataMappingRepository.Save(Parsers.ParseDTO2Class(dataMapping));
        }
    }
}
