namespace ClinicaIF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbGruposReceitasDespesa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbGruposReceitasDespesa()
        {
            tbLancarReceitasDespesas = new HashSet<tbLancarReceitasDespesa>();
        }

        [Key]
        public int IdReceitaDespesa { get; set; }

        public int Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLancarReceitasDespesa> tbLancarReceitasDespesas { get; set; }
    }
}
