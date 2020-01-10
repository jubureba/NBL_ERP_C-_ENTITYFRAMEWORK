namespace NBLsystem.Framework.Login {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DadosModel : DbContext {
        public DadosModel()
            : base("name=DadosModel") {
        }

        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<users>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.cpf)
                .IsUnicode(false);
        }
    }
}
