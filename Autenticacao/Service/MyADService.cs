using Autenticacao.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticacao.Modal;
using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Runtime.Versioning;

namespace Autenticacao.Service
{
    public class MyADService : IAutenticaAD
    {
        public string Autenticar(UsuarioAutentic usuarioAutentic)
        {
            return null;
        }

        [SupportedOSPlatform("windows")]
        public string AutenticarWindows(UsuarioAutentic usuarioAutentic)
        {

            // Cria um contexto principal para definir a busca na base do AD.
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);

            // Cria uma query do Active Directory Domain Services.
            DirectorySearcher directorySearcher = new DirectorySearcher(principalContext.ConnectedServer);

            // Cria um filtro para a busca com o login do usuário da rede.
            directorySearcher.Filter = "(sAMAccountName=" + System.Environment.UserName + ")";

            /*
            * Cria um elemento da hierarquia do Active Directory.
            * Este elemento é retornado durante uma busca através de DirectorySearcher.
            */
            SearchResult searchResult = directorySearcher.FindOne();

            // Cria um objeto encapsulado da hierarquia de diretório serviços do AD.
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();

            return directoryEntry.Properties["displayName"][0].ToString();
            //============================================================================================================================================
            //try
            //{
            //    DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://dominio.com:389", usuarioAutentic.Nome, usuarioAutentic.Senha);
            //    DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
            //    directorySearcher.Filter = "(SAMAccountName=" + usuarioAutentic.Nome + ")";
            //    SearchResult searchResult = directorySearcher.FindOne();
            //    if ((Int32)searchResult.Properties["userAccountControl"][0] == 512)
            //    {
            //         return "Usuário Autenticado!";
            //    }
            //    else
            //    {
            //        return "ERRO: Usuário/Senha Inválido!";
            //    }
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        //public void CriarUserAD()
        //{
        //    using (var contextoPrincipal = new PrincipalContext(ContextType.Domain))
        //    {
        //        using (var usuarioPrincipal = new UserPrincipal(contextoPrincipal))
        //        {
        //            usuarioPrincipal.SamAccountName = "";
        //            usuarioPrincipal.EmailAddress = "";
        //            usuarioPrincipal.SetPassword("");
        //            usuarioPrincipal.Enabled = true; // Aqui você ativa essa conta, poderia não ativar, dependendo do caso de uso
        //            usuarioPrincipal.ExpirePasswordNow();
        //            usuarioPrincipal.Save();
        //        }
        //    }
        //}
    }
}
