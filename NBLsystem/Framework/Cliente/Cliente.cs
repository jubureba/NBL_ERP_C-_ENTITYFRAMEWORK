namespace NBLsystem.Framework.Cliente
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int Idcliente { get; set; }

        [Required]
        [StringLength(50)]
        public string razaoSocial { get; set; }

        [StringLength(250)]
        public string nomeFantasia { get; set; }

        [StringLength(250)]
        public string CPFCNPJ { get; set; }

        [StringLength(50)]
        public string RG { get; set; }

        [StringLength(50)]
        public string Telefone1 { get; set; }

        [StringLength(50)]
        public string Telefone2 { get; set; }

        [StringLength(50)]
        public string Celular { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string cep { get; set; }

        [StringLength(50)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string municipio { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        [StringLength(50)]
        public string bairro { get; set; }
    }
}
