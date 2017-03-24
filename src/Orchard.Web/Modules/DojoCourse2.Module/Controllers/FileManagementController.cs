using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.FileSystems.Media;
using Orchard.Services;

namespace DojoCourse2.Module.Controllers
{
    public class FileManagementController : Controller
    {
        private readonly IStorageProvider _storageProvider;
        private readonly IClock _clock;


        public FileManagementController(IStorageProvider storageProvider, IClock clock)
        {
            _storageProvider = storageProvider;
            _clock = clock;
        }


        public void Index()
        {
            var filePath = "Demo/NotMeerkat.txt";
            IStorageFile file;
            if (!_storageProvider.FileExists(filePath))
            {
                file = _storageProvider.CreateFile(filePath); 
            }
            else
            {
                file = _storageProvider.GetFile(filePath);
            }
            using (var stream = file.OpenWrite())
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write("Hello world! " + _clock.UtcNow.ToString());
            }
        }
    }
}