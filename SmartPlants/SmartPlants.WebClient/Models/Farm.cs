using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartPlants.WebClient.Models
{
    public class Farm
    {
        [Key]
        [DisplayName("Id de la granja")]
        [Required]
        public int FarmId { get; set; }
        [DisplayName("Nombde granja")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Nit")]
        [Required]
        public string Nit { get; set; }
    }
}
