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
            return pesquisa.AsEnumerable();
        }

        public IEnumerable<DataMapping> Pesquisa_PorEmpresa(string empresa)
        {
            var pesquisa = this.JoinDatamapping().Where(x => x.Empresa == empresa);
            return pesquisa.AsEnumerable();
        }

        public IEnumerable<DataMapping> Pesquisa_PorEmpresa_e_Area(string empresa, string area)
        {
            var pesquisa = this.JoinDatamapping().Where(x => x.Empresa == empresa && x.Area == area);

            return pesquisa.AsEnumerable();
            
        }

        public void Save(DataMapping dataMapping)
        {
            this.dataContext.Add(dataMapping);
            this.dataContext.SaveChanges();
        }

        private IQueryable<DataMapping> JoinDatamapping()
        {
            var JoinDados = this.dataContext.DataMappings.Join(
                this.dataContext.Dados,
                (mapp => mapp.Id_DataMapping),(dado => dado.id_dado),
                (mapp, dado)=> new { mapp, dado}
                ).Join(
                this.dataContext.Processos,(mapps => mapps.mapp.Id_DataMapping), (process => process.Id),
                (mapps, process)=> new  DataMapping{
                    Area = mapps.mapp.Area,
                    Empresa = mapps.mapp.Empresa,
                    Id_DataMapping = mapps.mapp.Id_DataMapping, 
                    Responsavel = mapps.mapp.Responsavel,
                    Processo = new Processo()
                    {
                        Armazenamento_Digital = process.Armazenamento_Digital,
                        Armazenamento_Fisico = process.Armazenamento_Fisico,
                        BaseLegal = process.BaseLegal,
                        Compartilhamento_Externo = process.Compartilhamento_Externo,
                        Compartilhamento_interno = process.Compartilhamento_interno,
                        Controlador  =process.Controlador,
                        Dado = new Dados()
                        {
                            Dados_regulares = process.Dado.Dados_regulares,
                            Dados_Senssiveis = process.Dado.Dados_Senssiveis,
                            id_dado = process.Dado.id_dado
                        },
                        descricaoBase = process.descricaoBase,
                        Descricao_processo = process.Descricao_processo,
                        Destino_final = process.Destino_final,
                        Id = process.Id,
                        Macroprocesso =process.Macroprocesso,
                        Operador = process.Operador,
                        Subprocesso = process.Subprocesso
                    }
                }
                );


            return JoinDados;
        }
    }
}
