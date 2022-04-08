namespace ClinicaIF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbPai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPai()
        {
            tbEstadoes = new HashSet<tbEstado>();
        }

        [Key]
        public int IdPais { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEstado> tbEstadoes { get; set; }
    }
}
