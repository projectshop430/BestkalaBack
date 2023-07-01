using Domain.Entitis.user;

namespace BestKalas.Services.Interface
{
    public interface ITokenServices
    {
        public string CreateToken(User user,int x);
    }
}
