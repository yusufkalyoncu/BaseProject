using System;
using Microsoft.AspNetCore.Identity;

namespace BaseProject.Domain.Entities.Identity
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public RoleEntity()
        {
        }

        public RoleEntity(string roleName) : base(roleName)
        {
        }
    }
}

