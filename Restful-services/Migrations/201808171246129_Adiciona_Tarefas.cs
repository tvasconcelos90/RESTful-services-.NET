namespace Restful_services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adiciona_Tarefas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 50),
                        Descricao = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarefas");
        }
    }
}
