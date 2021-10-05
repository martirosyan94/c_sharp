using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Core;

namespace SocialNetwork.Core
{
    class AccountModel
    {
        public AccountType Type { get; set; }
        public string Model { get; set; }

        public AccountModel(AccountType type, string model)
        {
            Type = type;
            Model = model;
        }
    }
}
