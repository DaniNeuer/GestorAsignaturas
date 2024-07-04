namespace GestorAsignaturas.Migrations
{
    using GestorAsignaturas.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GestorAsignaturas.DAL.GestorData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GestorAsignaturas.DAL.GestorData";
        }

        protected override void Seed(GestorAsignaturas.DAL.GestorData context)
        {
            try
            {
                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method
                //  to avoid creating duplicate seed data.

                //añadir las asignaturas

                context.Asignaturas.AddOrUpdate(
                a => a.Codigo,
                new Asignatura { Nombre = "Álgebra Lineal", Codigo = "MATD113", Creditos = 3, CD = 6, CP = 0, AA = 3, Area = "Matemáticas" },
                new Asignatura { Nombre = "Programación Avanzada", Codigo = "ITID433", Creditos = 3, CD = 3, CP = 3, AA = 3, Area = "Programación" },
                new Asignatura { Nombre = "Bases de Datos", Codigo = "ITID443", Creditos = 3, CD = 6, CP = 0, AA = 3, Area = "Bases de Datos" },
                new Asignatura { Nombre = "Sistemas Operativos", Codigo = "ITID452", Creditos = 2, CD = 4, CP = 0, AA = 2, Area = "Sistemas Operativos" },
                new Asignatura { Nombre = "Redes de Área Local", Codigo = "ITID623", Creditos = 3, CD = 3, CP = 3, AA = 3, Area = "Redes" }
                 );
                //Cambios guardados en el database
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
                throw; 
            }
        }
    }
}
