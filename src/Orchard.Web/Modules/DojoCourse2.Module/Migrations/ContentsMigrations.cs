using DojoCourse2.Module.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Data.Migration.Schema;

namespace DojoCourse2.Module.Migrations
{
    public class ContentsMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(typeof(PersonListPartRecord).Name, table => table
                .ContentPartRecord()
                .Column<string>("Sex")
                .Column<int>("MaxCount"));

            ContentDefinitionManager.AlterPartDefinition(typeof(PersonListPart).Name, builder => builder
                .Attachable());

            ContentDefinitionManager.AlterTypeDefinition(Constants.ContentTypeNames.PersonList, type => type
                .DisplayedAs("Person List")
                .Creatable()
                .WithPart("TitlePart")
                .WithPart("AutoroutePart", part => part
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Title', Pattern: 'person-lists/{Content.Slug}', Description: 'my-list'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart(typeof(PersonListPart).Name)
                .WithPart("CommonPart"));

            ContentDefinitionManager.AlterTypeDefinition(Constants.ContentTypeNames.PersonListWidget, type => type
                .WithPart(typeof(PersonListPart).Name)
                .AsWidgetWithIdentity());

            return 2;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition(Constants.ContentTypeNames.PersonListWidget, type => type
                .WithPart(typeof(PersonListPart).Name)
                .AsWidgetWithIdentity());

            return 2;
        }
    }
}