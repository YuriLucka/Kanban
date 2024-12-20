namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResponsavelTarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        TarefaID = c.Int(nullable: false),
                        TipoResponsabilidadeID = c.Int(nullable: false),
                        Responsabilidade_ID = c.Int(),
                        Area_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Responsabilidades", t => t.Responsabilidade_ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .ForeignKey("dbo.Tarefas", t => t.TarefaID, cascadeDelete: true)
                .ForeignKey("dbo.Areas", t => t.Area_ID)
                .Index(t => t.UsuarioID)
                .Index(t => t.TarefaID)
                .Index(t => t.Responsabilidade_ID)
                .Index(t => t.Area_ID);
            
            CreateTable(
                "dbo.Responsabilidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        StatusTarefaID = c.Int(),
                        NivelPrioridadeID = c.Int(),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                        Prioridade_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prioridades", t => t.Prioridade_ID)
                .ForeignKey("dbo.StatusTarefas", t => t.StatusTarefaID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.UsuarioID)
                .Index(t => t.StatusTarefaID)
                .Index(t => t.Prioridade_ID);
            
            CreateTable(
                "dbo.AreaTarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        TarefaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Tarefas", t => t.TarefaID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.TarefaID);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        TarefaID = c.Int(nullable: false),
                        Texto = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tarefas", t => t.TarefaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.TarefaID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        FotoPerfil = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UsuarioAreas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        DepartamentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.DepartamentoID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.DepartamentoID);
            
            CreateTable(
                "dbo.Prioridades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        TarefaID = c.Int(nullable: false),
                        Descricao = c.String(),
                        Data = c.DateTime(),
                        HoraInicial = c.Time(precision: 7),
                        HoraFinal = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tarefas", t => t.TarefaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID)
                .Index(t => t.TarefaID);
            
            CreateTable(
                "dbo.StatusTarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponsavelTarefas", "Area_ID", "dbo.Areas");
            DropForeignKey("dbo.Tarefas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Tarefas", "StatusTarefaID", "dbo.StatusTarefas");
            DropForeignKey("dbo.ResponsavelTarefas", "TarefaID", "dbo.Tarefas");
            DropForeignKey("dbo.Registroes", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Registroes", "TarefaID", "dbo.Tarefas");
            DropForeignKey("dbo.Tarefas", "Prioridade_ID", "dbo.Prioridades");
            DropForeignKey("dbo.Comentarios", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.ResponsavelTarefas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioAreas", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioAreas", "DepartamentoID", "dbo.Areas");
            DropForeignKey("dbo.Comentarios", "TarefaID", "dbo.Tarefas");
            DropForeignKey("dbo.AreaTarefas", "TarefaID", "dbo.Tarefas");
            DropForeignKey("dbo.AreaTarefas", "AreaID", "dbo.Areas");
            DropForeignKey("dbo.ResponsavelTarefas", "Responsabilidade_ID", "dbo.Responsabilidades");
            DropIndex("dbo.Registroes", new[] { "TarefaID" });
            DropIndex("dbo.Registroes", new[] { "UsuarioID" });
            DropIndex("dbo.UsuarioAreas", new[] { "DepartamentoID" });
            DropIndex("dbo.UsuarioAreas", new[] { "UsuarioID" });
            DropIndex("dbo.Comentarios", new[] { "TarefaID" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioID" });
            DropIndex("dbo.AreaTarefas", new[] { "TarefaID" });
            DropIndex("dbo.AreaTarefas", new[] { "AreaID" });
            DropIndex("dbo.Tarefas", new[] { "Prioridade_ID" });
            DropIndex("dbo.Tarefas", new[] { "StatusTarefaID" });
            DropIndex("dbo.Tarefas", new[] { "UsuarioID" });
            DropIndex("dbo.ResponsavelTarefas", new[] { "Area_ID" });
            DropIndex("dbo.ResponsavelTarefas", new[] { "Responsabilidade_ID" });
            DropIndex("dbo.ResponsavelTarefas", new[] { "TarefaID" });
            DropIndex("dbo.ResponsavelTarefas", new[] { "UsuarioID" });
            DropTable("dbo.StatusTarefas");
            DropTable("dbo.Registroes");
            DropTable("dbo.Prioridades");
            DropTable("dbo.UsuarioAreas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Comentarios");
            DropTable("dbo.AreaTarefas");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Responsabilidades");
            DropTable("dbo.ResponsavelTarefas");
            DropTable("dbo.Areas");
        }
    }
}
