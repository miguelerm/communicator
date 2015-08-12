using Communicator.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Communicator.Services
{
    public class UserService
    {

        public async Task CreateCurrentUserIfNotExistsAsync()
        {
            await CreateIfNotExistsAsync(GetCurrent());
        }

        public UserModel GetCurrent()
        {
            var current = UserPrincipal.Current;
            return new UserModel
            {
                Name = Thread.CurrentPrincipal.Identity.Name,
                DistinguishedName = current.DistinguishedName,
                EmailAddress = current.EmailAddress,
                DisplayName = current.DisplayName,
                SamAccountName = current.SamAccountName,
                OrganizationalUnit = GetOrganizationalUnit(current)
            };
        }

        private Task CreateIfNotExistsAsync(UserModel user)
        {
            // TODO: create user in db.
            return Task.FromResult(0);
        }

        private string GetOrganizationalUnit(UserPrincipal user)
        {
            string result = string.Empty;
            //Getting the directoryEntry's path and spliting with the "," character
            string[] directoryEntryPath = user.DistinguishedName.Split(',');
            //Getting the each items of the array and spliting again with the "=" character
            foreach (var splitedPath in directoryEntryPath)
            {
                string[] eleiments = splitedPath.Split('=');
                //If the 1st element of the array is "OU" string then get the 2dn element
                if (eleiments[0].Trim() == "OU")
                {
                    result = eleiments[1].Trim();
                    break;
                }
            }
            return result;
        }
        
    }
}