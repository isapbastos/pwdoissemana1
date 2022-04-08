namespace ClinicaIF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbLancarReceitasDespesa
    {
        [Key]
        public int IdLancamento { get; set; }

        public int IdReceitaDespesa { get; set; }

        public DateTime Data { get; set; }

        public virtual tbGruposReceitasDespesa tbGruposReceitasDespesa { get; set; }
    }
}
