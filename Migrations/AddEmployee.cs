using FluentMigrator;

namespace Smartway.Migrations
{
    [Migration(202201230002)]
    public class AddEmployee : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Passports")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Type").AsString()
                .WithColumn("Number").AsString();
            Create.Table("Departments")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString()
                .WithColumn("Phone").AsString();

            Create.Table("Employees")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Surname").AsString().Nullable()
                .WithColumn("Phone").AsString().Nullable()
                .WithColumn("CompanyId").AsInt32().Nullable().ForeignKey("Companies", "Id")
                .WithColumn("PassportId").AsInt32().Nullable().ForeignKey("Passports", "Id")
                .WithColumn("DepartmentId").AsInt32().Nullable().ForeignKey("Departments", "Id");
        }
    }
}