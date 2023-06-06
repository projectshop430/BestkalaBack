using Domain.Entitis.user;

namespace DatingApps.Services.Interface
{
    public interface ITokenServices
    {
        public string CreateToken(User user);
    }
}
