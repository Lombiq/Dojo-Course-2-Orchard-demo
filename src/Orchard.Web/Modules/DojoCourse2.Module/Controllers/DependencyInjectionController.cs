using Orchard;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.UI.Notify;
using System.Web.Mvc;

namespace DojoCourse2.Module.Controllers
{
    public class DependencyInjectionController : Controller
    {
        private readonly INotifier _notifier;
        private readonly IWorkContextAccessor _wca;
        private readonly IHttpContextAccessor _hca;


        public Localizer T { get; set; }
        public ILogger Logger { get; set; }


        public DependencyInjectionController(INotifier notifier, IWorkContextAccessor wca, IHttpContextAccessor hca)
        {
            _notifier = notifier;
            _wca = wca;
            _hca = hca;

            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }


        public ActionResult NotifyMe()
        {
            var workContext = _wca.GetContext();
            var currentUser = workContext.CurrentUser;

            var currentUrl = _hca.Current().Request.Url.ToString();

            var userName = currentUser == null ? "Anonymous" : currentUser.UserName;

            _notifier.Information(T("Hello to \"{0}\", user {1}!", currentUrl, userName));

            Logger.Error("The user has been greeted!");

            return RedirectToAction("Index", "YourFirstOrchard");
        }
    }
}