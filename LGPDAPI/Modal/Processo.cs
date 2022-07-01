using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Modal
{
    [Serializable]
    public class Processo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Macroprocesso { get; set; }
        public string Area_controle { get; set; }
        public string Subprocesso { get; set; }
        public string Descricao_processo { get; set; }
        public Dados Dado { get; set; }
        public string BaseLegal { get; set; }
        public string descricaoBase { get; set; }
        public string Compartilhamento_interno { get; set; }
        public string Compartilhamento_Externo { get; set; }
        public string Destino_final { get; set; }
        public string Controlador { get; set; }
        public string Operador { get; set; }

        public string Armazenamento_Fisico { get; set; }
        public string Armazenamento_Digital { get; set; }
    }
}
