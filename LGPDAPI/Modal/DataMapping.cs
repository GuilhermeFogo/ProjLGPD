using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Modal
{
    [Serializable]
    public class DataMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_DataMapping { get; set; }
        public string Empresa { get; set; }
        public string Area { get; set; }
        public string Responsavel { get; set; }
        public Processo Processo { get; set; }
    }
}
