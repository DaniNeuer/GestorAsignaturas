namespace GestorAsignaturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionModelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asignaturas", "CD", c => c.Int(nullable: false));
            AddColumn("dbo.Asignaturas", "CP", c => c.Int(nullable: false));
            AddColumn("dbo.Asignaturas", "AA", c => c.Int(nullable: false));
            DropColumn("dbo.Asignaturas", "Horas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asignaturas", "Horas", c => c.Int(nullable: false));
            DropColumn("dbo.Asignaturas", "AA");
            DropColumn("dbo.Asignaturas", "CP");
            DropColumn("dbo.Asignaturas", "CD");
        }
    }
}
