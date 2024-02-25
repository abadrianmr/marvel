using System.Collections.Generic;
using System.Threading.Tasks;
using VisualApp.Models;

namespace VisualApp.Services
{
    public interface IHeroService
    {
        Task<Hero?> GetHero( int id );

        IAsyncEnumerable<Hero> GetHeroes();
    }
}
