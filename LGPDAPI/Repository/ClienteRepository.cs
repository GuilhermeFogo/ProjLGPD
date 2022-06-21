using LGPD.Modal;
using LGPD.Repository.Data;
using LGPD.Repository.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext clientesDB;
        public ClienteRepository(DataContext dataContext)
        {
            this.clientesDB = dataContext;
        }

        public void Atualizar(Cliente cliente)
        {
            var cliente_db = this.clientesDB.Clientes.Where((x) =>  x.Id == cliente.Id).FirstOrDefault();
            cliente_db.Nome = cliente.Nome;
            cliente_db.Telefone = cliente.Telefone;
            cliente_db.Email = cliente.Email;
            cliente_db.Consentimento = cliente.Consentimento;
            cliente_db.Endereco.Rua = cliente.Endereco.Rua;
            cliente_db.Endereco.CEP = cliente.Endereco.CEP;
            cliente_db.Endereco.Bairo = cliente.Endereco.Bairo;
            cliente_db.Endereco.Complemento = cliente.Endereco.Complemento;
            
            this.clientesDB.Update(cliente_db);
            this.clientesDB.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {

            var cliente_db = this.clientesDB.Clientes.Where((x) => x.Id == cliente.Id).FirstOrDefault();
            this.clientesDB.Remove(cliente_db);
            this.clientesDB.SaveChanges();
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var JoinClientes = this.JoinClientes();
            return JoinClientes.AsEnumerable<Cliente>().ToList();
        }

        public Cliente PesquisaCliente(int id)
        {
            var JoinClientes= this.JoinClientes();
            var cliente =  JoinClientes.Where((cliente) => cliente.Id == id);
            return cliente.AsEnumerable().FirstOrDefault();
        }

        public void Save(Cliente cliente)
        {
            this.clientesDB.Add(cliente);
            this.clientesDB.SaveChanges();
        }


        private IQueryable<Cliente> JoinClientes()
        {
            var JoinClientes = this.clientesDB.Clientes.Join(this.clientesDB.Enderecos,
                (cliente => cliente.Id),
                (endereco => endereco.Id),
                (cliente, endereco) => new Cliente(
                    cliente.Nome,
                    cliente.Email,
                    cliente.Telefone,
                    endereco.Rua,
                    endereco.CEP,
                    endereco.Complemento,
                    endereco.Bairo,
                    endereco.Id,
                    cliente.Id,
                    cliente.Consentimento
                    )
                );

            return JoinClientes;
        }
    }
}
