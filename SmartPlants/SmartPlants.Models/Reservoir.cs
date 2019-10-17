using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlants.Models
{
    /// <summary>
    /// Objeto POCO de un módulo de una granja hidrofonica
    /// </summary>
    public class Reservoir
    {
        [Key]
        public int ReservoirId { get; set; }
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module Module { get; set; }
        /// <summary>
        /// Capacidad en litros del reservorio
        /// </summary>
        [DefaultValue(50)]
        [Range(0, 50)]
        [Required]
        public int Capacity { get; set; }
    }
}
