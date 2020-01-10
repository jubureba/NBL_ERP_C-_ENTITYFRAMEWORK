namespace NBLsystem.Framework.Login
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [Key]
        public int Id_users { get; set; }

        [Required]
        [StringLength(70)]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string senha { get; set; }

        [Required]
        [StringLength(50)]
        public string cpf { get; set; }

        public int level { get; set; }
    }
}
