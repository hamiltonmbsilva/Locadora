using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Repository.Context
{
    public class BaseContext : IdentityDbContext
    {
        //private readonly string _connectionString;
        
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) 
        {
            Database.EnsureCreated();
           // _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //public BaseContext(IConfiguration configuration)
        //{            
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //    Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseNpgsql(_connectionString, options => options.SetPostgresVersion(new Version(9, 6)));

        //    //base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseMySql(_connectionString);

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         
            Cliente.Map(modelBuilder);
            Filme.Map(modelBuilder);
            Locacao.Map(modelBuilder);
        }
     
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Filme> empresas { get; set; }
        public DbSet<Locacao> vouchers { get; set; }
    }
}
