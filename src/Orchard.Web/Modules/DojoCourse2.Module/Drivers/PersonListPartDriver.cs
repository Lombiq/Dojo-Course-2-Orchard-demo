using System;
using DojoCourse2.Module.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;

namespace DojoCourse2.Module.Drivers
{
    public class PersonListPartDriver : ContentPartDriver<PersonListPart>
    {
        protected override DriverResult Display(PersonListPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_PersonList", () =>
                {
                    var upperCaseDisplayType = displayType.ToUpperInvariant();
                    return shapeHelper.Parts_PersonList(DisplayType: displayType, UpperDisplayType: upperCaseDisplayType);
                }),
                ContentShape("Parts_PersonList_Summary", () => shapeHelper.Parts_Person_Summary())
            );
        }

        protected override DriverResult Editor(PersonListPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PersonList_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.PersonList",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(PersonListPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PersonListPart part, ExportContentContext context)
        {
            var element = context.Element(part.PartDefinition.Name);

            element.SetAttributeValue("Sex", part.Sex);
            element.SetAttributeValue("MaxCount", part.MaxCount);
        }

        protected override void Importing(PersonListPart part, ImportContentContext context)
        {
            var partName = part.PartDefinition.Name;

            context.ImportAttribute(partName, "Sex", value => part.Sex = (Sex)Enum.Parse(typeof(Sex), value));
            context.ImportAttribute(partName, "MaxCount", value => part.MaxCount = int.Parse(value));
        }
    }
}