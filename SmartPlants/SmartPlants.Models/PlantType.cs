﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartPlants.Models
{
    /// <summary>
    /// Objeto POCO que representa el tipo de plantas en un cultivo hidrofónico.
    /// </summary>
    public class PlantType
    {
        /// <summary>
        /// Identificador único del tipo de planta
        /// </summary>
        [Key]
        public int PlantTypeId { get; set; }
        /// <summary>
        /// Nombre del tipo de planta
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Descripción del tipo de planta
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
