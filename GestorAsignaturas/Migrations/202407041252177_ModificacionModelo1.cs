namespace GestorAsignaturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionModelo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asignaturas", "Area", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asignaturas", "Area");
        }
    }
}
