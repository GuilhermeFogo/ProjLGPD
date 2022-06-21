﻿using LGPD.Modal;
using LGPD.Repository.Data;
using LGPD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGPD.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext usuarioDB;

        public UsuarioRepository(DataContext usuarioDB)
        {
            this.usuarioDB = usuarioDB;
        }

        public void Atualizar(Usuario usuario)
        {
            var user = this.usuarioDB.Usuarios.Where((x) => x.Id == usuario.Id).FirstOrDefault();
            user.Nome = usuario.Nome;
            user.Role = usuario.Role;
            user.Ativado = usuario.Ativado;
            user.Email = usuario.Email;

            this.usuarioDB.Update(user);
            this.usuarioDB.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            var user = this.usuarioDB.Usuarios.Where((x) => x.Id == usuario.Id).FirstOrDefault();   
            this.usuarioDB.Remove(user);
            this.usuarioDB.SaveChanges();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return this.usuarioDB.Usuarios.ToList();
        }

        public Usuario PesquisaUsuario(int id)
        {
           var usu= this.usuarioDB.Usuarios.Where((x) => x.Id == id);
           return usu.AsEnumerable().FirstOrDefault();
        }

        public Usuario PesquisaUsuario(string nome)
        {
            var usu = this.usuarioDB.Usuarios.Where((x) => x.Nome == nome);
            return usu.AsEnumerable().FirstOrDefault();
        }

        public void Save(Usuario usuario)
        {
            this.usuarioDB.Add(usuario);
            this.usuarioDB.SaveChanges();
        }
    }
}
