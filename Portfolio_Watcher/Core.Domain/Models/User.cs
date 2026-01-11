using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class User
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public double Balance { get; private set; }
        public double Equity { get; private set; }

        public User(string userId, string userName, string password, double balance, double equity)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Balance = balance;
            Equity = equity;
        }
    }
}
