using ControlNetBackend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<SGAA_Usuario> CubicoUsuario { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
    }
}
