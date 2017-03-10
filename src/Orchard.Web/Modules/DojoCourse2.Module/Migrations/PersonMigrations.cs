using DojoCourse2.Module.Models;
using Orchard.Data.Migration;
using System;

namespace DojoCourse2.Module.Migrations
{
    public class PersonMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(PersonRecord).Name, table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("Name", column => column.WithLength(500))
                .Column<string>("Sex")
                .Column<DateTime>("BirthDateUtc")
                .Column<string>("Biography", column => column.Unlimited())
            ).AlterTable(typeof(PersonRecord).Name, table => table
                .CreateIndex("DojoCourse2.Module.PersonRecord.Name", "Name"));

            return 3;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable(typeof(PersonRecord).Name, table => table
                .CreateIndex("DojoCourse2.Module.PersonRecord.Name", "Name"));

            return 2;
        }

        public int UpdateFrom2()
        {
            SchemaBuilder.AlterTable(typeof(PersonRecord).Name, table => table
                .AddColumn<DateTime>("BirthDateUtc"));

            return 3;
        }
    }
}