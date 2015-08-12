using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Communicator.Models
{
    [XmlRoot("User")]
    public class UserModel
    {
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public string SamAccountName { get; set; }
        public string OrganizationalUnit { get; set; }

    }
}