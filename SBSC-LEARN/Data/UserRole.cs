using Microsoft.AspNetCore.Identity;
using System;

namespace SBSC_LEARN.Data
{
    public class UserRole : IdentityRole<Guid>
    {
        public UserRole()
            : base()
        {

        }
        public UserRole(string roleName)
            : base(roleName)
        {

        }
    }
}