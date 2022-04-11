using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Modal
{
    [Serializable]
    public class Dados
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_dado { get; set; }
        public string Dados_regulares { get; set; }
        public string Dados_Senssiveis { get; set; }
    }
}
