using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281_Milestone_2
{
    public class UserAccount
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public UserAccount(string username, string password)
    {
        Username = username;
        PasswordHash = password;
    }

    public bool ValidatePassword(string password)
    {
        return PasswordHash == password;
    }
}
}
