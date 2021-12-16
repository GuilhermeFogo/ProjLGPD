using LGPD.Modal;
using LGPD.Repository.Data;
using LGPD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository
{
    public class ProcessosRepository : IProcessoRepository
    {
        public DataContext dbProcessos { get; set; }

        public ProcessosRepository(DataContext dbProcessos)
        {
            this.dbProcessos = dbProcessos;
        }

        public void Atualizacao(Processo processo)
        {
            this.dbProcessos.Update(processo);
        }

        public void Delete(Processo processo)
        {
            this.dbProcessos.Remove(processo);
        }

        public IEnumerable<Processo> ListaTudo()
        {
            var lista = this.JoinProcesso().AsEnumerable();
            return lista;
        }

        public void Save(Processo processo)
        {
            this.dbProcessos.Add(processo);
            this.dbProcessos.SaveChanges();
        }


        private IQueryable<Processo> JoinProcesso()
        {
            var JoinDados = this.dbProcessos.Processos.Join(this.dbProcessos.Dados,
                (processo => processo.Id),
                (dados => dados.id_dado),
                (processo, dado) => new Processo()
                {
                    Descricao_processo = processo.Descricao_processo,
                    Armazenamento_Digital = processo.Armazenamento_Digital,
                    Id = processo.Id,
                    Macroprocesso = processo.Macroprocesso,
                    Armazenamento_Fisico = processo.Armazenamento_Fisico,
                    Compartilhamento_Externo = processo.Compartilhamento_Externo,
                    Compartilhamento_interno = processo.Compartilhamento_interno,
                    Controlador = processo.Controlador,
                    Dado = new Dados()
                    {
                        Dados_regulares = dado.Dados_regulares,
                        Dados_Senssiveis = dado.Dados_Senssiveis,
                        id_dado = dado.id_dado
                    },
                    Destino_final = processo.Destino_final,
                    Operador = processo.Operador,
                    BaseLegal = processo.BaseLegal,
                    descricaoBase = processo.descricaoBase,
                    Subprocesso = processo.Subprocesso
                });

            return JoinDados;
        }
    }
}
