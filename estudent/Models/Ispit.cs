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

        //[RegularExpression(@"([((19|20)\d{2})]|\d{2})\/[1-5000]")]
        [Required]
        [BIAttribute()]
        public string BI { get; set; }

        [Required]
        public string Predmet { get; set; }

        [Range(6,10,ErrorMessage ="Ocena van opsega.")]
        public int Ocena { get; set; }
    }
}
