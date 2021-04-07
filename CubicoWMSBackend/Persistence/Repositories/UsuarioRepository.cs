using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.Models;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Persistence.Repositories
{
    public class UsuarioRepository:IUsuarioRepository

    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validateExistence = await _context.Usuarios.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return validateExistence;

        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }
    }
}
