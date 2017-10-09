namespace estudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ispiti")]
    public partial class Ispit
    {
        public int ID { get; set; }

        [Required]
        public string BI { get; set; }

        [Required]
        public string Predmet { get; set; }

        public int Ocena { get; set; }
    }
}
