using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace DojoCourse2.Module
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineStyle("DemoStyles").SetUrl("demo-styles.css");
        }
    }
}