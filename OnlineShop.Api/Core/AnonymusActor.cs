using OnlineShop.Application.Base;

namespace OnlineShop.Api.Core
{
        public class AnonymousActor : IApplicationActor
        {
            public int Id => 0;

            public string Identity => "Anonymus";
         
            public IEnumerable<int> AllowedUseCases => new List<int> {1};

    }
}
