using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Objects.Users
{
    public sealed partial class User
    {
        public UserId Id { get; private set; }
        
        public RoleId RoleId { get; private set; }
        
        public UserFullName FullName { get; private set; }
        
        public UserLogin Login { get; private set; }
        
        public UserPasswordHash PasswordHash { get; private set; }

        public void ChangeRoleId(RoleId roleId)
            => RoleId = roleId;

        public void ChangeFullName(UserFullName fullName) 
            => FullName = fullName;

        public void ChangeLogin(UserLogin login)
            => Login = login;

        public void ChangePasswordHash(UserPasswordHash passwordHash)
            => PasswordHash = passwordHash;
    }
}
