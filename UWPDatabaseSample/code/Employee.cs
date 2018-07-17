using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPDatabaseSample.code
{
   
    public class Employee
    {
        private string name { get; set; }
        private string organizationUnit { get; set; }
        private string groupId { get; set; }
        private string department { get; set; }
        private string username { get; set; }
        private string password { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string OrganizationUnit
        {
            get { return organizationUnit; }
            set { organizationUnit = value; }
        }

        public string GroupID
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
