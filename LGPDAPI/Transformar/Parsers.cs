﻿using Autenticacao.Modal;
using LGPD.DTO;
using LGPD.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Transformar
{
    public static class Parsers
    {
        public static Usuario ParseUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome,
                Role = MyRolesINT(usuarioDTO.Role),
                Senha = usuarioDTO.Senha,
                Email = usuarioDTO.Email,
                Ativado = usuarioDTO.Ativado
            };
        }

        public static UsuarioDTO ParseUsuario(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Role = MyRolesstrig(usuario.Role),
                Senha = usuario.Senha,
                Email = usuario.Email,
                Ativado = usuario.Ativado
            };
        }


        private static string MyRolesINT(int inteito)
        {
            switch (inteito)
            {
                case 1:
                    return "Funcionario";
                case 2:
                    return "Cliente";
                case 3:
                    return "Gerente";
                case 4:
                    return "ADM";
                default:
                    return "Cliente";
            }
        }

        private static int MyRolesstrig(string inteito)
        {
            switch (inteito)
            {
                case "Funcionario":
                    return 1;
                case "Cliente":
                    return 2;
                case "Gerente":
                    return 3;
                case "ADM":
                    return 4;
                default:
                    return 2;
            }
        }

        public static UsuarioDTO HidePass(UsuarioDTO usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Role = usuario.Role,
                Senha = "",
                Email = usuario.Email,
                Ativado = usuario.Ativado
            };
        }

        public static DatamappingDTO ParseClass2DTO(DataMapping dataMapping)
        {
            return new DatamappingDTO
            {
                Area = dataMapping.Area,
                Area_subprocesso = dataMapping.Processo.Subprocesso,
                Armazenamento_Digital = dataMapping.Processo.Armazenamento_Digital,
                Armazenamento_Fisico = dataMapping.Processo.Armazenamento_Fisico,
                BaseLegal_lei = dataMapping.Processo.BaseLegal,
                Compartilhamento_Externo = dataMapping.Processo.Compartilhamento_Externo,
                Compartilhamento_interno = dataMapping.Processo.Compartilhamento_interno,
                Controlador = dataMapping.Processo.Controlador,
                Dados_regulares = dataMapping.Processo.Dado.Dados_regulares,
                Dados_Senssiveis = dataMapping.Processo.Dado.Dados_Senssiveis,
                descricaoBase_lei = dataMapping.Processo.descricaoBase,
                Descricao_processo = dataMapping.Processo.Descricao_processo,
                Destino_final = dataMapping.Processo.Destino_final,
                Empresa = dataMapping.Empresa,
                IdProceso = dataMapping.Processo.Id,
                id_dado = dataMapping.Processo.Dado.id_dado,
                Id_DataMapping = dataMapping.Id_DataMapping,
                Nome = dataMapping.Processo.Macroprocesso,
                Operador = dataMapping.Processo.Operador,
                Responsavel = dataMapping.Responsavel,
                Subproceso_nome = dataMapping.Processo.Subprocesso
            };
        }

        public static DataMapping ParseDTO2Class(DatamappingDTO dataMapping)
        {
            return new DataMapping
            {
                Area = dataMapping.Area,
                Empresa = dataMapping.Empresa,
                Id_DataMapping = dataMapping.Id_DataMapping,
                Responsavel = dataMapping.Responsavel,
                Processo = new Processo()
                {
                    Armazenamento_Digital = dataMapping.Armazenamento_Digital,
                    Armazenamento_Fisico = dataMapping.Armazenamento_Fisico,
                    BaseLegal = dataMapping.BaseLegal_lei,
                    Compartilhamento_Externo = dataMapping.Compartilhamento_Externo,
                    Compartilhamento_interno = dataMapping.Compartilhamento_interno,
                    Controlador = dataMapping.Controlador,
                    Dado = new Dados()
                    {
                        Dados_regulares = dataMapping.Dados_regulares,
                        Dados_Senssiveis = dataMapping.Dados_Senssiveis,
                        id_dado = dataMapping.id_dado
                    },
                    descricaoBase = dataMapping.descricaoBase_lei,
                    Descricao_processo = dataMapping.Descricao_processo,
                    Destino_final = dataMapping.Destino_final,
                    Id = dataMapping.IdProceso,
                    Macroprocesso = dataMapping.Nome,
                    Operador = dataMapping.Operador,
                    Subprocesso = dataMapping.Subproceso_nome

                }
            };
        }


        public static Cliente TransformDTOtoCliente(ClienteDTO clienteDTO)
        {
            return new Cliente
            {
                Nome = clienteDTO.Nome,
                Email = clienteDTO.Email,
                Id = clienteDTO.Id,
                Telefone = clienteDTO.Telefone,
                Endereco = new Endereco
                {
                    Rua = clienteDTO.Rua,
                    Bairo = clienteDTO.Bairo,
                    CEP = clienteDTO.CEP,
                    Complemento = clienteDTO.Complemento,
                    Id = clienteDTO.Id_Endereco
                },
                Consentimento = clienteDTO.Consentimento
            };
        }

        public static ClienteDTO TransformClienteTODTO(Cliente cliente)
        {
            return new ClienteDTO(
                cliente.Nome, cliente.Email, cliente.Telefone, cliente.Endereco.Rua, cliente.Endereco.CEP, cliente.Endereco.Complemento, cliente.Endereco.Bairo,
                cliente.Endereco.Id, cliente.Id, cliente.Consentimento);
        }


        public static IEnumerable<ClienteDTO> TransformInListaDTO(IEnumerable<Cliente> lista)
        {
            var listaDTOS = new List<ClienteDTO>();
            foreach (Cliente cliente in lista)
            {
                var trasforma = TransformClienteTODTO(cliente);
                listaDTOS.Add(trasforma);
            }

            return listaDTOS;
        }

        public static UsuarioAutentic ParseUsuarioAuth(Usuario usuario)
        {
            return new UsuarioAutentic
            {
                Nome = usuario.Nome,
                Role = usuario.Role,
                Senha = usuario.Senha
            };
        }
    }
}
