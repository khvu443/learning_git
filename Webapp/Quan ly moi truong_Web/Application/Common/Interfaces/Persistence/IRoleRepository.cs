using Domain.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Persistence
{
    public interface IRoleRepository
    {
        List<Roles> GetRoles();
    }
}
