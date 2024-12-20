namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableRegistro3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registro", "HoraInicial", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Registro", "HoraFinal", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registro", "HoraFinal", c => c.Time(precision: 7));
            AlterColumn("dbo.Registro", "HoraInicial", c => c.Time(precision: 7));
        }
    }
}
