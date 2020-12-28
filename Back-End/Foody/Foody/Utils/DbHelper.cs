﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foody.Models;

namespace Foody.Utils
{
    public class DbHelper : DbContext
    {
        public DbHelper()
        {

        }

        public DbSet<Administrador> administrador { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Empresa> empresa { get; set; }
        public DbSet<Condutor> condutor{ get; set; }
        public DbSet<Encomenda> encomenda { get; set; }
        public DbSet<EncomendaProduto> encomendaProduto { get; set; }
        public DbSet<Entrega> entrega { get; set; }
        public DbSet<Morada> morada { get; set; }
        public DbSet<Produto> produto { get; set; }
        public DbSet<Utilizador> utilizador { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= db/foodybd.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilizador>().HasKey(u => new { u.idMorada });
            modelBuilder.Entity<Administrador>().HasKey(a => new { a.idUtilizador });
            modelBuilder.Entity<Cliente>().HasKey(cl => new { cl.idUtilizador });
            modelBuilder.Entity<Condutor>().HasKey(c => new { c.idUtilizador });
            modelBuilder.Entity<Empresa>().HasKey(em => new { em.idUtilizador, em.idEmpresa });
            modelBuilder.Entity<Encomenda>().HasKey(e => new { e.idCliente, e.idEncomendaProduto });
            modelBuilder.Entity<EncomendaProduto>().HasKey(ep => new { ep.idProduto });
            modelBuilder.Entity<Entrega>().HasKey(ent => new { ent.idCondutor, ent.idEncomenda });
            modelBuilder.Entity<Produto>().HasKey(p => new { p.idEmpresa });
        }
    }
}
