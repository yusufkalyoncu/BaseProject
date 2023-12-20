using System;
using Microsoft.AspNetCore.Identity;

namespace BaseProject.Domain.Entities.Identity
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireAt { get; set; }
    }
}

