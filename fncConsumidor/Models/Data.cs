namespace fncConsumidor.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        public String NameDevice { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public String Event { get; set; }


    }
}

