using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartPlantsMvc.Models
{
    /// <summary>
    /// Clase POCO de los objetos Granja (Farm)
    /// </summary>
    public class Farm
    {
        /// <summary>
        /// Identificador unico requerido por el modelo
        /// </summary>
        [Key]
        public int FarmId { get; set; }
        /// <summary>
        /// Nombre de la granja o razón social
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Nit de la granja
        /// </summary>
        [Required]
        public string Nit { get; set; }


    }
}
