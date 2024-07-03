using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GestorAsignaturas.Models
{
    public class Asignatura
    {
        [Key] public int  ID { get; set;  }

        [Required(ErrorMessage ="El nombre de la asignatura es obligatorio.")]
        [StringLength(100,ErrorMessage ="El nombre de la asignatura no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El codigo de la asignatura es obligatorio.")]
        [StringLength(7, ErrorMessage = "El codigo de la asignatura no puede superar los 7 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El numero de creditos de la asignatura es obligatorio.")]
        [Range(0,15, ErrorMessage = "El numero de creditos debe estar entre 0 y 15.")]
        public int Creditos { get; set; }

        [Required(ErrorMessage = "El numero de horas de la asignatura es obligatorio.")]
        [Range(1, 45, ErrorMessage = "El numero de horas debe estar entre 1 y 45.")]
        public int Horas { get; set; }



    }
}