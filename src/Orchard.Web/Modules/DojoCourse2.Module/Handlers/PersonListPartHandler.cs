using System.Web.Routing;
using DojoCourse2.Module.Models;
using DojoCourse2.Module.Services;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment;

namespace DojoCourse2.Module.Handlers
{
    public class PersonListPartHandler : ContentHandler
    {
        public PersonListPartHandler(
            IRepository<PersonListPartRecord> repository,
            Work<IPersonManager> personManagerWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<PersonListPart>((context, part) =>
            {
                part.PersonsField.Loader(() => personManagerWork.Value.GetPersons(part.Sex, part.MaxCount));
            });
        }


        protected override void GetItemMetadata(GetContentItemMetadataContext context)
        {
            if (context.ContentItem.ContentType != Constants.ContentTypeNames.PersonList) return;

            context.Metadata.EditorRouteValues = new RouteValueDictionary
            {
                { "area", "DojoCourse2.Module" },
                { "controller", "ContentsAdmin" },
                { "action", "PersonListDashboard" },
                { "id", context.ContentItem.Id }
            };
        }
    }
}