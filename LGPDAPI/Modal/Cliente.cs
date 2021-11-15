using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Modal
{
    public class Cliente : Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Consentimento { get; set; }

        public Cliente()
        {
            
        }

        public Cliente (string nome, string email, string tel, string rua, string cep, string complemento, string bairro, int id_endereco, int id, bool consentimento):
            base(nome,email,tel,rua,cep,complemento,bairro,id_endereco)
        {
            this.Id = id;
            this.Consentimento = consentimento;
        }
    }
}
