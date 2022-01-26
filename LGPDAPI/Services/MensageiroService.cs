using LGPD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAPI.Mensagero;

namespace LGPD.Services
{
    public class MensageiroService : IMensageiroService
    {
        private readonly IMensageiro mensageiro;

        public MensageiroService(IMensageiro mensageiro)
        {
            this.mensageiro = mensageiro;
        }

        public void EmailContato(string para, string assunto, string menagem)
        {
            this.mensageiro.EnviarEmail(para, assunto, menagem);
        }

        public void EmailPadrao(string para)
        {
            string assunto = "Email padrao";
            string mensagem = "Seja bem Vindo(a) ao sistema LGPD";
            this.mensageiro.EnviarEmail(para,assunto,mensagem);
        }
    }
}
