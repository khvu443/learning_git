using Application.Common.Interfaces.Persistence;
using Domain.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly WebDbContext webDbContext;

        public RoleRepository(WebDbContext webDbContext)
        {
            this.webDbContext = webDbContext;
        }

        public List<Roles> GetRoles()
        {
            return webDbContext.Roles.ToList();
        }
    }
}
