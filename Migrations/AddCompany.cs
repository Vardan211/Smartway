using FluentMigrator;
using FluentMigrator.Postgres;

namespace Smartway.Migrations
{
    [Migration(202201230001)]
    public class AddCompany : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Companies")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString();
        }
    }
}