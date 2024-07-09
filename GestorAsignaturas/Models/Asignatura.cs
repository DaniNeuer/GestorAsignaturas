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
// *  La separación de preocupaciones implementada a través del patrón MVC  permite que
// cada componente de la aplicación (modelos, vistas y controladores) sea desarrollado y mantenido de manera
// independiente. Esto facilita el mantenimiento del código, tambien permite el reuso de código y la escabilidad de la
// aplicación.
// * El uso de validaciones en los modelos garantiza que los datos ingresados cumplan con los requisistos establecidos
// antes de pasarlos a la base de datos.
// * El uso de entity Framework para la conexión a la base de datos  permite una integración eficiente entre el modelo de
// datos y la lógica de negocio, reduciendo la cantidad de código necesario para realizar operaciones CRUD.
// Recomendaciones:
// *Es recomendable mejorar las validaciones de los modelos para cubrir todos los posibles casos de uso y garantizar
// que los datos ingresados sean consistentes y válidos. 
// ************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.ConstrainedExecution;


namespace GestorAsignaturas.Models
{
    public class Asignatura
    {
        // El adorno [key] indica que sera una llave primaria
        [Key]
        public int ID { get; set; }
        // El adornor indica que el atrinuto nombre es obligatorio y se mostrara el mensaje de error
        // con el adornor [StringLength]  se indicara el maximo de caracteres que tendra el atributo
        [Required(ErrorMessage = "El nombre de la asignatura es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la asignatura no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }
        // se indica que el atributo codigo es obligatorio y con un maximo de 7 caracteres
        [Required(ErrorMessage = "El código de la asignatura es obligatorio.")]
        [StringLength(7, ErrorMessage = "El código de la asignatura no puede superar los 7 caracteres.")]
        public string Codigo { get; set; }
        // Se indica que el atributo credito es obligatorio y debe ser un valor entre 0 y 15
        [Required(ErrorMessage = "El número de créditos de la asignatura es obligatorio.")]
        [Range(0, 15, ErrorMessage = "El número de créditos debe estar entre 0 y 15.")]
        public int Creditos { get; set; }
        // Se indica que el atributo CD es obligatorio y su valor debe ser entre 1 y 45
        [Required(ErrorMessage = "El número de horas de clase directa (CD) es obligatorio.")]
        [Range(1, 45, ErrorMessage = "El número de horas de clase directa debe estar entre 1 y 45.")]
        public int CD { get; set; } = 1;
        // Se indica que el atributo CP es obligatorio y su valor debe ser entre 0 y 45
        [Range(0, 45, ErrorMessage = "El número de horas de clase práctica debe estar entre 0 y 45.")]
        public int CP { get; set; }
        //Se indica que el atributo AA es obligatorio y su valor debe ser entre 1 y 45
        [Required(ErrorMessage = "El número de horas de aprendizaje autónomo (AA) es obligatorio.")]
        [Range(1, 45, ErrorMessage = "El número de horas de aprendizaje autónomo debe estar entre 1 y 45.")]
        public int AA { get; set; } = 1;

        [NotMapped]
        public int Horas
        {
            get { return CD + CP + AA; }
        }

        public string Area { get; set; } = "sin área";

        public Asignatura()
        {
            // Establecer valores predeterminados
            CP = 0;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (Creditos == 0 && CD < 2)
            {
                errors.Add(new ValidationResult("El número de horas de clase directa debe ser al menos 2 cuando los créditos son 0.", new[] { "CD" }));
            }
            else if (Creditos > 0)
            {
                int totalHoras = Creditos * 3;
                if (Horas != totalHoras)
                {
                    errors.Add(new ValidationResult($"El número total de horas ({Horas}) no coincide con el número de créditos multiplicado por 3 ({totalHoras}).", new[] { "Horas" }));
                }
            }
            return errors;
        }
    }



}