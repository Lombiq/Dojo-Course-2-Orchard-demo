using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.UI.Admin;

namespace DojoCourse2.Module.Controllers
{
    [Admin]
    public class ContentsAdminController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly IOrchardServices _orchardServices;


        public ContentsAdminController(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
            _contentManager = orchardServices.ContentManager;
        }


        public ActionResult PersonListDashboard(int id = 0)
        {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManagePersonListDashboard))
            {
                return new HttpUnauthorizedResult();
            }

            ContentItem contentItem;

            if (id == 0)
            {
                contentItem = _contentManager.New("PersonList");
            }
            else
            {
                contentItem = _contentManager.Get(id);

                if (contentItem == null)
                {
                    return HttpNotFound();
                }
            }

            var displayShape = _contentManager.BuildDisplay(contentItem, "Detail");
            var personListDashboardShape = _orchardServices.New
                .DojoCourse2_PersonListDashboard(PersonListDashboardShape: displayShape);

            return new ShapeResult(this, personListDashboardShape);
        }

        public void PersonListQueries()
        {
            var personListCount = _contentManager.Query("PersonList").Count();
            var personLists = _contentManager.Query("PersonList").Slice(1, 1);
        }
    }
}