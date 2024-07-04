// ************************************************************************
// Practica 09
// Josue Chicaiza - Daniel Tapia
// Fecha de realización: 03/07/2024
// Fecha de entrega: 10/07/2024
// Resultados:
// * Se logra ejecutar la aplicacion de Asignatura, al modificar las rutas se tiene como default el controlador Asignatura.
// Se verificar la funcionalidad del CRUD, las validaciones funcionan bien, por ejemplo, si se quiere agregar mas de 100 
// caracteres en nombre aparecera un mensaje a la derecha del imput indicando el error y no se podra agregar la asignatura.
// * En la prueba de aplicacion se modifica la URL de la accion Detalle en la cual se quita el argumento de la ID 
// no va a funcionar ya que el metodo de accion Detalle recibe como argumento el id y sin el argumento en la URL no
// va ser posible ejecutar el metodo de accion.
// * Tambien se modifico el URL para que la solicitud de la accion Detalle/1000, esto tampcoo funciona ya que este ID no 
// existe en la base de datos y no sera posible encontrar.
// *
// Conclusiones:
// Recomendaciones:
// ************************************************************************
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