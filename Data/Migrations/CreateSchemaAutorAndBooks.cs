using FluentMigrator;

namespace Autor_Books_Api.Data.Migrations
{
    [Migration(160320251)]
    public class CreateSchemaAutorAndBooks:Migration
    {
        public override void Up()
        {
            Create.Table("autors")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(120).NotNullable()
                .WithColumn("email").AsString(120).NotNullable()
                .WithColumn("age").AsInt32().NotNullable();

            Create.Table("books")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(120).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("autor_id").AsInt32().ForeignKey("autors", "id").OnDelete(System.Data.Rule.Cascade);
             




        }


        public override void Down()
        {
            Delete.Table("books");
            Delete.Table("autors");
        }







    }
}
