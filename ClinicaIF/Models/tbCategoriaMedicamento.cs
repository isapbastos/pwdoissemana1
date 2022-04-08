namespace ClinicaIF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbCategoriaMedicamento")]
    public partial class tbCategoriaMedicamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCategoriaMedicamento()
        {
            tbMedicamentoes = new HashSet<tbMedicamento>();
        }

        [Key]
        public int IdCategoriaMedicamento { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(5000)]
        public string InformacaoComplementar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMedicamento> tbMedicamentoes { get; set; }
    }
}
