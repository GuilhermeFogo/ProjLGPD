using LGPD.Modal;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
using LGPD.Transformar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace LGPD.Services
{
    public class RelatoriosService : IRelatorioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly string diretorio;

        public RelatoriosService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.diretorio = Diretoriobase();
        }
        public FileStream GerarRelatorioUser()
        {
            
            var dados = this.usuarioRepository.ListarTodos();
            string nome = $"{this.diretorio}/Relatorio_Usuario_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}.csv";
            using (FileStream f = new FileStream(nome, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    string[] titulo = { "Id", "Nome","Role", "Email" };
                    foreach (var item in titulo)
                    {
                        s.Write(item + " |");
                    }
                    s.WriteLine(" ");
                    foreach (var item in dados)
                    {

                        s.Write(item.Id + "| ");
                        s.Write(item.Nome + " |");
                        s.Write(item.Role + " |");
                        s.Write(item.Email + " |");
                        s.WriteLine(" ");
                    }
                    s.Close();
                }
                f.Close();
                return f;
            }
        }

        private string Diretoriobase()
        {
            string diretoriobase = "./Relatorios";
            try
            {
                Directory.Delete($"{diretoriobase}", true);
                Directory.CreateDirectory($"{diretoriobase}");
            }
            catch (Exception e)
            {
                Directory.CreateDirectory($"{diretoriobase}");
            }
            return diretoriobase;
        }
    }
}
