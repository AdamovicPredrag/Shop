using OnlineShop.Application.Base;

namespace OnlineShop.Api.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
        public string Username { get; set; }

    }
}
