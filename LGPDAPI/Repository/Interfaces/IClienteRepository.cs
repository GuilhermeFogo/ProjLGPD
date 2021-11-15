using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository.Interfaces
{
    public interface IClienteRepository
    {
        void Save(Cliente cliente);
        void Delete(Cliente cliente);

        void Atualizar(Cliente cliente);

        IEnumerable<Cliente> ListarTodos();

        Cliente PesquisaCliente(int id);
    }
}
