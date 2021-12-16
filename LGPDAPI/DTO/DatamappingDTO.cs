using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.DTO
{
    public class DatamappingDTO
    {
        public int IdProceso { get; set; }
        public string Nome { get; set; }
        public int id_subprocesso { get; set; }
        public string Subproceso_nome { get; set; }
        public string Area_subprocesso { get; set; }
        public string Descricao_processo { get; set; }
        public int id_dado { get; set; }
        public string Dados_regulares { get; set; }
        public string Dados_Senssiveis { get; set; }
        public int Id_lei { get; set; }
        public string BaseLegal_lei { get; set; }
        public string descricaoBase_lei { get; set; }
        public string Compartilhamento_interno { get; set; }
        public string Compartilhamento_Externo { get; set; }
        public string Destino_final { get; set; }
        public string Controlador { get; set; }
        public string Operador { get; set; }
        public string Armazenamento_Fisico { get; set; }
        public string Armazenamento_Digital { get; set; }
        public int Id_DataMapping { get; set; }
        public string Empresa { get; set; }
        public string Area { get; set; }
        public string Responsavel { get; set; }
    }
}
