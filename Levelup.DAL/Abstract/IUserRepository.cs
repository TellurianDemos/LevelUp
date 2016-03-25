using Levelup.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.DAL.Abstract
{
    public interface IUserRepository
    {
        Task<bool> UsersInRoleExistAsync(string rolename);
    }
}
