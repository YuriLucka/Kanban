namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTables1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Areas", newName: "Area");
            RenameTable(name: "dbo.ResponsavelTarefas", newName: "ResponsavelTarefa");
            RenameTable(name: "dbo.Responsabilidades", newName: "Responsabilidade");
            RenameTable(name: "dbo.Tarefas", newName: "Tarefa");
            RenameTable(name: "dbo.AreaTarefas", newName: "AreaTarefa");
            RenameTable(name: "dbo.Comentarios", newName: "Comentario");
            RenameTable(name: "dbo.Usuarios", newName: "Usuario");
            RenameTable(name: "dbo.UsuarioAreas", newName: "UsuarioArea");
            RenameTable(name: "dbo.Prioridades", newName: "Prioridade");
            RenameTable(name: "dbo.Registroes", newName: "Registro");
            RenameTable(name: "dbo.StatusTarefas", newName: "StatusTarefa");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StatusTarefa", newName: "StatusTarefas");
            RenameTable(name: "dbo.Registro", newName: "Registroes");
            RenameTable(name: "dbo.Prioridade", newName: "Prioridades");
            RenameTable(name: "dbo.UsuarioArea", newName: "UsuarioAreas");
            RenameTable(name: "dbo.Usuario", newName: "Usuarios");
            RenameTable(name: "dbo.Comentario", newName: "Comentarios");
            RenameTable(name: "dbo.AreaTarefa", newName: "AreaTarefas");
            RenameTable(name: "dbo.Tarefa", newName: "Tarefas");
            RenameTable(name: "dbo.Responsabilidade", newName: "Responsabilidades");
            RenameTable(name: "dbo.ResponsavelTarefa", newName: "ResponsavelTarefas");
            RenameTable(name: "dbo.Area", newName: "Areas");
        }
    }
}
