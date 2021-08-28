using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FactoryMethod
{
    public class UserModelFactory
    {
        public UserViewModel GetModelFromData(Account acc)
        {
            return new UserViewModel
            {
                UserId = acc.User.Id,
                Email = acc.Email,
                FirstName = acc.User.FirstName,
                LastName = acc.User.LastName,
                Login = acc.Login
            };
        }
    }
}
