using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.UI.Admin;
using Orchard.UI.Resources;

namespace DojoCourse2.Module.Filters
{
    public class ResourceFilter : FilterProvider, IResultFilter
    {
        private readonly IResourceManager _resourceManager;


        public ResourceFilter(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }



        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (AdminFilter.IsApplied(filterContext.RequestContext))
            {
                return;
            }

            if (filterContext.Result is PartialViewResult)
            {
                return;
            }

            _resourceManager.Require("stylesheet", "DemoStyles");
        }
    }
}