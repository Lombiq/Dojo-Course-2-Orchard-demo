using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Orchard.Caching.Services;

namespace DojoCourse2.Module.Controllers
{
    public class CacheController : Controller
    {
        private readonly ICacheService _cacheService;


        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }


        public string Index()
        {
            return _cacheService.Get("DemoCache", SlowVerySlow, TimeSpan.FromSeconds(15));
        }


        private string SlowVerySlow()
        {
            Thread.Sleep(10000);
            return DateTime.UtcNow.ToString();
        }
    }
}