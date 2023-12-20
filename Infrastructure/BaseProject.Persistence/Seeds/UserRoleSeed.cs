using System;
using BaseProject.Application.Constants;
using BaseProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Persistence.Seeds
{
    public class UserRoleSeed
    {
        public static async Task Seed(IServiceProvider service)
        {
            var roleManager = service.GetRequiredService<RoleManager<RoleEntity>>();

            await SeedUserRoleItem(roleManager, UserRole.OWNER);
            await SeedUserRoleItem(roleManager, UserRole.ADMIN);
            await SeedUserRoleItem(roleManager, UserRole.USER);
        }

        private static async Task<RoleEntity> SeedUserRoleItem(RoleManager<RoleEntity> roleManager, string roleName)
        {
            RoleEntity roleEntity = new RoleEntity(roleName);

            bool userRole = await roleManager.RoleExistsAsync(roleName);

            if (userRole is false)
            {
                await roleManager.CreateAsync(roleEntity);
            }

            return roleEntity;
        }
    }
}

