namespace GestorAsignaturas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
