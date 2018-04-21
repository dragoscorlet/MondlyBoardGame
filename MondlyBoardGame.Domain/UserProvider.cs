using MondlyBoardGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public static class UserProvider
    {
        public static bool IsValidUser(string username)
        {
            return new UserRepository().IsValidUser(username);
        }
    }
}
