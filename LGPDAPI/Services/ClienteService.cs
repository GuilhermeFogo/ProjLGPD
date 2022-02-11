

using LGPD.DTO;
using LGPD.Modal;
using LGPD.Repository.Interfaces;
using LGPD.Services.Interfaces;
using LGPD.Transformar;
using System;
using System.Collections.Generic;

namespace LGPD.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }


        public void Atualizar(ClienteDTO cliente)
        {
            var clientes = Parsers.TransformDTOtoCliente(cliente);
            this.clienteRepository.Atualizar(clientes);
        }

        public void Delete(ClienteDTO cliente)
        {
            var clientes = Parsers.TransformDTOtoCliente(cliente);
            this.clienteRepository.Delete(clientes);
        }

        public IEnumerable<ClienteDTO> ListarTodos()
        {
           var listaClientes = this.clienteRepository.ListarTodos();
            var transfom = Parsers.TransformInListaDTO(listaClientes);
            return transfom;
           
        }

        public void Save(ClienteDTO cliente)
        {
            var clientes = Parsers.TransformDTOtoCliente(cliente);
            this.clienteRepository.Save(clientes);
        }

        public ClienteDTO PesquisarCliente(int id)
        {
            var cliente = this.clienteRepository.PesquisaCliente(id);
            return Parsers.TransformClienteTODTO(cliente);
        }
    }
}
