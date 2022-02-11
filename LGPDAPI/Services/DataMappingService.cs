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

        public DatamappingDTO PesquisarPorArea(string area)
        {
            var pesquisaDatamapping =  this.dataMappingRepository.Pesquisa_PorArea(area);
            return Parsers.ParseClass2DTO(pesquisaDatamapping);
        }

        public void Save(DatamappingDTO dataMapping)
        {
            this.dataMappingRepository.Save(Parsers.ParseDTO2Class(dataMapping));
        }
    }
}
