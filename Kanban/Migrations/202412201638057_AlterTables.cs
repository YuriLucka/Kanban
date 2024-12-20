namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTables : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UsuarioAreas", name: "DepartamentoID", newName: "AreaID");
            RenameColumn(table: "dbo.Tarefas", name: "Prioridade_ID", newName: "PrioridadeID");
            RenameIndex(table: "dbo.Tarefas", name: "IX_Prioridade_ID", newName: "IX_PrioridadeID");
            RenameIndex(table: "dbo.UsuarioAreas", name: "IX_DepartamentoID", newName: "IX_AreaID");
            DropColumn("dbo.Tarefas", "NivelPrioridadeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefas", "NivelPrioridadeID", c => c.Int());
            RenameIndex(table: "dbo.UsuarioAreas", name: "IX_AreaID", newName: "IX_DepartamentoID");
            RenameIndex(table: "dbo.Tarefas", name: "IX_PrioridadeID", newName: "IX_Prioridade_ID");
            RenameColumn(table: "dbo.Tarefas", name: "PrioridadeID", newName: "Prioridade_ID");
            RenameColumn(table: "dbo.UsuarioAreas", name: "AreaID", newName: "DepartamentoID");
        }
    }
}
