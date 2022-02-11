using LGPD.DTO;
using LGPD.Services.Interfaces;
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

        public void EmailNovoUsuario(UsuarioDTO usuario)
        {
            string assunto = "<h1>Boas Vindas</h1>";
            string mensagem = $"<p>Seja Bem Vindo(a) {usuario.Nome}</p> <p>Ao programa de LGPD Suas credenciais de acesso são:</p> <p>Nome:{usuario.Nome}</p>" +
                $"<p> Senha:{usuario.Senha}</p>";

            this.mensageiro.EnviarEmailHTML(usuario.Email, assunto, mensagem);
        }
    }
}
