namespace NBLsystem.Framework.Cliente {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DadosModel : DbContext {
        public DadosModel()
            : base("name=DadosModel") {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.razaoSocial)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nomeFantasia)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CPFCNPJ)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.RG)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone1)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone2)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Celular)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.cep)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.endereco)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.municipio)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.estado)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.bairro)
                .IsFixedLength();
        }
    }
}
