using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
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
            return this.ParseClass2DTO(pesquisaDatamapping);
        }

        public void Save(DatamappingDTO dataMapping)
        {
            this.dataMappingRepository.Save(this.ParseDTO2Class(dataMapping));
        }


        private DatamappingDTO ParseClass2DTO(DataMapping dataMapping)
        {
            return new DatamappingDTO
            {
                Area = dataMapping.Area,
                Area_subprocesso = dataMapping.Processo.Subprocesso,
                Armazenamento_Digital = dataMapping.Processo.Armazenamento_Digital,
                Armazenamento_Fisico = dataMapping.Processo.Armazenamento_Fisico,
                BaseLegal_lei = dataMapping.Processo.BaseLegal,
                Compartilhamento_Externo = dataMapping.Processo.Compartilhamento_Externo,
                Compartilhamento_interno = dataMapping.Processo.Compartilhamento_interno,
                Controlador = dataMapping.Processo.Controlador,
                Dados_regulares = dataMapping.Processo.Dado.Dados_regulares,
                Dados_Senssiveis = dataMapping.Processo.Dado.Dados_Senssiveis,
                descricaoBase_lei = dataMapping.Processo.descricaoBase,
                Descricao_processo = dataMapping.Processo.Descricao_processo,
                Destino_final = dataMapping.Processo.Destino_final,
                Empresa = dataMapping.Empresa,
                IdProceso = dataMapping.Processo.Id,
                id_dado = dataMapping.Processo.Dado.id_dado,
                Id_DataMapping = dataMapping.Id_DataMapping,
                Nome = dataMapping.Processo.Macroprocesso,
                Operador = dataMapping.Processo.Operador,
                Responsavel = dataMapping.Responsavel,
                Subproceso_nome = dataMapping.Processo.Subprocesso
            };
        }


        private DataMapping ParseDTO2Class(DatamappingDTO dataMapping)
        {
            return new DataMapping
            {
                Area = dataMapping.Area,
                Empresa = dataMapping.Empresa,
                Id_DataMapping = dataMapping.Id_DataMapping,
                Responsavel = dataMapping.Responsavel,
                Processo = new Processo()
                {
                    Armazenamento_Digital = dataMapping.Armazenamento_Digital,
                    Armazenamento_Fisico = dataMapping.Armazenamento_Fisico,
                    BaseLegal = dataMapping.BaseLegal_lei,
                    Compartilhamento_Externo = dataMapping.Compartilhamento_Externo,
                    Compartilhamento_interno = dataMapping.Compartilhamento_interno,
                    Controlador = dataMapping.Controlador,
                    Dado = new Dados()
                    {
                        Dados_regulares = dataMapping.Dados_regulares,
                        Dados_Senssiveis = dataMapping.Dados_Senssiveis,
                        id_dado = dataMapping.id_dado
                    },
                    descricaoBase = dataMapping.descricaoBase_lei,
                    Descricao_processo = dataMapping.Descricao_processo,
                    Destino_final = dataMapping.Destino_final,
                    Id = dataMapping.IdProceso,
                    Macroprocesso = dataMapping.Nome,
                    Operador = dataMapping.Operador,
                    Subprocesso = dataMapping.Subproceso_nome
                    
                }
            };
        }
    }
}
