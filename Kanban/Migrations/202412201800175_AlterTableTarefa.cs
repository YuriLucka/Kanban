namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableTarefa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefa", "Titulo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarefa", "Titulo");
        }
    }
}
