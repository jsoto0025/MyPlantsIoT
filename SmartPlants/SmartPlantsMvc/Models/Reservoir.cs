using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlantsMvc.Models
{
    public class Reservoir
    {
        [Key]
        public int ReservoirId { get; set;}
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module Module { get; set; }
        /// <summary>
        /// Capacidad en litros del reservorio
        /// </summary>
        [DefaultValue(50)]
        int Capacity { get; set; }
    }
}
