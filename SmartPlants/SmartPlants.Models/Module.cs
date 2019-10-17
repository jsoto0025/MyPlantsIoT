using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlants.Models
{
    /// <summary>
    /// Objeto POCO de un módulo de una granja hidrofonica
    /// </summary>
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        [ForeignKey("FarmId")]
        public virtual Farm Farm { get; set; }

        public int PlantTypeId { get; set; }
        [ForeignKey("PlantTypeId")]
        public PlantType PlantType { get; set; }

    }
}
