using Dominio.Exceptions;
using Dominio.InterfacesRepositorio;
using DTOs.DTOs;
using DTOs.Mappers;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StellarMinds.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {

        private StellarMindsContext _context;
        public RepositorioUsuarioEF(StellarMindsContext context)
        {
            _context = context;
        }
        public void Alta(Usuario unUsuario)
        {
            
            unUsuario.Validar();
            _context.Usuarios.Add(unUsuario);
            _context.SaveChanges();
            
        }

        public Usuario? FindByUsername(string username)
        {
            return _context.Usuarios
                           .FirstOrDefault(usuario => usuario.Username == username);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios;
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
        }

        public void Update(Usuario aActualizar)
        {
            throw new NotImplementedException();
        }
    }
}
