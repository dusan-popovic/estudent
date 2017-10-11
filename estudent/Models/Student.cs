namespace estudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Studenti")]
    public partial class Student
    {
        public int ID { get; set; }
        
        [Required]
        [BIAttribute()]
        public string BI { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string Grad { get; set; }
    }

    

}
