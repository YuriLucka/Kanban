namespace Kanban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableResponsavelTarefa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResponsavelTarefa", "Responsabilidade_ID", "dbo.Responsabilidade");
            DropIndex("dbo.ResponsavelTarefa", new[] { "Responsabilidade_ID" });
            RenameColumn(table: "dbo.ResponsavelTarefa", name: "Responsabilidade_ID", newName: "ResponsabilidadeID");
            AlterColumn("dbo.ResponsavelTarefa", "ResponsabilidadeID", c => c.Int(nullable: false));
            CreateIndex("dbo.ResponsavelTarefa", "ResponsabilidadeID");
            AddForeignKey("dbo.ResponsavelTarefa", "ResponsabilidadeID", "dbo.Responsabilidade", "ID", cascadeDelete: true);
            DropColumn("dbo.ResponsavelTarefa", "TipoResponsabilidadeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ResponsavelTarefa", "TipoResponsabilidadeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ResponsavelTarefa", "ResponsabilidadeID", "dbo.Responsabilidade");
            DropIndex("dbo.ResponsavelTarefa", new[] { "ResponsabilidadeID" });
            AlterColumn("dbo.ResponsavelTarefa", "ResponsabilidadeID", c => c.Int());
            RenameColumn(table: "dbo.ResponsavelTarefa", name: "ResponsabilidadeID", newName: "Responsabilidade_ID");
            CreateIndex("dbo.ResponsavelTarefa", "Responsabilidade_ID");
            AddForeignKey("dbo.ResponsavelTarefa", "Responsabilidade_ID", "dbo.Responsabilidade", "ID");
        }
    }
}
