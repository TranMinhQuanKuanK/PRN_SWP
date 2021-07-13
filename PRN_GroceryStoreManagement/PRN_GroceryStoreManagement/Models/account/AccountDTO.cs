using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN_GroceryStoreManagement.Models.account
{
    public class AccountDTO 
    {
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool is_owner { get; set; }

        public AccountDTO(string username, string password, string name, bool is_owner)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.is_owner = is_owner;
        }

        public AccountDTO(string username, string name, bool is_owner)
        {
            this.username = username;
            this.name = name;
            this.is_owner = is_owner;
        }

    }
}
