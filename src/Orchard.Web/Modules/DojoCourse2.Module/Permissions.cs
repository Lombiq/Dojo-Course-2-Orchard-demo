using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;

namespace DojoCourse2.Module
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManagePersonListDashboard = new Permission
        {
            Name = "ManagePersonListDashboard",
            Description = "Able to interact with the Person List dashboard."
        };

        public Feature Feature { get; set; }


        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManagePersonListDashboard }
                }
            };
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                ManagePersonListDashboard
            };
        }
    }
}