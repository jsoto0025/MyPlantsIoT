using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPlantsMvc.Models
{
    /// <summary>
    /// Objeto POCO de un módulo de una granja hidrofonica
    /// </summary>
    public class Module
    {
        public int Id { get; set; }
        [ForeignKey("Farm")]
        public int FarmId
        {get;set;}
        public virtual Farm Farm { get; set; }
        [ForeignKey("PlantType")]
        public int PlantTypeId
        { get; set; }
        public virtual PlantType PlantType { get; set; }

    }
}
