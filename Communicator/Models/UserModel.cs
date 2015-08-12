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