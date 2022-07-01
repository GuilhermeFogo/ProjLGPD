using LGPD.Modal;
using LGPD.Repository.Data;
using LGPD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository
{
    public class DataMappingRepository : IDataMappingRepository
    {
        public DataContext dataContext { get; set; }

        public DataMappingRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Atualizacao(DataMapping dataMapping)
        {
            this.dataContext.Update(dataMapping);
        }

        public void Delete(DataMapping dataMapping)
        {
            this.dataContext.Remove(dataMapping);
        }

        public IEnumerable<DataMapping> Pesquisa_PorArea(string area)
        {
            var pesquisa = this.JoinDatamapping().Where(x => x.Area == area);
            return pesquisa.AsEnumerable().ToList();
        }

        public IEnumerable<DataMapping> Pesquisa_PorEmpresa(string empresa)
        {
            var pesquisa = this.JoinDatamapping().Where(x => x.Empresa == empresa);
            return pesquisa.AsEnumerable().ToList();
        }

        public IEnumerable<DataMapping> Pesquisa_PorEmpresa_e_Area(string empresa, string area)
        {
            var pesquisa = this.JoinDatamapping().Where(x => x.Empresa == empresa && x.Area == area);

            return pesquisa.AsEnumerable().ToList();

        }

        public void Save(DataMapping dataMapping)
        {
            this.dataContext.Add(dataMapping);
            this.dataContext.SaveChanges();
        }

        private IQueryable<DataMapping> JoinDatamapping()
        {
            var JoinDados = this.dataContext.DataMappings.Join(
                this.dataContext.Processos,
                (mapp => mapp.Processo.Id), (processo => processo.Id),
                (mapp, processo) => new { mapp, processo }
                ).Join(
                this.dataContext.Dados, (processos => processos.processo.Dado.id_dado), (dado => dado.id_dado),
                (mapps, dado) => new DataMapping
                {
                    Area = mapps.mapp.Area,
                    Empresa = mapps.mapp.Empresa,
                    Id_DataMapping = mapps.mapp.Id_DataMapping,
                    Responsavel = mapps.mapp.Responsavel,
                    Processo = new Processo()
                    {
                        Armazenamento_Digital = mapps.processo.Armazenamento_Digital,
                        Armazenamento_Fisico = mapps.processo.Armazenamento_Fisico,
                        BaseLegal = mapps.processo.BaseLegal,
                        Compartilhamento_Externo = mapps.processo.Compartilhamento_Externo,
                        Compartilhamento_interno = mapps.processo.Compartilhamento_interno,
                        Controlador = mapps.processo.Controlador,
                        Dado = new Dados()
                        {
                            Dados_regulares = dado.Dados_regulares,
                            Dados_Senssiveis = dado.Dados_Senssiveis,
                            id_dado = dado.id_dado
                        },
                        descricaoBase = mapps.processo.descricaoBase,
                        Descricao_processo = mapps.processo.Descricao_processo,
                        Destino_final = mapps.processo.Destino_final,
                        Id = mapps.processo.Id,
                        Macroprocesso = mapps.processo.Macroprocesso,
                        Operador = mapps.processo.Operador,
                        Subprocesso = mapps.processo.Subprocesso,
                        Area_controle = mapps.processo.Area_controle
                    }
                }
                );


            return JoinDados;
        }

        public IEnumerable<DataMapping> ListarTodos()
        {
            return this.JoinDatamapping().AsEnumerable();

        }
    }
}
